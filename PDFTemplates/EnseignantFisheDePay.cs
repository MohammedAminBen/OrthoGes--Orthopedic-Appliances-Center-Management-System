using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PDFTemplates
{
    public class EnseignantFisheDePay
    {
        public static Document GenerateDocument()
        {
            _enseignantid = ens;
            _filters = filters;
            enseignant = Enseignant.FindByEnseignantID(ens);
            person = Person.Find(enseignant.PersonID);
            return Document.Create(container =>
            {
                    container.Page(page =>
                    {
                        page.PageColor(Colors.White);
                        page.MarginTop(35);
                        page.MarginLeft(20);
                        page.MarginRight(20);
                        page.MarginBottom(25);
                        page.DefaultTextStyle(x => x.FontColor(Colors.Grey.Darken3).FontSize(10));
                        page.Header().ShowOnce().Element(ComposeHeader);
                        page.Content().Element(ComposeContent);
                        page.Footer().Element(ComposeFooter);
                    });
                
            });
        }

        private static void ComposeHeader(IContainer container)
        {
            byte[] image = File.ReadAllBytes(Globale.ecole.ImagePath);
            container.Column(column =>
            {
                column.Item().Row(Row =>
                {
                    Row.RelativeItem(2).Column(column => 
                    {
                        column.Item().Text(Globale.ecole.NomEcole).FontSize(25).Bold();
                        column.Item().Padding(3).Row(Row =>
                        {
                            Row.RelativeItem().Column(column =>
                            {
                                column.Item().Text("Contact : "+Globale.ecole.Contact);
                                column.Item().Text("Adresse : "+Globale.ecole.Address);
                            });
                        });
                    });
                    Row.RelativeItem().PaddingTop(10).AlignRight().Width(120).Image(image);
                });
               
                        column.Item().PaddingTop(5).Text("Fiche de paie pour : ").Bold().FontSize(13);
                        column.Item().PaddingTop(5).Text("Enseignant : " + person.NomEtPrenom).SemiBold();
                        column.Item().PaddingTop(5).Text("Identifiant : " + enseignant.EnseignantID).SemiBold();
                        

                    
                
            });
        }

        private static void ComposeContent(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().PaddingTop(20).Column(column =>
                {
                    column.Item().AlignCenter().Text("Détail du salaire").SemiBold().FontSize(13) ;
                    column.Item().PaddingTop(8).AlignRight().Table(table =>
                    {
                        table.ColumnsDefinition(def =>
                        {
                            def.ConstantColumn(100);   // Groupe
                            def.ConstantColumn(60);   // Montant
                            def.ConstantColumn(100);   // Nombre de séances
                            def.ConstantColumn(90);   // Nombre d’élèves
                            def.ConstantColumn(115);   // Période
                            def.ConstantColumn(90);  // Montant Totale
                        });


                        static IContainer HeaderCellStyle(IContainer container) =>
                            container.Background(Colors.Grey.Darken3)
                                     .Padding(6).AlignCenter()
                                     .DefaultTextStyle(x => x.FontColor(Colors.White).SemiBold().FontSize(10));
                        table.Header(header =>
                        {
                            header.Cell().Element(HeaderCellStyle).Text("Groupe");
                            header.Cell().Element(HeaderCellStyle).AlignRight(). Text("Montant");
                            header.Cell().Element(HeaderCellStyle).AlignRight().Text("Nombre de seances");
                            header.Cell().Element(HeaderCellStyle).AlignRight().Text("Nombre d'élèves");
                            header.Cell().Element(HeaderCellStyle).AlignRight().Text("Période");
                            header.Cell().Element(HeaderCellStyle).AlignRight().Text("Montant Totale");
                        });

                        static IContainer ItemCellStyle(IContainer container) =>
                             container
                             .BorderBottom(1)                    // line between rows
                                .BorderColor(Colors.Grey.Lighten2)
                                .PaddingVertical(5)
                                .PaddingHorizontal(3)
                                .DefaultTextStyle(x => x.FontSize(10).FontColor(Colors.Black));

                        int rowIndex = 0;
                        DataTable dt = Financement.GetEnseignantFicheDePaieData(_enseignantid,_filters);

                        string lastGroupe = null;

                        foreach (DataRow row in dt.Rows)
                        {
                            bool isEven = rowIndex % 2 == 0;

                            static IContainer ItemCellStyleAlt(IContainer container, bool isEven) =>
                                container
                                    .Background(isEven ? Colors.White : Colors.Grey.Lighten4)
                                    .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .PaddingVertical(5).PaddingHorizontal(3)
                                    .AlignCenter()
                                    .DefaultTextStyle(x => x.FontSize(10).FontColor(Colors.Black));

                            string currentGroupe = row["GroupeID"].ToString();

                            // Only print the group ID the first time it appears
                            if (currentGroupe != lastGroupe)
                                table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignMiddle().Text(currentGroupe);
                            else
                                table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignMiddle().Text("");

                            // The rest of the row cells
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignRight().Text(row["Montant"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["NombreSeance"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignCenter().Text(row["NombreEleve"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).Text(row["Periode"].ToString());
                            table.Cell().Element(c => ItemCellStyleAlt(c, isEven)).AlignRight().Text(row["SommeHistorique"].ToString() + " DA").SemiBold();

                            lastGroupe = currentGroupe;
                            rowIndex++;
                        }


                        decimal totalSalaire = dt.AsEnumerable()
                            .Sum(r => Convert.ToDecimal(r["SommeHistorique"]));

                        table.Cell().ColumnSpan(4).Border(0);

                        table.Cell().Element(ItemCellStyle)
                            .AlignCenter()
                            .Text("Salaire Totale :  ")
                            .FontSize(16)
                            .SemiBold();

                        table.Cell().Element(ItemCellStyle).AlignCenter()
                            .Text(totalSalaire.ToString("N0")+" DA").FontSize(16)  
                            .Bold();
                        column.Item().PaddingRight(10).PaddingTop(10).Text("Émis le " + DateTime.Now.ToString("dd/MM/yyyy")).SemiBold().FontSize(11);


                    });
                });
            });
        }

        private static void ComposeFooter(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().PaddingTop(20).Column(column =>
                {
                    column.Item().Text("SysSco").FontSize(12).AlignCenter();
                });
            });
        }


    }
}
