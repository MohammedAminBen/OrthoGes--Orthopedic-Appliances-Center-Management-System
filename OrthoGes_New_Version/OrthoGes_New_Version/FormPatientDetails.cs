
using CodeSourceLayer_;
using DataLayer_;
using PDFTemplate;
using PDFTemplates;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace OrthoGes_New_Version
{
    public partial class FormPatientDetails : Form
    {
        private int PersonID = -1;
        private string Numero_Patient = null;
        Person person;
        Patient patient;
        Assure assure;
        public static List<(string Reference, string designation, string PUHT, string Quantity, string Montant_HT, string MontantTVA, string TVA)> produitsForPDF { get; set; } = new();

        public FormPatientDetails(string numero_patient)
        {
            InitializeComponent();
            Numero_Patient = numero_patient;
        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }
        private void AssureCheckedConfig()
        {
            gbxPatient.Size = new System.Drawing.Size(1132, 286);
            lblNum.Visible = true;
            lblC.Visible = true;
            gbxAssure.Visible = false;
            lblTitle.Location = new Point(495, 344);
            dgvDocuments.Location = new Point(5, 395);
            btnFermer.Location = new Point(1021, 1215);
            btnModifer.Location = new Point(874, 1215);
            btnSupprimer.Location = new Point(725, 1215);
            btnCreationDevis.Location = new Point(564, 1215);
            btnCreationFacture.Location = new Point(389, 1215);
            btnCreationBonLiv.Location = new Point(135, 1215);
            this.dgvAccord.Location = new System.Drawing.Point(5, 844);
            this.label5.Location = new System.Drawing.Point(507, 786);
            this.btnCreerAccord.Location = new System.Drawing.Point(980, 785);
            this.pictureBox3.Location = new System.Drawing.Point(626, 783);



            this.Size = new System.Drawing.Size(1195, 955);
        }
        private void LoadData()
        {
            patient = Patient.FindByNumeroPatient(Numero_Patient);
            if (patient == null)
            {
                MessageBox.Show("Error when trying to identify the patient");
                return;
            }
            if (patient.est_Assure == 1)
            {
                AssureCheckedConfig();
                person = Person.Find(patient.PersonID);
                assure = Assure.FindByID(patient.AssureID);

                lblNumPatient.Text = patient.NumeroPatient;
                lblNometPrenomPatient.Text = person.NomEtPrenom;
                lblDateDinscriptionPatient.Text = patient.Date_Dinscription.ToString("d");
                lblDateNaiPatient.Text = person.DateNaissance.ToString("d");
                lblNumAssPatient.Text = assure.NumeroAssurance.ToString();
                lblCaissePatient.Text = assure.CaisseNom;

                if (person.Genre == 0)
                {
                    lblGenrePatient.Text = "Femelle";
                }
                else { lblGenrePatient.Text = "Male"; }

                if (person.NomArabe != string.Empty && person.PrenomArabe != string.Empty)
                    lblARNometPrenomPatient.Text = person.NomArabe + " " + person.PrenomArabe;
                else lblARNometPrenomPatient.Text = "---";

                if (person.Email != string.Empty)
                    lblEmailPatient.Text = person.Email;
                else lblEmailPatient.Text = "---";


                lblAddressPatient.Text = person.Adresse + " " + person.Commune + " " + person.Wilaya;

                lblTelephonePatient.Text = person.Telephones[0];
                if (person.Telephones.Length > 1)
                {
                    lblTelephonePatient.Text += "/" + person.Telephones[1];
                    if (person.Telephones.Length > 2) lblTelephonePatient.Text += "/" + person.Telephones[2];
                }

            }
            else
            {
                person = Person.Find(patient.PersonID);
                assure = Assure.FindByID(patient.AssureID);

                Person personassure = Person.Find(assure.PersonID);

                lblNumPatient.Text = patient.NumeroPatient;
                lblNometPrenomPatient.Text = person.NomEtPrenom;

                lblDateNaiPatient.Text = person.DateNaissance.ToString("d");

                if (person.Genre == 0)
                {
                    lblGenrePatient.Text = "Femelle";
                }
                else { lblGenrePatient.Text = "Male"; }


                if (person.NomArabe != string.Empty && person.PrenomArabe != string.Empty)
                    lblARNometPrenomPatient.Text = person.NomArabe + " " + person.PrenomArabe;
                else lblARNometPrenomPatient.Text = "---";

                if (person.Email != string.Empty)
                    lblEmailPatient.Text = person.Email;
                else lblEmailPatient.Text = "---";

                lblAddressPatient.Text = person.Adresse + " " + person.Commune + " " + person.Wilaya;
                lblDateDinscriptionPatient.Text = patient.Date_Dinscription.ToString("d");
                lblTelephonePatient.Text = person.Telephones[0];
                if (person.Telephones.Length > 1)
                {
                    lblTelephonePatient.Text += "/" + person.Telephones[1];
                    if (person.Telephones.Length > 2) lblTelephonePatient.Text += "/" + person.Telephones[2];
                }

                //////////////////

                lblRelationAssure.Text = assure.RelationPatient;
                lblNometPrenomAssure.Text = personassure.NomEtPrenom;
                lblDateDinscriptionAssure.Text = patient.Date_Dinscription.ToString("d");
                lblDateNaiAssure.Text = personassure.DateNaissance.ToString("d");
                lblNumAssAssure.Text = assure.NumeroAssurance.ToString();
                lblCaisseAssure.Text = assure.CaisseNom;

                if (personassure.Genre == 1)
                {
                    lblGenreAssure.Text = "Male";
                }
                else { lblGenreAssure.Text = "Femelle"; }

                if (personassure.NomArabe != string.Empty && personassure.PrenomArabe != string.Empty)
                    lblARNometPrenomAssure.Text = personassure.NomArabe + " " + personassure.PrenomArabe;
                else lblARNometPrenomAssure.Text = "---";

                if (personassure.Email != string.Empty)
                    lblEmailAssure.Text = personassure.Email;
                else lblEmailAssure.Text = "---";

                lblAdresseAssure.Text = personassure.Adresse + " " + personassure.Commune + " " + personassure.Wilaya;

                lblTelephoneAssure.Text = personassure.Telephones[0];
                if (personassure.Telephones.Length > 1)
                {
                    lblTelephoneAssure.Text += "/" + personassure.Telephones[1];
                    if (personassure.Telephones.Length > 2) lblTelephoneAssure.Text += "/" + personassure.Telephones[2];
                }
            }

        }
        private void FormPatientDetails_Load(object sender, EventArgs e)
        {
            LoadData();
            FillDgvDocumentsWithData();
            FillDgvAccordWithData();
        }

        private void FillDgvAccordWithData()
        {
            DataTable dt = Accord.GetAllByPatient(Numero_Patient);
            if (dt.Rows.Count == 0) { return; }
            DataView dv = dt.DefaultView;
            dgvAccord.DataSource = dv;

            dgvAccord.Columns[1].Visible = false;
            dgvAccord.Columns[2].HeaderText = "Référence";
            dgvAccord.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[2].Width = 170;

            dgvAccord.Columns[3].HeaderText = "Description";
            dgvAccord.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[3].Width = 170;

            dgvAccord.Columns[4].HeaderText = "Quantité";
            dgvAccord.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[4].Width = 120;

            dgvAccord.Columns[5].HeaderText = "Date d'accord";
            dgvAccord.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[5].Width = 100;

            dgvAccord.Columns[6].HeaderText = "etat d'accord";
            dgvAccord.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[6].Width = 130;

            //dgvAccord.Columns[7].Visible = false;
            //dgvAccord.Columns[7].HeaderText = "délai";
            //dgvAccord.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvAccord.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvAccord.Columns[7].Width = 70;
        }

        private void FillDgvDocumentsWithData()
        {
            DataTable devis = Devis.GetAllDevisDePatient(Numero_Patient);
            DataTable facture = Facture.GetAllFacturesDePatient(Numero_Patient);
            DataTable bon_livraison = Bon_Livraison.GetAllBonDePatient(Numero_Patient);

            if (devis.Rows.Count == 0 && facture.Rows.Count == 0 && bon_livraison.Rows.Count == 0) { return; }
            // Clone the structure of table1
            DataTable combined = devis.Clone();

            // Import all rows
            foreach (DataTable t in new DataTable[] { devis, facture, bon_livraison })
            {
                foreach (DataRow row in t.Rows)
                    combined.ImportRow(row);
            }

            // Bind to DataGridView

            DataView dv = combined.DefaultView;
            dgvDocuments.DataSource = dv;

            dgvDocuments.DataSource = dv;
            dgvDocuments.Columns[1].HeaderText = "Type";
            dgvDocuments.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[1].Width = 100;

            dgvDocuments.Columns[2].HeaderText = "Numéro";
            dgvDocuments.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[2].Width = 100;

            dgvDocuments.Columns[3].HeaderText = "Références";
            dgvDocuments.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[3].Width = 170;

            dgvDocuments.Columns[4].HeaderText = "Montant TTC";
            dgvDocuments.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[4].Width = 150;

            dgvDocuments.Columns[5].HeaderText = "Centre Payeur";
            dgvDocuments.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[5].Width = 120;

            dgvDocuments.Columns[6].HeaderText = "Date";
            dgvDocuments.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[6].Width = 120;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormCreationDevis frmDevis = new FormCreationDevis(Numero_Patient);
            frmDevis.ShowDialog();
            FillDgvDocumentsWithData();
        }

        private void btnCreationFacture_Click(object sender, EventArgs e)
        {
            FormCreationFacture frmFacture = new FormCreationFacture(Numero_Patient);
            frmFacture.ShowDialog();
            FillDgvDocumentsWithData();
        }

        private void btnCreationBonLiv_Click(object sender, EventArgs e)
        {
            FormCreationBonLiv frmBonLiv = new FormCreationBonLiv(Numero_Patient);
            frmBonLiv.ShowDialog();
            FillDgvDocumentsWithData();
        }

        private void btnModifer_Click(object sender, EventArgs e)
        {
            FormModifierPatient frmModifier = new FormModifierPatient(Numero_Patient);
            frmModifier.ShowDialog();
            LoadData();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("êtes-vous sûr de vouloir supprimer ce patient ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Patient.DeletePatient(Numero_Patient);
                MessageBox.Show("Patient supprimé avec succès.");
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormCreationAccord frmAccord = new FormCreationAccord(Numero_Patient);
            frmAccord.ShowDialog();
            FillDgvAccordWithData();
        }
        private void PrintDevisPDF(string numeroDevis)
        {
            Devis devis = Devis.FindByNumeroDevis(numeroDevis);
            Patient patient = Patient.FindByNumeroPatient(devis.Numero_Patient);
            Person person = Person.Find(patient.PersonID);
            Assure assure = Assure.FindByID(patient.AssureID);
            Person personAssure = Person.Find(assure.PersonID);
            Produit p1 = Produit.FindByReference(devis.Produits[0].Reference);

            QuestPDF.Settings.License = LicenseType.Community;
            produitsForPDF.Clear();
            produitsForPDF.Add((devis.Produits[0].Reference, p1.Nom_Produit, p1.Prix.ToString(), devis.Produits[0].Quantity.ToString(), (devis.Produits[0].Quantity * p1.Prix).ToString(), devis.Produits[0].MontantTVA.ToString(), devis.Produits[0].TVA.ToString()));
            if (devis.Produits.Count > 1)
            {
                Produit p2 = Produit.FindByReference(devis.Produits[1].Reference);
                produitsForPDF.Add((devis.Produits[1].Reference, p2.Nom_Produit, p2.Prix.ToString(), devis.Produits[1].Quantity.ToString(), (devis.Produits[1].Quantity * p2.Prix).ToString(), devis.Produits[1].MontantTVA.ToString(), devis.Produits[1].TVA.ToString()));

            }
            if (devis.Produits.Count > 2)
            {
                Produit p3 = Produit.FindByReference(devis.Produits[2].Reference);
                produitsForPDF.Add((devis.Produits[2].Reference, p3.Nom_Produit, p3.Prix.ToString(), devis.Produits[2].Quantity.ToString(), (devis.Produits[2].Quantity * p3.Prix).ToString(), devis.Produits[2].MontantTVA.ToString(), devis.Produits[2].TVA.ToString()));
            }
            Document document;
            document = PDFDevis.GenerateDocument(numeroDevis,
           person.Nom,
           person.Prenom,
           person.DateNaissance.ToString("d"),
           personAssure.Nom,
           personAssure.Prenom,
           personAssure.DateNaissance.ToString("d"),
           assure.NumeroAssurance,
           assure.CaisseNom,
           devis.Centre_Payeur,
           person.Adresse,
           person.Wilaya,
           person.Commune,
           produitsForPDF,
           devis.Montant_TTC.ToString(),
           devis.Date_Devis.ToString("d"));

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
        private void PrintFacturePDF(string numerofacture)
        {
            Facture facture = Facture.FindByNumeroFacture(numerofacture);
            Patient patient = Patient.FindByNumeroPatient(facture.Numero_Patient);
            Person person = Person.Find(patient.PersonID);
            Assure assure = Assure.FindByID(patient.AssureID);
            Person personAssure = Person.Find(assure.PersonID);
            Produit p1 = Produit.FindByReference(facture.Produits[0].Reference);

            QuestPDF.Settings.License = LicenseType.Community;
            produitsForPDF.Clear();
            produitsForPDF.Add((facture.Produits[0].Reference, p1.Nom_Produit, p1.Prix.ToString(), facture.Produits[0].Quantity.ToString(), (facture.Produits[0].Quantity * p1.Prix).ToString(), facture.Produits[0].MontantTVA.ToString(), facture.Produits[0].TVA.ToString()));
            if (facture.Produits.Count > 1)
            {
                Produit p2 = Produit.FindByReference(facture.Produits[1].Reference);
                produitsForPDF.Add((facture.Produits[1].Reference, p2.Nom_Produit, p2.Prix.ToString(), facture.Produits[1].Quantity.ToString(), (facture.Produits[1].Quantity * p2.Prix).ToString(), facture.Produits[1].MontantTVA.ToString(), facture.Produits[1].TVA.ToString()));

            }
            if (facture.Produits.Count > 2)
            {
                Produit p3 = Produit.FindByReference(facture.Produits[2].Reference);
                produitsForPDF.Add((facture.Produits[2].Reference, p3.Nom_Produit, p3.Prix.ToString(), facture.Produits[2].Quantity.ToString(), (facture.Produits[2].Quantity * p3.Prix).ToString(), facture.Produits[2].MontantTVA.ToString(), facture.Produits[2].TVA.ToString()));
            }
            Document document;
            document = PDFFacture.GenerateDocument(numerofacture,
           person.Nom,
           person.Prenom,
           person.DateNaissance.ToString("d"),
           personAssure.Nom,
           personAssure.Prenom,
           personAssure.DateNaissance.ToString("d"),
           assure.NumeroAssurance,
           assure.CaisseNom,
           facture.Centre_Payeur,
           person.Adresse,
           person.Wilaya,
           person.Commune,
           produitsForPDF,
           facture.Montant_TTC.ToString(),
           facture.Date_Facture.ToString("d"));

            // ✅ Set save path
            string doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderPath = Path.Combine(doc, "OrthoGes Document\\Facture");

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
        private void PrintBon_LivraisonPDF(string numeroBon)
        {
            Bon_Livraison bon = Bon_Livraison.FindByNumeroBon(numeroBon);
            Patient patient = Patient.FindByNumeroPatient(bon.Numero_Patient);
            Person person = Person.Find(patient.PersonID);
            Assure assure = Assure.FindByID(patient.AssureID);
            Person personAssure = Person.Find(assure.PersonID);
            Produit p1 = Produit.FindByReference(bon.Produits[0].Reference);

            QuestPDF.Settings.License = LicenseType.Community;
            produitsForPDF.Clear();
            produitsForPDF.Add((bon.Produits[0].Reference, p1.Nom_Produit, p1.Prix.ToString(), bon.Produits[0].Quantity.ToString(), (bon.Produits[0].Quantity * p1.Prix).ToString(), bon.Produits[0].MontantTVA.ToString(), bon.Produits[0].TVA.ToString()));
            if (bon.Produits.Count > 1)
            {
                Produit p2 = Produit.FindByReference(bon.Produits[1].Reference);
                produitsForPDF.Add((bon.Produits[1].Reference, p2.Nom_Produit, p2.Prix.ToString(), bon.Produits[1].Quantity.ToString(), (bon.Produits[1].Quantity * p2.Prix).ToString(), bon.Produits[1].MontantTVA.ToString(), bon.Produits[1].TVA.ToString()));

            }
            if (bon.Produits.Count > 2)
            {
                Produit p3 = Produit.FindByReference(bon.Produits[2].Reference);
                produitsForPDF.Add((bon.Produits[2].Reference, p3.Nom_Produit, p3.Prix.ToString(), bon.Produits[2].Quantity.ToString(), (bon.Produits[2].Quantity * p3.Prix).ToString(), bon.Produits[2].MontantTVA.ToString(), bon.Produits[2].TVA.ToString()));
            }
            Document document;
            document = PDFBon_Livraison.GenerateDocument(numeroBon,
           person.Nom,
           person.Prenom,
           person.DateNaissance.ToString("d"),
           personAssure.Nom,
           personAssure.Prenom,
           personAssure.DateNaissance.ToString("d"),
           assure.NumeroAssurance,
           assure.CaisseNom,
           bon.Centre_Payeur,
           person.Adresse,
           person.Wilaya,
           person.Commune,
           produitsForPDF,
           bon.Montant_TTC.ToString(),
           bon.Date_Bon.ToString("d"),
           bon.PieceProduit);

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
        private void cmsImprimer_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.CurrentRow.Cells[1].Value.ToString() == "Devis")
            {
                PrintDevisPDF(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
            }
            else if (dgvDocuments.CurrentRow.Cells[1].Value.ToString() == "Facture")
            {
                PrintFacturePDF(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
            }
            else if (dgvDocuments.CurrentRow.Cells[1].Value.ToString() == "Bon de livraison")
            {
                PrintBon_LivraisonPDF(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
            }
        }

        private void cmsSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.CurrentRow.Cells[1].Value.ToString() == "Devis")
            {
                var result = MessageBox.Show("Vous êtes sur le point de supprimer un devis. Cette action est irréversible.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    Devis.DeleteDevis(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
                    FillDgvDocumentsWithData();
                }
            }
            else if (dgvDocuments.CurrentRow.Cells[1].Value.ToString() == "Facture")
            {
                var result = MessageBox.Show("Vous êtes sur le point de supprimer une facture. Cette action est irréversible.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    Facture.DeleteFacture(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
                    FillDgvDocumentsWithData();
                }
            }
            else if (dgvDocuments.CurrentRow.Cells[1].Value.ToString() == "Bon de livraison")
            {
                var result = MessageBox.Show("Vous êtes sur le point de supprimer un bon de livraison. Cette action est irréversible.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    Bon_Livraison.DeleteBon_Livraison(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
                    FillDgvDocumentsWithData();
                }
            }
        }

        private void cmsDetails_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.CurrentRow.Cells[1].Value.ToString() == "Devis")
            {
                FormDevisDetails frmdevis = new FormDevisDetails(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
                frmdevis.ShowDialog();
            }
            else if (dgvDocuments.CurrentRow.Cells[1].Value.ToString() == "Facture")
            {
                FormFactureDetails frmfacture = new FormFactureDetails(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
                frmfacture.ShowDialog();
            }
            else if (dgvDocuments.CurrentRow.Cells[1].Value.ToString() == "Bon de livraison")
            {
                FormBonLivDetails frmbonliv = new FormBonLivDetails(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
                frmbonliv.ShowDialog();
            }
        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Vous êtes sur le point de supprimer cet accord. Cette action est irréversible.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Accord.DeleteAccord(Convert.ToInt32(dgvAccord.CurrentRow.Cells[1].Value));
                FillDgvAccordWithData();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormAccordDetails frmaccord = new FormAccordDetails(Convert.ToInt32(dgvAccord.CurrentRow.Cells[1].Value));
            frmaccord.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormModifierEtatAccord frmModifierEtatAccord = new FormModifierEtatAccord(Convert.ToInt32(dgvAccord.CurrentRow.Cells[1].Value));
            frmModifierEtatAccord.ShowDialog();
            FillDgvAccordWithData();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bonDeLivraisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModifierBonLiv modifierbon = new FormModifierBonLiv(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
            modifierbon.ShowDialog();
            FillDgvDocumentsWithData();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FormModifierAccord modifieraccord = new FormModifierAccord(Convert.ToInt32(dgvAccord.CurrentRow.Cells[1].Value));
            modifieraccord.ShowDialog();
            FillDgvAccordWithData();
        }

        private void devisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModifierDevis modifierDevis = new FormModifierDevis(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
            modifierDevis.ShowDialog();
            FillDgvDocumentsWithData();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void factureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModifierFacture modifierFacture = new FormModifierFacture(dgvDocuments.CurrentRow.Cells[2].Value.ToString());
            modifierFacture.ShowDialog();
            FillDgvDocumentsWithData();
        }
    }
}