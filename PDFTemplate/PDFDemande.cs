using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Text;

public class PDFDemande
{
    public static string Nom { get; set; }
    public static string Prenoms { get; set; }
    public static string DateNaissance { get; set; }
    public static string NomPrenomBenef { get; set; }
    public static string DateNaissanceBenef { get; set; }
    public static string Description { get; set; }
    public static string DateActe { get; set; }
    public static string Immatriculation { get; set; }

    public static Document GenerateDocument(
        string nom,
        string prenoms,
        string dateNaissance,
        string description,
        string dateActe,
        string immatriculation,
        string nomPrenomBenef = "",
        string dateNaissanceBenef = "")
    {
        Nom = nom;
        Prenoms = prenoms;
        DateNaissance = dateNaissance;
        NomPrenomBenef = nomPrenomBenef;
        DateNaissanceBenef = dateNaissanceBenef;
        Description = description;
        DateActe = dateActe;
        Immatriculation = immatriculation;

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(0);
                page.Content().Svg(GenerateSvg());

                //page.Content().Layers(layers =>
                //{
                //    // Background PNG image
                //    layers.PrimaryLayer()
                //        .Image(GetEmbeddedResource("form.png"))
                //        .FitArea();

                //    // Text overlay via SVG
                //    layers.Layer().Svg(GenerateSvg());
                //});
            });
        });
    }

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(0);
            page.Content().Svg(GenerateSvg());
        });
    }

    private static byte[] GetEmbeddedResource(string fileName)
    {
        var assembly = typeof(PDFDemande).Assembly;

        var resourceName = assembly.GetManifestResourceNames()
            .FirstOrDefault(n => n.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));

        if (resourceName == null)
            throw new Exception("Embedded image not found: " + fileName +
                "\nAvailable resources:\n" + string.Join("\n", assembly.GetManifestResourceNames()));

        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        return ms.ToArray();
    }

    private static string GenerateSvg()
    {
        var sb = new StringBuilder();

        // A4 in pixels (96 DPI)
        int width = 794;
        int height = 1123;

        sb.AppendLine(@"<?xml version='1.0' encoding='UTF-8'?>");
        sb.AppendLine($@"<svg width='{width}' height='{height}' viewBox='0 0 {width} {height}' xmlns='http://www.w3.org/2000/svg'>");
        sb.AppendLine(@"<style>");
        sb.AppendLine(@"    text { font-family: Arial Black, Arial, sans-serif; fill: black; font-weight: bold; }");
        sb.AppendLine(@"</style>");

        // Positions converted roughly from cm → px (1 cm ≈ 37.8 px)
        AddText(sb, Immatriculation ?? "", 150, 117);   // 15, 11.7
        AddText(sb, Nom ?? "", 28, 116);                // 2.8, 11.6
        AddText(sb, Prenoms ?? "", 34, 121);            // 3.4, 12.1
        AddText(sb, DateNaissance ?? "", 49, 127);      // 4.9, 12.7
        AddText(sb, NomPrenomBenef ?? "", 45, 146);     // 4.5, 14.6
        AddText(sb, DateNaissanceBenef ?? "", 164, 145);// 16.4, 14.5
        AddText(sb, DateActe ?? "", 43, 207);           // 4.3, 20.7

        AddDescriptionText(sb, Description ?? "", 44, 189, 18, 195);


        sb.AppendLine("</svg>");

        return sb.ToString();
    }

    private static void AddText(StringBuilder sb, string text, double xMm, double yMm, double maxWidthMm = 150)
    {
        if (string.IsNullOrWhiteSpace(text))
            return;


        string escaped = System.Security.SecurityElement.Escape(text);

        // Approximate character width in mm for your font (Arial, bold)
        double approxCharWidthMm = 2; // adjust as needed
        int maxCharsPerLine = (int)(maxWidthMm / approxCharWidthMm);

        // Split text into lines
        var lines = new List<string>();
        string remaining = escaped;
        while (remaining.Length > maxCharsPerLine)
        {
            int breakIndex = remaining.LastIndexOf(' ', maxCharsPerLine);
            if (breakIndex <= 0) breakIndex = maxCharsPerLine;
            lines.Add(remaining.Substring(0, breakIndex));
            remaining = remaining.Substring(breakIndex).TrimStart();
        }
        if (!string.IsNullOrEmpty(remaining))
            lines.Add(remaining);

        // Add font-weight='bold' to the text element
        sb.AppendLine($@"<text x='{xMm}mm' y='{yMm}mm' font-size='5.5mm' font-weight='bold'>");

        double lineHeightMm = 6; // vertical spacing between lines
        for (int i = 0; i < lines.Count; i++)
        {
            double yLine = yMm + i * lineHeightMm;
            // Add font-weight='bold' to tspans as well
            sb.AppendLine($@"    <tspan x='{xMm}mm' y='{yLine}mm' font-weight='bold'>{lines[i]}</tspan>");
        }

        sb.AppendLine("</text>");
    }

    private static void AddDescriptionText(StringBuilder sb, string text, double firstLineX, double firstLineY, double restLinesX, double restLinesY, double maxWidthMm = 150)
    {
        if (string.IsNullOrWhiteSpace(text))
            return;

        string escaped = System.Security.SecurityElement.Escape(text);

        // Adjust these values based on your actual font size and page width
        // For A4 page: usable width is about 190mm (210mm - margins)
        double approxCharWidthMm = 1.8; // Reduced from 2.2 for better fit
        int maxCharsPerLine = (int)(maxWidthMm / approxCharWidthMm);

        // Split text into lines with better word wrapping
        var lines = new List<string>();
        string remaining = escaped;

        while (remaining.Length > 0)
        {
            if (remaining.Length <= maxCharsPerLine)
            {
                lines.Add(remaining);
                break;
            }

            // Find a good break point (space or punctuation)
            int breakIndex = maxCharsPerLine;

            // Look for space within the last 15 characters
            int searchStart = Math.Max(0, maxCharsPerLine - 15);
            int lastSpace = remaining.LastIndexOf(' ', maxCharsPerLine);
            int lastPunctuation = Math.Max(
                remaining.LastIndexOf(',', maxCharsPerLine),
                remaining.LastIndexOf(';', maxCharsPerLine)
            );

            int breakPoint = Math.Max(lastSpace, lastPunctuation);

            if (breakPoint > searchStart)
            {
                breakIndex = breakPoint;
            }
            else
            {
                // Force break at maxCharsPerLine if no good break point found
                breakIndex = maxCharsPerLine;
            }

            lines.Add(remaining.Substring(0, breakIndex).Trim());
            remaining = remaining.Substring(breakIndex).TrimStart();
        }

        if (lines.Count == 0)
            return;

        double lineHeightMm = 5.5; // Slightly reduced for better spacing

        // First line at special position
        sb.AppendLine($@"<text x='{firstLineX}mm' y='{firstLineY}mm' font-size='4.5mm' font-weight='bold'>");
        sb.AppendLine($@"    <tspan x='{firstLineX}mm' y='{firstLineY}mm' font-weight='bold'>{lines[0]}</tspan>");
        sb.AppendLine("</text>");

        // Subsequent lines with indent
        for (int i = 1; i < lines.Count; i++)
        {
            double yLine = restLinesY + (i - 1) * lineHeightMm;
            sb.AppendLine($@"<text x='{restLinesX}mm' y='{yLine}mm' font-size='4.5mm' font-weight='bold'>");
            sb.AppendLine($@"    <tspan x='{restLinesX}mm' y='{yLine}mm' font-weight='bold'>{lines[i]}</tspan>");
            sb.AppendLine("</text>");
        }
    }
}