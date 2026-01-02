using CodeSource;
using CodeSourceLayer;
using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace PDFTemplates
{
    public class PDFDevis
    {
        public static string Num_Devis;
        public static string PatientNom;
        public static string PatientPrenom;
        public static string DateNaiPatient;
        public static string AssureNom;
        public static string AssurePrenom;
        public static string AssureDateNai;
        public static string NumAss;
        public static string Caisse;
        public static string CentrePay;
        public static string Adresse;
        public static string Wilaya;
        public static string Commune;
        public static string Reference;
        public static string Designation;
        public static string Qte;
        public static string Puht;
        public static string Montant_TVA;
        public static string Montant_HT;
        public static string Tva;
        public static string Montant_TTC;
        public static string Date_Devis;

        public static Document GenerateDocument(string Num_devis,string patientNom, string patientPrenom, string DatenaiPatient, string assureNom, string assurePrenom, string assureDateNai, string numAss, string caisse, string centrePay, string adresse,
                                                string wilaya, string commune, string reference, string designation, string qte, string puht, string Montant_tva,string Montant_ht, string tva, string Montant_ttc,string datedevis)
        {
            Num_Devis = Num_devis;
            PatientNom = patientNom;
            PatientPrenom = patientPrenom;
            DateNaiPatient = DatenaiPatient;
            AssureNom = assureNom;
            AssurePrenom = assurePrenom;
            AssureDateNai = assureDateNai;
            NumAss = numAss;
            Caisse = caisse;
            CentrePay = centrePay;
            Adresse = adresse;
            Wilaya = wilaya;
            Commune = commune;
            Reference = reference;
            Designation = designation;
            Qte = qte;
            Puht = puht;
            Montant_TVA = Montant_tva;
            Montant_TTC = Montant_ttc;
            Tva = tva;
            Date_Devis = datedevis;
            Montant_HT = Montant_ht;


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
            byte[] image = File.ReadAllBytes(Global.centre.PathImage);

            container.Row(row =>
            {
                row.RelativeColumn(3).Column(col =>
                {
                    col.Item().PaddingTop(10).AlignRight().Width(120).Image(image);
                    col.Item().Text("EURL HANDICAPIA").Bold().FontSize(16).FontColor(Colors.Blue.Darken2);
                    col.Item().Text("Centre D'appareillage Orthopédique").Bold();
                    col.Item().Text("TEL / FAX : 036.62.65.60");
                    col.Item().Text("Mobile : 0776.89.17.66 / 0770.05.60.80");
                    col.Item().Text("ADRESSE : RUE MAQUAM ELCAHAID SAMO SETIF");
                });

                row.RelativeColumn(1).AlignRight().Column(col =>
                {
                    col.Item().Text($"DATE : {DateTime.Now:dd/MM/yyyy}").Bold();
                });
            });

            container.PaddingTop(15).Row(row =>
            {
                row.ConstantColumn(200)
                    .Background(Colors.Blue.Darken2)
                    .Padding(8)
                    .Text("DEVIS N° : " + Num_Devis )
                    .FontColor(Colors.White)
                    .Bold()
                    .FontSize(12);
            });
        }
        private static void ComposePatient(IContainer container)
        {
            container.Column(col =>
            {
                col.Item().Text("Patient & Assuré").Bold().FontSize(12);
                col.Item().Text($"Nom : {PatientNom}");
                col.Item().Text($"Prénom : {PatientPrenom}");
                col.Item().Text($"Date né le : {DateNaiPatient}");
                col.Item().Text($"Adresse : {Adresse}");
                col.Item().Text($"Commune : {Commune}");
                col.Item().Text($"Wilaya : {Wilaya}");
            });
        }
        private static void ComposeAssure(IContainer container)
        {
            container.Column(col =>
            {
                col.Item().Text("Assuré").Bold().FontSize(12);
                col.Item().Text($"Nom : {AssureNom}");
                col.Item().Text($"Prénom : {AssurePrenom}");
                col.Item().Text($"Date né le : {AssureDateNai}");
                col.Item().Text($"N° ass SN : {NumAss}");
                col.Item().Text($"Caisse : {Caisse}");
                col.Item().Text($"Centre payeur : {CentrePay}");
            });
        }
        private static void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(4);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Text("Description").Bold();
                    header.Cell().AlignCenter().Text("QTE").Bold();
                    header.Cell().AlignCenter().Text("PU HT").Bold();
                    header.Cell().AlignCenter().Text("Montant HT").Bold();
                });

                table.Cell().Text(Designation).Bold();
                table.Cell().AlignCenter().Text(Qte);
                table.Cell().AlignCenter().Text(Puht);
                table.Cell().AlignCenter().Text(Montant_HT);
            });
        }
        private static void ComposeFooter(IContainer container)
        {
            container.PaddingTop(20).Column(col =>
            {
                col.Item().Text("Signature & Cachet").Bold();
                col.Item().Height(80);
            });
        }


        private static void ComposeContent(IContainer container)
        {
            container.PaddingTop(15).Column(column =>
            {
                column.Item().Row(row =>
                {
                    row.RelativeColumn().Element(ComposePatient);
                    row.RelativeColumn().Element(ComposeAssure);
                });

                column.Item().PaddingVertical(15).LineHorizontal(1);

                column.Item().Text("Description").Bold().FontSize(12);

                column.Item().PaddingTop(10).Element(ComposeTable);

                column.Item().AlignRight().PaddingTop(10).Column(col =>
                {
                    col.Item().Text($"TVA {Tva}% : {Montant_TVA} DZD").Bold();
                    col.Item()
                        .Background(Colors.Grey.Lighten3)
                        .Padding(10)
                        .Text($"TOTAL TTC : {Montant_TTC} DZD")
                        .Bold()
                        .FontSize(14)
                        .FontColor(Colors.Blue.Darken2);
                });
            });
        }
    }
}
