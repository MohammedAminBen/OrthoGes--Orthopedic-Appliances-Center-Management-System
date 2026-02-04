using CodeSourceLayer_;
using PDFTemplate;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes_New_Version
{
    public partial class FormBonLivDetails : Form
    {
        private int PersonID = -1;
        private string Numero_Bon = null;
        Person person;
        Patient patient;
        Assure assure;
        Bon_Livraison bon;
        private bool _suppressSearch = false;
        private bool _suppressSearch2 = false;
        private bool _suppressSearch3 = false;

        public static List<(string Reference, string designation, string PUHT, string Quantity, string Montant_HT, string MontantTVA, string TVA)> produitsForPDF { get; set; } = new();

        public FormBonLivDetails(string numero_bon)
        {
            InitializeComponent();
            Numero_Bon = numero_bon;
        }

        private void AssuredCheckedConfig()
        {
            gbxpatient.Size = new System.Drawing.Size(766, 278);
            gbxAssure.Visible = false;
            gbxContact.Location = new System.Drawing.Point(11, 336);
            lblnum.Visible = true;
            tbxNumAssPatient.Visible = true;
            gbxProduit.Location = new System.Drawing.Point(11, 502);
            pnlTotal.Location = new System.Drawing.Point(11, 786);
            this.btnEnregistrer.Location = new System.Drawing.Point(477, 855);
            this.btnAnnuler.Location = new System.Drawing.Point(643, 854);
            lblD.Location = new Point(218, 865);
            tbxDate.Location = new Point(285, 856);
            this.Size = new System.Drawing.Size(805, 960);
        }
        private void LoadData()
        {
            bon = Bon_Livraison.FindByNumeroBon(Numero_Bon);
            patient = Patient.FindByNumeroPatient(bon.Numero_Patient);
            tbxDate.Text = bon.Date_Bon.ToString("d");
            if (patient == null)
            {
                MessageBox.Show("Error when trying to identify the patient");
                return;
            }
            lblNumero.Text = bon.Numero_Bon;
            if (patient.est_Assure == 1)
            {
                AssuredCheckedConfig();
                person = Person.Find(patient.PersonID);
                assure = Assure.FindByID(patient.AssureID);

                tbxNomPatient.Text = person.Nom;
                tbxPrenomPatient.Text = person.Prenom;
                tbxDateNaiPatient.Text = person.DateNaissance.ToString("d");
                tbxNumAssPatient.Text = assure.NumeroAssurance.ToString();
                tbxCaissePatient.Text = assure.CaisseNom;
                tbxadresse.Text = person.Adresse;
                tbxWilaya.Text = person.Wilaya;
                tbxCommune.Text = person.Commune;
                tbxCentrePayeurPatient.Text = bon.Centre_Payeur;

            }
            else
            {
                person = Person.Find(patient.PersonID);
                assure = Assure.FindByID(patient.AssureID);

                Person personassure = Person.Find(assure.PersonID);

                tbxNomPatient.Text = person.Nom;
                tbxPrenomPatient.Text = person.Prenom;
                tbxDateNaiPatient.Text = person.DateNaissance.ToString("d");

                tbxNomAssure.Text = personassure.Nom;
                tbxPrenomAssure.Text = personassure.Prenom;

                tbxDateNaiAssure.Text = personassure.DateNaissance.ToString("d");



                tbxNumAssAssure.Text = assure.NumeroAssurance.ToString();
                tbxCaisseAssure.Text = assure.CaisseNom;

                tbxadresse.Text = person.Adresse;
                tbxWilaya.Text = person.Wilaya;
                tbxCommune.Text = person.Commune;
                tbxCentrePayeurAssure.Text = bon.Centre_Payeur;
            }

            tbxPieceProduit.Text = bon.PieceProduit;
            if (bon.Produits.Count >= 1)
            {
                Produit p1 = Produit.FindByReference(bon.Produits[0].Reference);
                tbxReference.Text = p1.Reference;
                tbxDesignation.Text = p1.Nom_Produit;
                tbxPUHT.Text = p1.Prix.ToString("F2");
                tbxQuantity.Text = bon.Produits[0].Quantity.ToString();
                tbxMontant.Text = (p1.Prix * bon.Produits[0].Quantity).ToString("F2");
                tbxTVAMontant.Text = bon.Produits[0].MontantTVA.ToString();
                tbxTVA.Text = bon.Produits[0].TVA.ToString();
                if (bon.Produits.Count >= 2)
                {
                    Produit p2 = Produit.FindByReference(bon.Produits[1].Reference);
                    pnlProduit2.Visible = true;
                    tbxReference2.Text = p2.Reference;
                    tbxDesignation2.Text = p2.Nom_Produit;
                    tbxPUHT2.Text = p2.Prix.ToString("F2");
                    tbxQuantity2.Text = bon.Produits[1].Quantity.ToString();
                    tbxMontant2.Text = (p2.Prix * bon.Produits[1].Quantity).ToString("F2");
                    tbxMontantTVA2.Text = bon.Produits[1].MontantTVA.ToString();
                    tbxTVA2.Text = bon.Produits[1].TVA.ToString();
                    if (bon.Produits.Count >= 3)
                    {
                        Produit p3 = Produit.FindByReference(bon.Produits[2].Reference);
                        pnlProduit3.Visible = true;
                        tbxReference3.Text = p3.Reference;
                        tbxDesignation3.Text = p3.Nom_Produit;
                        tbxPUHT3.Text = p3.Prix.ToString("F2");
                        tbxQuantity3.Text = bon.Produits[2].Quantity.ToString();
                        tbxMontant3.Text = (p3.Prix * bon.Produits[2].Quantity).ToString("F2");
                        tbxMontantTVA3.Text = bon.Produits[2].MontantTVA.ToString();
                        tbxTVA3.Text = bon.Produits[2].TVA.ToString();
                    }
                }
            }
            tbxTotale.Text = bon.Montant_TTC.ToString("F2");

        }
        private void FormCreationDevis_Load(object sender, EventArgs e)
        {
            pnlProduit3.Visible = false;
            pnlProduit2.Visible = false;
            LoadData();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
           PrintBonLivraisonPDF(Numero_Bon);
        }
        private void PrintBonLivraisonPDF(string numeroBon)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            produitsForPDF.Clear();
            produitsForPDF.Add((tbxReference.Text, tbxDesignation.Text, tbxPUHT.Text, tbxQuantity.Text, tbxMontant.Text, tbxTVAMontant.Text, tbxTVA.Text));
            if (pnlProduit2.Visible == true)
            {
                if (tbxMontantTVA2 != null)
                {
                    produitsForPDF.Add((tbxReference2.Text, tbxDesignation2.Text, tbxPUHT2.Text, tbxQuantity2.Text, tbxMontant2.Text, tbxMontantTVA2.Text, tbxTVA2.Text));
                }
            }
            if (pnlProduit3.Visible == true)
            {
                if (tbxMontantTVA3 != null)
                {
                    produitsForPDF.Add((tbxReference3.Text, tbxDesignation3.Text, tbxPUHT3.Text, tbxQuantity3.Text, tbxMontant3.Text, tbxMontantTVA3.Text, tbxTVA3.Text));
                }
            }
            Document document;
            if (patient.est_Assure != 1)
            {
                document = PDFBon_Livraison.GenerateDocument(numeroBon,
               tbxNomPatient.Text,
               tbxPrenomPatient.Text,
               tbxDateNaiPatient.Text,
               tbxNomAssure.Text,
               tbxPrenomAssure.Text,
               tbxDateNaiAssure.Text,
               tbxNumAssAssure.Text,
               tbxCaisseAssure.Text,
               tbxCentrePayeurAssure.Text,
               tbxadresse.Text,
               tbxWilaya.Text,
               tbxCommune.Text, produitsForPDF,
               tbxTotale.Text,
               tbxDate.Text,
               tbxPieceProduit.Text);
            }
            else
            {
                document = PDFBon_Livraison.GenerateDocument(numeroBon,
                tbxNomPatient.Text,
                tbxPrenomPatient.Text,
                tbxDateNaiPatient.Text,
                tbxNomPatient.Text,
                tbxPrenomPatient.Text,
                tbxDateNaiPatient.Text,
                tbxNumAssPatient.Text,
                tbxCaissePatient.Text,
                tbxCentrePayeurPatient.Text,
                tbxadresse.Text,
                tbxWilaya.Text,
                tbxCommune.Text, produitsForPDF,
                tbxTotale.Text,
                tbxDate.Text,
                tbxPieceProduit.Text);
            }

            // ✅ Set save path
            string doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderPath = Path.Combine(doc, "OrthoGes Document\\Bons De Livraison");

            // Ensure the folder exists
            Directory.CreateDirectory(folderPath);

            string fileName = $"{person.NomEtPrenom}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.pdf";
            string filePath = Path.Combine(folderPath, fileName);

            // ✅ Save the PDF correctly
            document.GeneratePdf(filePath);

            // ✅ Wait briefly to ensure file write completes (optional but helpful)
            System.Threading.Thread.Sleep(200);

            // ✅ Open the generated PDF
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = filePath,
                UseShellExecute = true
            });
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
