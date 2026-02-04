using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF;
using QuestPDF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSourceLayer_;

namespace PDFTemplate
{
    public class PDFBon_Livraison
    {
        private static readonly string BrandBlue = "#1F3A63";

        // ===== DATA =====
        public static string Num_Bon, Date_Facture;
        public static string PatientNom, PatientPrenom, DateNaiPatient;
        public static string AssureNom, AssurePrenom, AssureDateNai, NumAss;
        public static string Adresse, Commune, Wilaya;
        public static string Caisse, CentrePay;
        public static List<(string Reference, string designation, string PUHT, string Quantity, string Montant_HT, string MontantTVA, string TVA)> Produits = new();
        public static string Montant_TTC;
        public static string Piece_Produit;

        // ===== GENERATOR =====
        public static Document GenerateDocument(string Num_bon, string patientNom, string patientPrenom, string DatenaiPatient, string assureNom, string assurePrenom, string assureDateNai, string numAss, string caisse, string centrePay, string adresse,
                                                       string wilaya, string commune, List<(string Reference, string designation, string PUHT, string Quantity, string Montant_HT, string MontantTVA, string TVA)> produits, string Montant_ttc, string datefacture,string piece)
        {
            Num_Bon = Num_bon;
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
            Montant_TTC = Montant_ttc;
            Date_Facture = datefacture;
            Produits = produits;
            Piece_Produit = piece;
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(28);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x =>
                        x.FontFamily(Fonts.Arial)
                         .FontSize(10)
                         .FontColor(Colors.Black));

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().Element(ComposeFooter);
                });
            });
        }

        // ===== HEADER =====
        private static void ComposeHeader(IContainer container)
        {
            //byte[] image = File.ReadAllBytes(Global.centre.PathImage);

            container.Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text(Global.centre.CentreNom)
                            .FontSize(24)
                            .ExtraBold()
                            .FontColor(BrandBlue);

                        c.Item().PaddingTop(1)
                            .Text(Global.centre.Description_Centre)
                            .SemiBold()
                            .FontSize(11);
                        c.Item().PaddingTop(3).Text($"ADRESSE : {Global.centre.Adresse}").FontSize(12).FontFamily(Fonts.SegoeUI);
                        c.Item().PaddingTop(2).Text($"Mobile : {Global.centre.Mobile}").FontSize(12).FontFamily(Fonts.SegoeUI);
                        c.Item().PaddingTop(2).Text($"RC N° : {Global.centre.NumeroRC}").FontSize(12).FontFamily(Fonts.SegoeUI);
                        c.Item().PaddingTop(2).Text($"NIF : {Global.centre.NIF}").FontSize(12).FontFamily(Fonts.SegoeUI);
                        c.Item().PaddingTop(2).Text($"RIB : {Global.centre.RIB}").FontSize(12).FontFamily(Fonts.SegoeUI);
                        c.Item().PaddingTop(2).Text($"N° ART : {Global.centre.NumeroART}").FontSize(12).FontFamily(Fonts.SegoeUI);

                    });
                    // row.RelativeItem().AlignRight().Width(130).Height(130).Image(image);
                    row.ConstantItem(150)
                        .AlignRight()
                        .Text($"DATE : {Date_Facture}")
                        .Bold().FontFamily(Fonts.SegoeUI);
                });

                col.Item()
                    .PaddingTop(17)
                    .Background(BrandBlue)
                    .Height(36)
                    .AlignMiddle()
                    .PaddingLeft(18)
                    .Text($"BON DE LIVRAISON N° :   {Num_Bon}")
                    .FontColor(Colors.White)
                    .Bold()
                    .FontSize(20).FontFamily(Fonts.SegoeUI);
            });
        }

        // ===== CONTENT =====
        private static void ComposeContent(IContainer container)
        {
            container.PaddingTop(20).Column(col =>
            {
                // -------- PATIENT / ASSURE --------
                col.Item().Row(row =>
                {
                    // Patient
                    row.RelativeItem().Element(ComposePatient);

                    // Vertical separator
                    row.ConstantItem(20)
                        .AlignCenter()
                        .LineVertical(0.7f)
                        .LineColor(Colors.Grey.Lighten2);

                    // Assuré
                    row.RelativeItem().PaddingLeft(20).Element(ComposeAssure);
                });

                col.Item().PaddingVertical(8)
                    .LineHorizontal(0.7f)
                    .LineColor(Colors.Grey.Lighten2);


                // -------- DESCRIPTION --------
                // -------- DESCRIPTION --------
                col.Item().Row(row =>
                {
                    row.RelativeItem(4)
                        .Text("Description")
                        .FontSize(20)
                        .Bold()
                        .FontColor(BrandBlue);

                    row.RelativeItem()
                        .AlignCenter()
                        .PaddingTop(10)
                        .Text("QTE")
                        .FontSize(11)
                        .FontColor(Colors.Grey.Medium);

                    row.RelativeItem()
                        .AlignCenter()
                        .PaddingTop(10)
                        .Text("PU HT")
                        .FontSize(11)
                        .FontColor(Colors.Grey.Medium);

                    row.RelativeItem()
                        .AlignCenter()
                        .PaddingTop(10)
                        .Text("Montant")
                        .FontSize(11)
                        .FontColor(Colors.Grey.Medium);
                });


                col.Item();
                col.Item().PaddingVertical(10)
                    .LineHorizontal(0.7f)
                    .LineColor(Colors.Grey.Lighten2);


                col.Item().PaddingTop(0).Column(mainCol =>
                {
                    // ===== HEADER LINE =====
                    //mainCol.Item().Row(row =>
                    //{
                    //    row.RelativeItem(4); // empty (designation has no header)

                    //    row.RelativeItem()
                    //        .AlignCenter()
                    //        .Text("QTE")
                    //        .FontSize(11)
                    //        .FontColor(Colors.Grey.Medium);

                    //    row.RelativeItem()
                    //        .AlignCenter()
                    //        .Text("PU HT")
                    //        .FontSize(11)
                    //        .FontColor(Colors.Grey.Medium);

                    //    row.RelativeItem()
                    //        .AlignCenter()
                    //        .Text("Montant HT")
                    //        .FontSize(11)
                    //        .FontColor(Colors.Grey.Medium);
                    //});

                    // ===== PRODUCT ROW =====

                    // ===== PRODUCT ROWS =====
                    for (int i = 0; i < Produits.Count; i++)
                    {
                        var produit = Produits[i];

                        // Product row
                        mainCol.Item().Row(row =>
                        {
                            // Designation
                            row.RelativeItem(4).PaddingTop(2).Column(c =>
                            {
                                c.Item()
                                    .Text(produit.Reference + "  " + produit.designation)
                                    .SemiBold()
                                    .FontFamily(Fonts.SegoeUI)
                                    .FontSize(14);
                            });

                            // Quantity
                            row.RelativeItem()
                                .AlignCenter()
                                .PaddingTop(4)
                                .Text($"x{produit.Quantity}")
                                .FontSize(13);

                            // Unit price
                            row.RelativeItem()
                                .AlignCenter()
                                .PaddingTop(4)
                                .Text(produit.PUHT)
                                .FontSize(13);

                            // Amount
                            row.RelativeItem()
                                .AlignCenter()
                                .PaddingTop(4)
                                .Text(produit.Montant_HT)
                                .FontSize(13)
                                .Bold();
                        });

                        // TVA row (immediately under the product)
                        mainCol.Item().PaddingTop(4).Row(row =>
                        {
                            // Empty designation column
                            row.RelativeItem(4);

                            // Empty QTE column
                            row.RelativeItem();

                            // TVA label
                            row.RelativeItem()
                                .AlignCenter()
                                .Text($"TVA {produit.TVA}%")
                                .FontSize(13);

                            // TVA amount
                            row.RelativeItem()
                                .AlignCenter()
                                .Text(produit.MontantTVA)
                                .FontSize(13)
                                .Bold();
                        });

                        // Separator line under the product + TVA block
                        mainCol.Item()
                            .PaddingTop(8)
                            .LineHorizontal(0.6f)
                            .LineColor(Colors.Grey.Lighten2);
                    }




                });


                // -------- TVA --------
                // -------- TVA --------



                // -------- TOTAL --------
                col.Item().PaddingTop(11)
      .Row(row =>
      {
          // LEFT SIDE
          row.RelativeItem()
              .AlignLeft().PaddingTop(25).PaddingLeft(50)
              .Text("Signature et cachet")
              .FontSize(12)
              .Italic()
              .FontFamily(Fonts.SegoeUI);

          // RIGHT SIDE (TOTAL TTC box)
          row.ConstantItem(200)
              .AlignRight()
              .Background(Colors.Grey.Lighten4)
              .PaddingVertical(12)
              .PaddingHorizontal(1)
              .Row(r =>
              {
                  r.RelativeItem()
                      .Text("     TOTAL TTC :")
                      .SemiBold()
                      .FontSize(14)
                      .FontFamily(Fonts.SegoeUI);

                  r.RelativeItem()
                      .AlignRight()
                      .Text($"{Montant_TTC} DZD")
                      .SemiBold()
                      .FontSize(14)
                      .FontColor(BrandBlue)
                      .FontFamily(Fonts.SegoeUI);
              });
      });
                //col.Item().PaddingTop(50).PaddingRight(60).AlignRight()
                //.Text("Signature & Cachet")
                //.Bold()
                //.FontColor(BrandBlue).FontSize(12);
            });
        }

        // ===== PATIENT =====
        private static void ComposePatient(IContainer c)
        {
            c.Column(col =>
            {
                // Title
                col.Item()
                    .Text("Patient")
                    .SemiBold()
                    .FontSize(21)
                    .FontFamily(Fonts.Arial)
                    .FontColor(BrandBlue);

                col.Item().PaddingTop(13);

                // Nom
                col.Item().Row(row =>
                {
                    row.ConstantItem(90).Text("Nom :").FontFamily(Fonts.Arial).FontSize(14).FontColor(Colors.Grey.Darken1);
                    row.RelativeItem().Text(PatientNom).FontFamily(Fonts.SegoeUI).FontSize(14).SemiBold();
                });

                col.Item().PaddingTop(10);

                // Prénom
                col.Item().Row(row =>
                {
                    row.ConstantItem(90).Text("Prénom :").FontFamily(Fonts.Arial).FontSize(14).FontColor(Colors.Grey.Darken1);
                    row.RelativeItem().Text(PatientPrenom).FontFamily(Fonts.SegoeUI).FontSize(14).SemiBold();
                });

                col.Item().PaddingTop(10);

                // Date de naissance
                col.Item().Row(row =>
                {
                    row.ConstantItem(90).Text("Date né le :").FontFamily(Fonts.Arial).FontSize(14).FontColor(Colors.Grey.Darken1);
                    row.RelativeItem().Text(DateNaiPatient).FontFamily(Fonts.SegoeUI).FontSize(14).SemiBold();
                });

                col.Item().PaddingTop(10);

                // Adresse
                col.Item().Row(row =>
                {
                    row.ConstantItem(90).Text("Adresse :").FontFamily(Fonts.Arial).FontSize(14).FontColor(Colors.Grey.Darken1);
                    row.RelativeItem().Text(Adresse).FontFamily(Fonts.SegoeUI).FontSize(14).SemiBold();
                });

                col.Item().PaddingTop(10);

                // Commune
                col.Item().Row(row =>
                {
                    row.ConstantItem(90).Text("Commune :").FontFamily(Fonts.Arial).FontSize(14).FontColor(Colors.Grey.Darken1);
                    row.RelativeItem().Text(Commune).FontFamily(Fonts.SegoeUI).FontSize(14).SemiBold();
                });

                col.Item().PaddingTop(10);

                // Wilaya
                col.Item().Row(row =>
                {
                    row.ConstantItem(90).Text("Wilaya :").FontFamily(Fonts.Arial).FontSize(14).FontColor(Colors.Grey.Darken1);
                    row.RelativeItem().Text(Wilaya).FontFamily(Fonts.SegoeUI).FontSize(14).SemiBold();
                });
                col.Item().PaddingTop(10);

                col.Item().Row(row =>
                {
                    row.RelativeItem().Text("Pièce Produit :").FontFamily(Fonts.Arial).FontSize(14).FontColor(Colors.Grey.Darken1);
                    row.RelativeItem().Text(Piece_Produit).FontFamily(Fonts.SegoeUI).FontSize(14).SemiBold();
                });
            });
        }


        // ===== ASSURE =====
        private static void ComposeAssure(IContainer c)
        {
            c.Column(col =>
            {
                // Title
                col.Item()
                    .Text("Assuré")
                    .SemiBold()
                    .FontSize(21)
                    .FontFamily(Fonts.Arial)
                    .FontColor(BrandBlue);

                col.Item().PaddingTop(13);

                // Nom
                col.Item().Row(row =>
                {
                    row.ConstantItem(90)
                        .Text("Nom :")
                        .FontFamily(Fonts.Arial)
                        .FontSize(14)
                        .FontColor(Colors.Grey.Darken1);

                    row.RelativeItem()
                        .Text(AssureNom)
                        .FontFamily(Fonts.SegoeUI)
                        .FontSize(14)
                        .SemiBold();
                });

                col.Item().PaddingTop(10);

                // Prénom
                col.Item().Row(row =>
                {
                    row.ConstantItem(90)
                        .Text("Prénom :")
                        .FontFamily(Fonts.Arial)
                        .FontSize(14)
                        .FontColor(Colors.Grey.Darken1);

                    row.RelativeItem()
                        .Text(AssurePrenom)
                        .FontFamily(Fonts.SegoeUI)
                        .FontSize(14)
                        .SemiBold();
                });

                col.Item().PaddingTop(10);

                // Date de naissance
                col.Item().Row(row =>
                {
                    row.ConstantItem(90)
                        .Text("Date né le :")
                        .FontFamily(Fonts.Arial)
                        .FontSize(14)
                        .FontColor(Colors.Grey.Darken1);

                    row.RelativeItem()
                        .Text(AssureDateNai)
                        .FontFamily(Fonts.SegoeUI)
                        .FontSize(14)
                        .SemiBold();
                });

                col.Item().PaddingTop(10);

                // N° Assurance
                col.Item().Row(row =>
                {
                    row.ConstantItem(90)
                        .Text("N° ASS :")
                        .FontFamily(Fonts.Arial)
                        .FontSize(14)
                        .FontColor(Colors.Grey.Darken1);

                    row.RelativeItem()
                        .Text(NumAss)
                        .FontFamily(Fonts.SegoeUI)
                        .FontSize(14)
                        .SemiBold();
                });

                col.Item().PaddingTop(10);

                // Caisse
                col.Item().Row(row =>
                {
                    row.ConstantItem(90)
                        .Text("Caisse :")
                        .FontFamily(Fonts.Arial)
                        .FontSize(14)
                        .FontColor(Colors.Grey.Darken1);

                    row.RelativeItem()
                        .Text(Caisse)
                        .FontFamily(Fonts.SegoeUI)
                        .FontSize(14)
                        .SemiBold();
                });

                col.Item().PaddingTop(10);

                // Centre payeur
                col.Item().Row(row =>
                {
                    row.RelativeItem()
                        .Text("Centre payeur :")
                        .FontFamily(Fonts.Arial)
                        .FontSize(14)
                        .FontColor(Colors.Grey.Darken1);

                    row.RelativeItem()
                        .Text(CentrePay)
                        .FontFamily(Fonts.SegoeUI)
                        .FontSize(14)
                        .SemiBold();
                });
            });
        }


        private static void Field(ColumnDescriptor col, string label, string value, bool bold = false)
        {
            col.Item().PaddingTop(6).Row(r =>
            {
                r.ConstantItem(80).Text(label);
                r.RelativeItem().Text(value).Bold();
            });
        }

        // ===== FOOTER =====
        private static void ComposeFooter(IContainer container)
        {

        }
    }
}
