using System;
using System.Data;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using IContainer = QuestPDF.Infrastructure.IContainer;

namespace PDFTemplate
{
    public class PDFRecouvrement
    {
        public static DataTable RecouvTable;
        public static string Title;

        public static Document GenerateDocument(DataTable dt, string title)
        {
            RecouvTable = dt;
            Title = title;

            return Document.Create(container =>
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(8);
                    page.Content().Element(ComposeContent);
                }));
        }

        private static void ComposeContent(IContainer container)
        {
            container.Column(column =>
            {
                // Title
                column.Item().PaddingTop(5).PaddingBottom(4).AlignCenter()
                    .Text(Title)
                    .SemiBold()
                    .FontSize(14);

                // Record count
                column.Item().PaddingBottom(8).AlignCenter()
                    .Text($"{RecouvTable.Rows.Count} enregistrement(s)")
                    .FontSize(9)
                    .FontColor(Colors.Grey.Darken1);

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(def =>
                    {
                        def.ConstantColumn(60);
                        def.RelativeColumn(1.8f);
                        def.RelativeColumn(1.8f);
                        def.RelativeColumn(1.3f);
                        def.RelativeColumn(1.2f);
                        def.ConstantColumn(70);
                        def.ConstantColumn(60);
                        def.RelativeColumn(1.8f);
                        def.ConstantColumn(28);
                        def.ConstantColumn(50);
                        def.ConstantColumn(30);
                        def.ConstantColumn(55);
                        def.ConstantColumn(40);
                    });

                    // Header style - white background with bold text and borders
                    static IContainer HeaderStyle(IContainer container) =>
                        container
                            .Border(1)
                            .BorderColor(Colors.Black)
                            .Background(Colors.White)
                            .PaddingVertical(5)
                            .PaddingHorizontal(4)
                            .AlignCenter()
                            .AlignMiddle()
                            .DefaultTextStyle(x => x
                                .FontColor(Colors.Black)
                                .Bold()
                                .FontSize(9));

                    // Cell style with all borders
                    static IContainer CellStyle(IContainer container) =>
                        container
                            .Border(1)
                            .BorderColor(Colors.Black)
                            .Background(Colors.White)
                            .PaddingVertical(4)
                            .PaddingHorizontal(3)
                            .AlignMiddle()
                            .DefaultTextStyle(x => x.FontSize(8));

                    // Header row
                    table.Header(header =>
                    {
                        header.Cell().Element(HeaderStyle).Text("N° Pat");
                        header.Cell().Element(HeaderStyle).Text("Patient");
                        header.Cell().Element(HeaderStyle).Text("Assuré");
                        header.Cell().Element(HeaderStyle).Text("N° Ass");
                        header.Cell().Element(HeaderStyle).Text("Assurance");
                        header.Cell().Element(HeaderStyle).Text("N° Fact");
                        header.Cell().Element(HeaderStyle).Text("Date");
                        header.Cell().Element(HeaderStyle).Text("Produit");
                        header.Cell().Element(HeaderStyle).Text("Qte");
                        header.Cell().Element(HeaderStyle).Text("HT");
                        header.Cell().Element(HeaderStyle).Text("TVA");
                        header.Cell().Element(HeaderStyle).Text("TTC");
                        header.Cell().Element(HeaderStyle).Text("Payé");
                    });

                    foreach (DataRow row in RecouvTable.Rows)
                    {
                        string dateText = "";
                        if (DateTime.TryParse(row["Date_Facture"].ToString(), out DateTime date))
                            dateText = date.ToString("dd/MM/yy");

                        // N° Patient
                        table.Cell().Element(CellStyle)
                            .AlignCenter()
                            .Text(row["Numero_Patient"].ToString())
                            .FontSize(8);

                        // Patient
                        table.Cell().Element(CellStyle)
                            .Text(row["Patient"].ToString())
                            .FontSize(8);

                        // Assuré
                        table.Cell().Element(CellStyle)
                            .Text(row["Assure"].ToString())
                            .FontSize(8);

                        // N° Assurance
                        table.Cell().Element(CellStyle)
                            .AlignCenter()
                            .Text(row["Numero_Assurance"].ToString())
                            .FontSize(8);

                        // Assurance
                        table.Cell().Element(CellStyle).AlignCenter()
                            .Text(row["Nom_Caisse"].ToString())
                            .FontSize(8);

                        // N° Facture
                        table.Cell().Element(CellStyle)
                            .AlignCenter()
                            .Text(row["Numero_Facture"].ToString())
                            .FontSize(8);

                        // Date
                        table.Cell().Element(CellStyle)
                            .AlignCenter()
                            .Text(dateText)
                            .FontSize(8);

                        // Produit
                        table.Cell().Element(CellStyle)
                            .Text(row["Produits"].ToString())
                            .FontSize(8);

                        // Quantité
                        table.Cell().Element(CellStyle)
                            .AlignCenter()
                            .Text(row["Quantites"].ToString())
                            .FontSize(8);

                        // HT
                        table.Cell().Element(CellStyle)
                            .AlignRight()
                            .Text(FormatCurrency(row["Prix"]))
                            .FontSize(8);

                        // TVA
                        table.Cell().Element(CellStyle)
                            .AlignCenter()
                            .Text(FormatCurrency(row["TVA"]))
                            .FontSize(8);

                        // TTC
                        table.Cell().Element(CellStyle)
                            .AlignRight()
                            .Text(FormatCurrency(row["Montant_TTC"]))
                            .FontSize(8);

                        // Payé
                        table.Cell().Element(CellStyle)
                            .AlignCenter()
                            .Text(FormatPaymentStatus(row["etat_Payement"].ToString()))
                            .FontSize(8);
                    }
                });

                // Footer with summary and date
                column.Item().PaddingTop(8).Row(row =>
                {
                    row.RelativeItem().AlignLeft()
                        .Text(GenerateSummary())
                        .FontSize(9);

                    row.RelativeItem().AlignRight()
                        .Text($"Émis le {DateTime.Now:dd/MM/yyyy}")
                        .SemiBold()
                        .FontSize(9);
                });
            });
        }

        // Helper method to format currency
        private static string FormatCurrency(object value)
        {
            if (value == null || value == DBNull.Value)
                return "0,00";

            if (decimal.TryParse(value.ToString(), out decimal amount))
                return amount.ToString("N2");

            return value.ToString();
        }

        // Helper method to format payment status
        private static string FormatPaymentStatus(string status)
        {
            return status?.ToLower() switch
            {
                "payé" or "paid" or "oui" => "Payé",
                "non" or "impayé" or "unpaid" => "Impayé",
                _ => status ?? ""
            };
        }

        // Generate summary with totals
        private static string GenerateSummary()
        {
            decimal totalHT = 0;
            decimal totalTTC = 0;
            int paidCount = 0;
            int unpaidCount = 0;

            foreach (DataRow row in RecouvTable.Rows)
            {
                if (decimal.TryParse(row["Prix"]?.ToString(), out decimal ht))
                    totalHT += ht;

                if (decimal.TryParse(row["Montant_TTC"]?.ToString(), out decimal ttc))
                    totalTTC += ttc;

                string status = row["etat_Payement"]?.ToString() ?? "";
                if (status?.ToLower() == "payé" || status?.ToLower() == "paid" || status?.ToLower() == "oui")
                    paidCount++;
                else
                    unpaidCount++;
            }

            return $"Total: {RecouvTable.Rows.Count} lignes | Payé: {paidCount} | Impayé: {unpaidCount} | HT: {totalHT:N2} | TTC: {totalTTC:N2}";
        }
    }
}