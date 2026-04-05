using CodeSourceLayer_;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;
namespace PDFTemplate
{
    public class PDFFicheEnseignement
    {
        private static readonly string BrandColor = "#1F3A63";

        public static Document Generate(
            string dossier,
            string nom,
            string prenom,
            string dateNaissance,
            string telephone,
            string wilaya,
            string commune,
            string dateDevis)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.PageColor(Colors.White);

                    page.DefaultTextStyle(x =>
                        x.FontFamily(Fonts.SegoeUI)
                         .FontSize(15)
                         .FontColor(Colors.Black));

                    page.Content().Column(col =>
                    {
                        col.Spacing(10);

                        // ===== HEADER =====
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Text(Global.centre.CentreNom)
                                .FontSize(25)
                                .Bold().FontColor(BrandColor);

                            row.RelativeItem().AlignRight().Column(c =>
                            {
                                c.Item().Text("DOCUMENT DE DOSSIER PATIENT")
                                    .Bold();
                                c.Item().Text($"ID: {dossier}").Bold();
                            });
                        });

                        col.Item().LineHorizontal(1);

                        // ===== TITLE =====
                        col.Item().AlignCenter().Text(Global.centre.Description_Centre)
                            .FontSize(18)
                            .Bold();

                        // ===== PATIENT DETAILS =====
                        col.Item().PaddingTop(20).PaddingBottom(10).Text("--- DÉTAILS PATIENT ---")
                            .FontColor(BrandColor)
                            .Bold();

                        void RowItem(string label, string value)
                        {
                            col.Item().Row(r =>
                            {
                                r.ConstantItem(180).Text(label).Bold();
                                r.RelativeItem().Text(value).SemiBold();
                            });
                        }

                        RowItem("N° DOSSIER:", dossier);
                        RowItem("NOM:", nom.ToUpper());
                        RowItem("PRÉNOM:", prenom.ToUpper());
                        RowItem("DATE DE NAISSANCE:", dateNaissance);

                        // ===== CONTACT =====
                        col.Item().PaddingTop(15).PaddingBottom(10).Text("--- COORDONNÉES & LOCALISATION ---")
                            .FontColor(BrandColor)
                            .Bold();

                        RowItem("TÉLÉPHONE:", telephone);
                        RowItem("WILAYA:", wilaya.ToUpper());
                        RowItem("COMMUNE:", commune.ToUpper());
                        RowItem("DATE D'INSCRIPTION:",dateDevis);

                        // ===== DIAGNOSTIC =====

                        // ===== FOOTER =====
                        col.Item().PaddingTop(40).AlignCenter().Text($"© {DateTime.Now.Year} EURL HANDICAPIA")
                            .FontSize(10)
                            .FontColor(Colors.Grey.Darken1);
                    });
                });
            });
        }
    }
}
