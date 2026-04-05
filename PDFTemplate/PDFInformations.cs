using CodeSourceLayer_;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace PDFTemplate
{
    public class PDFInformations
    {
        public static Document Generate(
            string nom,
            string prenom)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A6);
                    page.Margin(15);
                    page.PageColor(Colors.Grey.Lighten2);

                    page.Content().Column(col =>
                    {
                        col.Spacing(10);

                        // Main card
                        col.Item().Background(Colors.White)
                            .CornerRadius(12)
                            .Padding(20)
                            .Column(card =>
                            {
                                card.Spacing(12);

                                // Logo / Title section
                                card.Item().AlignCenter().Text(Global.centre.CentreNom)
                                    .FontSize(28)
                                    .Bold()
                                    .FontColor("#0B2B4F");

                                card.Item().AlignCenter().Text(Global.centre.Description_Centre)
                                    .FontSize(10)
                                    .Bold()
                                    .FontColor("#0B2B4F");

                                // Separator line
                                card.Item().PaddingTop(5).LineHorizontal(0.5f);

                                // Contact section
                                card.Item().PaddingTop(5).Column(c =>
                                {
                                    c.Item().Text("CONTACTS")
                                        .FontSize(11)
                                        .Bold()
                                        .FontColor("#0B2B4F");

                                    c.Item().PaddingTop(3).Row(r =>
                                    {
                                        r.RelativeItem().Text($"Tél: {Global.centre.Mobile}")
                                            .FontSize(10)
                                            .FontColor(Colors.Grey.Darken2);
                                    });
                                    c.Item().PaddingTop(2).Row(r =>
                                    {
                                        r.RelativeItem().Text($"Fax: {Global.centre.FAX}")
                                            .FontSize(10)
                                            .FontColor(Colors.Grey.Darken2);
                                    });
                                });

                                // Name boxes (white with light grey border, matching the image style)
                                card.Item().PaddingTop(12).Column(nameCol =>
                                {
                                    nameCol.Spacing(12);

                                    // Last name box
                                    nameCol.Item().Border(1).BorderColor(Colors.Grey.Lighten1)
                                        .Background(Colors.White)
                                        .PaddingVertical(10)
                                        .PaddingHorizontal(8)
                                        .AlignCenter()
                                        .Text(nom?.ToUpper() ?? "NOM")
                                        .FontSize(22)
                                        .Bold()
                                        .FontColor("#1A3A5C");

                                    // First name box
                                    nameCol.Item().Border(1).BorderColor(Colors.Grey.Lighten1)
                                        .Background(Colors.White)
                                        .PaddingVertical(10)
                                        .PaddingHorizontal(8)
                                        .AlignCenter()
                                        .Text(prenom?.ToUpper() ?? "PRÉNOM")
                                        .FontSize(22)
                                        .Bold()
                                        .FontColor("#1A3A5C");
                                });
                            });
                    });
                });
            });
        }
    }
}