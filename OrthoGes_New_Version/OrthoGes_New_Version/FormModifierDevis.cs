using CodeSourceLayer_;
using PDFTemplates;
using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CodeSourceLayer_.Devis;
namespace OrthoGes_New_Version
{
    public partial class FormModifierDevis : Form
    {
        private int PersonID = -1;
        private string Numero_Devis = null;
        Person person;
        Devis devis;
        Patient patient;
        Assure assure;
        public static List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA)> Produits { get; set; } = new();
        public static List<(string Reference, string designation, string PUHT, string Quantity, string Montant_HT, string MontantTVA, string TVA)> produitsForPDF { get; set; } = new();

        private bool _suppressSearch = false;
        private bool _suppressSearch2 = false;
        private bool _suppressSearch3 = false;


        private string oldreference1 = "-";
        private string oldreference2 = "-";
        private string oldreference3 = "-";

        public FormModifierDevis(string numero_patient)
        {
            InitializeComponent();
            Numero_Devis = numero_patient;
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
            devis = Devis.FindByNumeroDevis(Numero_Devis);
            patient = Patient.FindByNumeroPatient(devis.Numero_Patient);
            tbxDate.Text = devis.Date_Devis.ToString("d");

            if (patient == null)
            {
                MessageBox.Show("Error when trying to identify the patient");
                return;
            }
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
                tbxCentrePayeurPatient.Text = devis.Centre_Payeur;

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
                tbxCentrePayeurAssure.Text = devis.Centre_Payeur;
            }
            if (devis.Produits.Count >= 1)
            {
                Produit p1 = Produit.FindByReference(devis.Produits[0].Reference);
                tbxReference.Text = p1.Reference;
                oldreference1 = p1.Reference;
                tbxDesignation.Text = p1.Nom_Produit;
                tbxPUHT.Text = p1.Prix.ToString("F2");
                tbxQuantity.Text = (devis.Produits[0].Quantity.ToString());
                tbxMontant.Text = (p1.Prix * devis.Produits[0].Quantity).ToString("F2");
                tbxTVAMontant.Text = devis.Produits[0].MontantTVA.ToString();
                tbxTVA.Text = devis.Produits[0].TVA.ToString();
                if (devis.Produits.Count >= 2)
                {
                    Produit p2 = Produit.FindByReference(devis.Produits[1].Reference);
                    pnlProduit2.Visible = true;
                    tbxReference2.Text = p2.Reference;
                    oldreference2 = p2.Reference;
                    tbxDesignation2.Text = p2.Nom_Produit;
                    tbxPUHT2.Text = p2.Prix.ToString("F2");
                    tbxQuantity2.Text = devis.Produits[1].Quantity.ToString();
                    tbxMontant2.Text = (p2.Prix * devis.Produits[1].Quantity).ToString("F2");
                    tbxMontantTVA2.Text = devis.Produits[1].MontantTVA.ToString();
                    tbxTVA2.Text = devis.Produits[1].TVA.ToString();
                    if (devis.Produits.Count >= 3)
                    {
                        Produit p3 = Produit.FindByReference(devis.Produits[2].Reference);
                        pnlProduit3.Visible = true;
                        oldreference3 = p3.Reference;
                        tbxReference3.Text = p3.Reference;
                        tbxDesignation3.Text = p3.Nom_Produit;
                        tbxPUHT3.Text = p3.Prix.ToString("F2");
                        tbxQuantity3.Text = devis.Produits[2].Quantity.ToString();
                        tbxMontant3.Text = (p3.Prix * devis.Produits[2].Quantity).ToString("F2");
                        tbxMontantTVA3.Text = devis.Produits[2].MontantTVA.ToString();
                        tbxTVA3.Text = devis.Produits[2].TVA.ToString();
                    }
                }
            }
        }
        private void FormCreationDevis_Load(object sender, EventArgs e)
        {


            pnlProduit3.Visible = false;
            pnlProduit2.Visible = false;
            tbxMontant2.Text = "0.00";
            tbxMontantTVA2.Text = "0.00";
            tbxMontant3.Text = "0.00";
            tbxMontantTVA3.Text = "0.00";
            LoadData();
            dgvDesignation.Visible = false;
            dgvProduits.Visible = false;
            dgvProduit2.Visible = false;
            dgvDesignation2.Visible = false;
            dgvProduit3.Visible = false;
            dgvDesignation3.Visible = false;

        }
        private void RecalculateTotal()
        {
            decimal m1 = GetDecimal(tbxMontant.Text);
            decimal t1 = GetDecimal(tbxTVAMontant.Text);

            decimal m2 = GetDecimal(tbxMontant2.Text);
            decimal t2 = GetDecimal(tbxMontantTVA2.Text);

            decimal m3 = GetDecimal(tbxMontant3.Text);
            decimal t3 = GetDecimal(tbxMontantTVA3.Text);

            tbxTotale.Text = (m1 + t1 + m2 + t2 + m3 + t3).ToString("0.00");
        }
        private decimal GetDecimal(string value)
        {
            return decimal.TryParse(value, out var result) ? result : 0m;
        }

        private void tbxReference_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch) return;

            if (tbxReference.Text.Length == 0)
            {
                dgvProduits.Visible = false;
                return;
            }

            dgvProduits.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvProduits.DataSource = produits;

            for (int i = 1; i < dgvProduits.Columns.Count; i++)
                dgvProduits.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Reference LIKE '%{tbxReference.Text}%'";

            if (dv.Count == 0)
                dgvProduits.Visible = false;
        }

        private void dgvProduits_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch = true;

            tbxReference.Text = dgvProduits.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation.Text = dgvProduits.CurrentRow.Cells[1].Value.ToString();
            tbxPUHT.Text = dgvProduits.CurrentRow.Cells[4].Value.ToString();
            tbxTVA.Text = dgvProduits.CurrentRow.Cells[5].Value.ToString();
            //tbxTVAMontant.Text = dgvProduits.CurrentRow.Cells[6].Value.ToString();

            dgvProduits.Visible = false;

            _suppressSearch = false;

        }

        private void tbxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (tbxQuantity.Text == string.Empty || tbxPUHT.Text == string.Empty)
            {
                tbxMontant.Text = "0.00";
                return;
            }
            if (decimal.TryParse(tbxPUHT.Text, out decimal puht) &&
                decimal.TryParse(tbxQuantity.Text, out decimal quantity))
            {
                tbxMontant.Text = (puht * quantity).ToString("0.00");
            }
            else
            {
                tbxMontant.Text = "0.00";
            }

        }

        private void tbxMontant_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant.Text == string.Empty || tbxTVA.Text == string.Empty)
            {
                tbxTVAMontant.Text = "0.00";
                return;
            }

            if (decimal.TryParse(tbxMontant.Text, out decimal montant) &&
                decimal.TryParse(tbxTVA.Text, out decimal tva))
            {
                tbxTVAMontant.Text = (montant * tva / 100).ToString("0.00");
            }
            else
            {
                tbxTVAMontant.Text = "0.00";
            }


            if (tbxMontant.Text == string.Empty || tbxTVAMontant.Text == string.Empty)
            {
                tbxTotale.Text = "0.00";
                return;
            }
            RecalculateTotal();
        }

        private void tbxTVAMontant_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant.Text == string.Empty || tbxTVAMontant.Text == string.Empty)
            {
                tbxTotale.Text = "0.00";
                return;
            }

            if (decimal.TryParse(tbxMontant.Text, out decimal montant) &&
                decimal.TryParse(tbxTVAMontant.Text, out decimal tva))
            {
                RecalculateTotal();
            }
            else
                tbxTotale.Text = "0.00";

        }

        private void tbxDesignation_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch) return;

            if (tbxDesignation.Text.Length == 0)
            {
                dgvDesignation.Visible = false;
                return;
            }

            dgvDesignation.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvDesignation.DataSource = produits;

            dgvDesignation.Columns[0].Visible = false;
            for (int i = 2; i < dgvDesignation.Columns.Count; i++)
                dgvDesignation.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Nom_Produit LIKE '%{tbxDesignation.Text}%'";

            if (dv.Count == 0)
                dgvDesignation.Visible = false;
        }

        private void dgvDesignation_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch = true;

            tbxReference.Text = dgvDesignation.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation.Text = dgvDesignation.CurrentRow.Cells[1].Value.ToString();
            tbxPUHT.Text = dgvDesignation.CurrentRow.Cells[4].Value.ToString();
            tbxTVA.Text = dgvDesignation.CurrentRow.Cells[5].Value.ToString();
            //tbxTVAMontant.Text = dgvDesignation.CurrentRow.Cells[6].Value.ToString();

            dgvDesignation.Visible = false;

            _suppressSearch = false;
        }

        private void tbxTVA_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant.Text == string.Empty || tbxTVA.Text == string.Empty)
            {
                tbxTVAMontant.Text = "0.00";
                return;
            }
            if (decimal.TryParse(tbxMontant.Text, out decimal montant) &&
                decimal.TryParse(tbxTVA.Text, out decimal tva))
            {
                tbxTVAMontant.Text = (montant * tva / 100).ToString("0.00");
            }
            else
            {
                tbxTVAMontant.Text = "0.00";
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintDevisPDF(string numeroDevis)
        {
            QuestPDF.Settings.License = LicenseType.Community;

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
                document = PDFDevis.GenerateDocument(numeroDevis,
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
               tbxDate.Text);
            }
            else
            {
                document = PDFDevis.GenerateDocument(numeroDevis,
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
                tbxDate.Text);
            }

            // ✅ Set save path
            string doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderPath = Path.Combine(doc, "OrthoGes Document\\Devis");

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

        private void button5_Click(object sender, EventArgs e)
        {
            if (pnlProduit2.Visible == false)
            {
                pnlProduit2.Visible = true;


            }
            else
            {
                pnlProduit3.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pnlProduit3.Visible == true)
            {
                pnlProduit3.Visible = false;
            }
            else
            {
                pnlProduit2.Visible = false;
            }
        }

        private void tbxReference2_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch2) return;

            if (tbxReference2.Text.Length == 0)
            {
                dgvProduit2.Visible = false;
                return;
            }

            dgvProduit2.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvProduit2.DataSource = produits;

            for (int i = 1; i < dgvProduit2.Columns.Count; i++)
                dgvProduit2.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Reference LIKE '%{tbxReference2.Text}%'";

            if (dv.Count == 0)
                dgvProduit2.Visible = false;
        }

        private void dgvProduit2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch2 = true;

            tbxReference2.Text = dgvProduit2.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation2.Text = dgvProduit2.CurrentRow.Cells[1].Value.ToString();
            tbxPUHT2.Text = dgvProduit2.CurrentRow.Cells[4].Value.ToString();
            tbxTVA2.Text = dgvProduit2.CurrentRow.Cells[5].Value.ToString();
            //tbxTVAMontant.Text = dgvProduits.CurrentRow.Cells[6].Value.ToString();

            dgvProduit2.Visible = false;

            _suppressSearch2 = false;
        }

        private void tbxQuantity2_TextChanged(object sender, EventArgs e)
        {
            if (tbxQuantity2.Text == string.Empty || tbxPUHT2.Text == string.Empty)
            {
                tbxMontant2.Text = "0.00";
                return;
            }
            if (decimal.TryParse(tbxPUHT2.Text, out decimal puht) &&
                decimal.TryParse(tbxQuantity2.Text, out decimal quantity))
            {
                tbxMontant2.Text = (puht * quantity).ToString("0.00");
            }
            else
            {
                tbxMontant2.Text = "0.00";
            }
        }

        private void tbxMontant2_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant2.Text == string.Empty || tbxTVA2.Text == string.Empty)
            {
                tbxMontantTVA2.Text = "0.00";
                return;
            }

            if (decimal.TryParse(tbxMontant2.Text, out decimal montant) &&
                decimal.TryParse(tbxTVA2.Text, out decimal tva))
            {
                tbxMontantTVA2.Text = (montant * tva / 100).ToString("0.00");
            }
            else
            {
                tbxMontantTVA2.Text = "0.00";
            }


            if (tbxMontant2.Text == string.Empty || tbxMontantTVA2.Text == string.Empty)
            {
                tbxTotale.Text = "0.00";
                return;
            }

            RecalculateTotal();
        }

        private void tbxTVA2_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant2.Text == string.Empty || tbxTVA2.Text == string.Empty)
            {
                tbxMontantTVA2.Text = "0.00";
                return;
            }
            if (decimal.TryParse(tbxMontant2.Text, out decimal montant) &&
                decimal.TryParse(tbxTVA2.Text, out decimal tva))
            {
                tbxMontantTVA2.Text = (montant * tva / 100).ToString("0.00");
            }
            else
            {
                tbxMontantTVA2.Text = "0.00";
            }
        }

        private void tbxMontantTVA2_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant2.Text == string.Empty || tbxMontantTVA2.Text == string.Empty)
            {
                tbxTotale.Text = "0.00";
                return;
            }

            if (decimal.TryParse(tbxMontant2.Text, out decimal montant) &&
                decimal.TryParse(tbxMontantTVA2.Text, out decimal tva))
            {
                RecalculateTotal();
            }
            else
                tbxTotale.Text = "0.00";
        }

        private void tbxReference3_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch3) return;

            if (tbxReference3.Text.Length == 0)
            {
                dgvProduit3.Visible = false;
                return;
            }

            dgvProduit3.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvProduit3.DataSource = produits;

            for (int i = 1; i < dgvProduit3.Columns.Count; i++)
                dgvProduit3.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Reference LIKE '%{tbxReference3.Text}%'";

            if (dv.Count == 0)
                dgvProduit3.Visible = false;
        }

        private void dgvProduit3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch3 = true;

            tbxReference3.Text = dgvProduit3.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation3.Text = dgvProduit3.CurrentRow.Cells[1].Value.ToString();
            tbxPUHT3.Text = dgvProduit3.CurrentRow.Cells[4].Value.ToString();
            tbxTVA3.Text = dgvProduit3.CurrentRow.Cells[5].Value.ToString();
            //tbxTVAMontant.Text = dgvProduits.CurrentRow.Cells[6].Value.ToString();

            dgvProduit3.Visible = false;

            _suppressSearch3 = false;
        }

        private void dgvDesignation3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch3 = true;

            tbxReference3.Text = dgvDesignation3.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation3.Text = dgvDesignation3.CurrentRow.Cells[1].Value.ToString();
            tbxPUHT3.Text = dgvDesignation3.CurrentRow.Cells[4].Value.ToString();
            tbxTVA3.Text = dgvDesignation3.CurrentRow.Cells[5].Value.ToString();
            //tbxTVAMontant.Text = dgvDesignation.CurrentRow.Cells[6].Value.ToString();

            dgvDesignation3.Visible = false;

            _suppressSearch3 = false;
        }

        private void tbxQuantity3_TextChanged(object sender, EventArgs e)
        {
            if (tbxQuantity3.Text == string.Empty || tbxPUHT3.Text == string.Empty)
            {
                tbxMontant3.Text = "0.00";
                return;
            }
            if (decimal.TryParse(tbxPUHT3.Text, out decimal puht) &&
                decimal.TryParse(tbxQuantity3.Text, out decimal quantity))
            {
                tbxMontant3.Text = (puht * quantity).ToString("0.00");
            }
            else
            {
                tbxMontant3.Text = "0.00";
            }
        }

        private void tbxMontant3_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant3.Text == string.Empty || tbxTVA3.Text == string.Empty)
            {
                tbxMontantTVA3.Text = "0.00";
                return;
            }

            if (decimal.TryParse(tbxMontant3.Text, out decimal montant) &&
                decimal.TryParse(tbxTVA3.Text, out decimal tva))
            {
                tbxMontantTVA3.Text = (montant * tva / 100).ToString("0.00");
            }
            else
            {
                tbxMontantTVA3.Text = "0.00";
            }


            if (tbxMontant3.Text == string.Empty || tbxMontantTVA3.Text == string.Empty)
            {
                tbxTotale.Text = "0.00";
                return;
            }

            RecalculateTotal();
        }

        private void tbxMontantTVA3_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant3.Text == string.Empty || tbxMontantTVA3.Text == string.Empty)
            {
                tbxTotale.Text = "0.00";
                return;
            }

            if (decimal.TryParse(tbxMontant3.Text, out decimal montant) &&
                decimal.TryParse(tbxMontantTVA3.Text, out decimal tva))
            {
                RecalculateTotal();
            }
            else
                tbxTotale.Text = "0.00";
        }

        private void tbxTVA3_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant3.Text == string.Empty || tbxTVA3.Text == string.Empty)
            {
                tbxMontantTVA3.Text = "0.00";
                return;
            }
            if (decimal.TryParse(tbxMontant3.Text, out decimal montant) &&
                decimal.TryParse(tbxTVA3.Text, out decimal tva))
            {
                tbxMontantTVA3.Text = (montant * tva / 100).ToString("0.00");
            }
            else
            {
                tbxMontantTVA3.Text = "0.00";
            }
        }

        private void dgvDesignation2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch2 = true;

            tbxReference2.Text = dgvDesignation2.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation2.Text = dgvDesignation2.CurrentRow.Cells[1].Value.ToString();
            tbxPUHT2.Text = dgvDesignation2.CurrentRow.Cells[4].Value.ToString();
            tbxTVA2.Text = dgvDesignation2.CurrentRow.Cells[5].Value.ToString();
            //tbxTVAMontant.Text = dgvDesignation.CurrentRow.Cells[6].Value.ToString();

            dgvDesignation2.Visible = false;

            _suppressSearch2 = false;
        }

        private void tbxDesignation2_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch2) return;

            if (tbxDesignation2.Text.Length == 0)
            {
                dgvDesignation2.Visible = false;
                return;
            }

            dgvDesignation2.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvDesignation2.DataSource = produits;

            dgvDesignation2.Columns[0].Visible = false;
            for (int i = 2; i < dgvDesignation2.Columns.Count; i++)
                dgvDesignation2.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Nom_Produit LIKE '%{tbxDesignation2.Text}%'";

            if (dv.Count == 0)
                dgvDesignation2.Visible = false;
        }

        private void tbxDesignation3_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch3) return;

            if (tbxDesignation3.Text.Length == 0)
            {
                dgvDesignation3.Visible = false;
                return;
            }

            dgvDesignation3.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvDesignation3.DataSource = produits;

            dgvDesignation3.Columns[0].Visible = false;
            for (int i = 2; i < dgvDesignation3.Columns.Count; i++)
                dgvDesignation3.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Nom_Produit LIKE '%{tbxDesignation3.Text}%'";

            if (dv.Count == 0)
                dgvDesignation3.Visible = false;
        }

        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {

            bool resultProduits = true;
            bool resultDevis;

            try
            {
                // Produit 1
                if (!string.IsNullOrWhiteSpace(tbxTVAMontant.Text))
                {
                    resultProduits &= Devis.UpdateDevis_Produits(
                        Numero_Devis,
                        oldreference1,
                        tbxReference.Text,
                        int.Parse(tbxQuantity.Text),
                        decimal.Parse(tbxTVAMontant.Text),
                        decimal.Parse(tbxMontant.Text) + decimal.Parse(tbxTVAMontant.Text),
                        int.Parse(tbxTVA.Text)
                    );
                }

                // Produit 2
                if (pnlProduit2.Visible && !string.IsNullOrWhiteSpace(tbxMontantTVA2.Text))
                {

                    resultProduits &= Devis.UpdateDevis_Produits(
                        Numero_Devis,
                        oldreference2,
                        tbxReference2.Text,
                        int.Parse(tbxQuantity2.Text),
                        decimal.Parse(tbxMontantTVA2.Text),
                        decimal.Parse(tbxMontant2.Text) + decimal.Parse(tbxMontantTVA2.Text),
                        int.Parse(tbxTVA2.Text)
                    );
                }

                // Produit 3
                if (pnlProduit3.Visible && !string.IsNullOrWhiteSpace(tbxMontantTVA3.Text))
                {
                    resultProduits &= Devis.UpdateDevis_Produits(
                        Numero_Devis,
                        oldreference3,
                        tbxReference3.Text,
                        int.Parse(tbxQuantity3.Text),
                        decimal.Parse(tbxMontantTVA3.Text),
                        decimal.Parse(tbxMontant3.Text) + decimal.Parse(tbxMontantTVA3.Text),
                        int.Parse(tbxTVA3.Text)
                    );
                }

                // Update Bon (once, no useless if)
                resultDevis = Devis.UpdateDevis(
                    Numero_Devis,
                    DateTime.Parse(tbxDate.Text),
                    decimal.Parse(tbxTotale.Text),
                    tbxCentrePayeurPatient.Text);

                if (resultProduits && resultDevis)
                {
                    MessageBox.Show("Devis a été modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la modification du Devis ou des produits.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Données invalides : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProduits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                _suppressSearch = true;

                if (dgvDesignation.Visible)
                {
                    tbxReference.Text = dgvDesignation.CurrentRow.Cells[0].Value.ToString();
                    tbxDesignation.Text = dgvDesignation.CurrentRow.Cells[1].Value.ToString();
                    dgvDesignation.Visible = false;

                }
                else
                {
                    tbxReference.Text = dgvProduits.CurrentRow.Cells[0].Value.ToString();
                    tbxDesignation.Text = dgvProduits.CurrentRow.Cells[1].Value.ToString();
                    dgvProduits.Visible = false;

                }

                _suppressSearch = false;

            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Optional: keep full-row selection clean
                e.Handled = false; // let DataGridView handle navigation
            }
        }

        private void dgvProduit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                _suppressSearch2 = true;
                if (dgvDesignation2.Visible)
                {
                    tbxReference2.Text = dgvDesignation2.CurrentRow.Cells[0].Value.ToString();
                    tbxDesignation2.Text = dgvDesignation2.CurrentRow.Cells[1].Value.ToString();
                    dgvDesignation2.Visible = false;

                }
                else
                {
                    tbxReference2.Text = dgvProduit2.CurrentRow.Cells[0].Value.ToString();
                    tbxDesignation2.Text = dgvProduit2.CurrentRow.Cells[1].Value.ToString();
                    dgvProduit2.Visible = false;

                }

                //tbxTVAMontant.Text = dgvProduits.CurrentRow.Cells[6].Value.ToString();


                _suppressSearch2 = false;

            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Optional: keep full-row selection clean
                e.Handled = false; // let DataGridView handle navigation
            }
        }

        private void dgvProduit3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                _suppressSearch3 = true;

                if (dgvDesignation3.Visible)
                {
                    tbxReference3.Text = dgvDesignation3.CurrentRow.Cells[0].Value.ToString();
                    tbxDesignation3.Text = dgvDesignation3.CurrentRow.Cells[1].Value.ToString();
                    dgvDesignation3.Visible = false;

                }
                else
                {
                    tbxReference3.Text = dgvProduit3.CurrentRow.Cells[0].Value.ToString();
                    tbxDesignation3.Text = dgvProduit3.CurrentRow.Cells[1].Value.ToString();
                    dgvProduit3.Visible = false;

                }

                _suppressSearch3 = false;

            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Optional: keep full-row selection clean
                e.Handled = false; // let DataGridView handle navigation
            }
        }
    }
}
