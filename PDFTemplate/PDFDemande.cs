using Azure.Core;
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

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public static Document GenerateDocument(string nom, string prenoms, string dateNaissance, string description, string dateActe, string immatriculation, string nomPrenomBenef = "", string dateNaissanceBenef = "")
    {
        Nom = nom;
        Prenoms = prenoms;
        DateNaissance = dateNaissance;
        NomPrenomBenef = nomPrenomBenef;
        DateNaissanceBenef = dateNaissanceBenef;
        Description = description;
        DateActe = dateActe;
        Immatriculation = immatriculation;
        //    return Document.Create(container =>
        //container.Page(page =>
        //{
        //    page.Size(PageSizes.A4);
        //    page.Margin(0);
        //    page.Content().Svg(GenerateSvg());
        //    page.Content().Layers(layers =>
        //    {

        //        layers.PrimaryLayer().Image(GetEmbeddedResource("form.png")).FitArea();


        //        layers.Layer().Svg(GenerateSvg());
        //    });
        //}));

        return Document.Create(container =>
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(0);

            page.Content().Layers(layers =>
            {
                // Background PNG image
                layers.PrimaryLayer()
                    .Image(GetEmbeddedResource("form.png"))
                    .FitArea();

                // Text overlay via SVG
                layers.Layer().Svg(GenerateSvg());
            });
        }));
    }

    //public void Compose(IDocumentContainer container)
    //{
    //    container.Page(page =>
    //        {
    //            page.Size(PageSizes.A4);
    //            page.Margin(0);
    //            page.Content().Svg(GenerateSvg());
    //        });
    //}


    private static byte[] GetEmbeddedResource(string fileName)
    {
        var assembly = typeof(PDFDemande).Assembly;

        var resourceName = assembly.GetManifestResourceNames()
            .FirstOrDefault(n => n.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));

        if (resourceName == null)
            throw new Exception("Embedded image not found: " + fileName
                + "\nAvailable resources:\n"
                + string.Join("\n", assembly.GetManifestResourceNames()));

        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        return ms.ToArray();
    }


    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(0);

                page.Content().Layers(layers =>
                {

                    layers.PrimaryLayer().Image(GetEmbeddedResource("form.png")).FitArea();


                    layers.Layer().Svg(GenerateSvg());
                });
            });
    }

    private static string GenerateSvg()
    {
        var sb = new StringBuilder();

        sb.AppendLine(@"<?xml version='1.0' encoding='UTF-8'?>");
        // A4 = 21cm x 29.7cm — viewBox locks the coordinate space
        sb.AppendLine(@"<svg width='21cm' height='29.7cm' viewBox='0 0 21 29.7' xmlns='http://www.w3.org/2000/svg'>");
        sb.AppendLine(@"<style>");
        sb.AppendLine(@"    text { font-family: Arial, sans-serif; fill: black; font-weight: bold; }");
        sb.AppendLine(@"</style>");

        AddText(sb, Immatriculation ?? "", 15, 11.7, "0.45");
        AddText(sb, Nom ?? "", 2.8, 11.6, "0.45");
        AddText(sb, Prenoms ?? "", 3.4, 12.1, "0.45");
        AddText(sb, DateNaissance ?? "", 4.9, 12.7, "0.45");
        AddText(sb, NomPrenomBenef ?? "", 4.5, 14.6, "0.45");
        AddText(sb, DateNaissanceBenef ?? "", 16.4, 14.5, "0.45");
        AddText(sb, Description ?? "", 2, 19.5, "0.45");
        AddText(sb, DateActe ?? "", 4.3, 20.7, "0.45");

        sb.AppendLine("</svg>");
        return sb.ToString();
    }

    private static void AddText(StringBuilder sb, string text, double leftCm, double topCm, string fontSize)
    {
        if (string.IsNullOrEmpty(text)) return;

        string escapedText = System.Security.SecurityElement.Escape(text);
        // No units on x/y — they use viewBox cm units directly
        sb.AppendLine($"    <text x='{leftCm}' y='{topCm}' font-size='{fontSize}' font-weight='bold'>{escapedText}</text>");
    }
}

