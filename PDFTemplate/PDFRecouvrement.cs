using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
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

        public static QuestPDF.Fluent.Document GenerateDocument(DataTable dt, string title)
        {
            RecouvTable = dt;
            Title = title;
            return QuestPDF.Fluent.Document.Create(Container =>
            Container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(0);
                page.Content().Element(ComposeContent);
            }));

        }
        private static void ComposeContent(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().PaddingTop(20).Column(column =>
                {
                    column.Item().AlignCenter().Text(Title).SemiBold().FontSize(13);
                    column.Item().PaddingTop(8).AlignCenter().Table(table =>
                    {
                        table.ColumnsDefinition(def =>
                        {
                            def.ConstantColumn(100);//id
                            def.ConstantColumn(200);//nompatient
                            def.ConstantColumn(200);//nomassure
                            def.ConstantColumn(150);//numeroASS
                            def.ConstantColumn(100);//assurance
                            def.ConstantColumn(100);//numfacture
                            def.ConstantColumn(120);//datefacture
                            def.ConstantColumn(120);//produit
                            def.ConstantColumn(20);//quantity
                            def.ConstantColumn(150);//Montant HT
                            def.ConstantColumn(30);//tva
                            def.ConstantColumn(150);//MontantTTC
                            def.ConstantColumn(50);//payé
                            
                            

                        });


                        static IContainer HeaderCellStyle(IContainer container) =>
                            container.Background(Colors.Grey.Darken3)
                                     .Padding(6).AlignCenter()
                                     .DefaultTextStyle(x => x.FontColor(Colors.White).SemiBold().FontSize(10));
                        table.Header(header =>
                        {
                            header.Cell().Element(HeaderCellStyle).Text("N° Patient");
                            header.Cell().Element(HeaderCellStyle).Text("Patient");
                            header.Cell().Element(HeaderCellStyle).Text("Assure");
                            header.Cell().Element(HeaderCellStyle).Text("N° Assurance");
                            header.Cell().Element(HeaderCellStyle).Text("Assurance");
                            header.Cell().Element(HeaderCellStyle).Text("N° facture");
                            header.Cell().Element(HeaderCellStyle).Text("date facture");
                            header.Cell().Element(HeaderCellStyle).Text("Produit");
                            header.Cell().Element(HeaderCellStyle).Text("Qnt");
                            header.Cell().Element(HeaderCellStyle).Text("Montant HT");
                            header.Cell().Element(HeaderCellStyle).Text("TVA");
                            header.Cell().Element(HeaderCellStyle).Text("Montant TTC");
                            header.Cell().Element(HeaderCellStyle).Text("Payé");

                        });

                        static IContainer ItemCellStyle(IContainer container) =>
                             container
                             .BorderBottom(1)                    // line between rows
                                .BorderColor(Colors.Grey.Lighten2)
                                .PaddingVertical(5)
                                .PaddingHorizontal(3)
                                .DefaultTextStyle(x => x.FontSize(10).FontColor(Colors.Black));

                        int rowIndex = 0;
                        foreach (DataRow row in RecouvTable.Rows)
                        {
                            bool isEven = rowIndex % 2 == 0;

                            static IContainer ItemCellStyleAlt(IContainer container, bool isEven) =>
                                container
                                    .Background(isEven ? Colors.White : Colors.Grey.Lighten4)
                                    .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .PaddingVertical(5).PaddingHorizontal(3)
                                    .AlignCenter()
                                    .DefaultTextStyle(x => x.FontSize(10).FontColor(Colors.Black));

                            // The rest of the row cells
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignRight().Text(row["Numero_Patient"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["Patient"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["Assure"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["Numero_Assurance"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["Nom_Caisse"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["Numero_Facture"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["Date_Facture"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["Produits"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["Quantites"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["Prix"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["TVA"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["Montant_TTC"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["etat_Payement"].ToString());
                            string dateText = "";

                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven))
                                .AlignCenter()
                                .Text(dateText);
                            rowIndex++;
                        }
                        column.Item().PaddingRight(10).PaddingTop(10).Text("Émis le " + DateTime.Now.ToString("dd/MM/yyyy")).SemiBold().FontSize(11);


                    });
                });
            });
        }
    }
}
