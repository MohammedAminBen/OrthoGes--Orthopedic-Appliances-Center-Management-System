//using CodeSourceLayer;
//using Newtonsoft.Json.Bson;
//using PDFTemplates;
//using QuestPDF.Fluent;
//using QuestPDF.Infrastructure;
using CodeSource;
using CodeSourceLayer;
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

namespace OrthoGes
{
    public partial class FormPatientDetails : Form
    {
        private int PersonID = -1;
        private string Numero_Patient = null;
        Person person;
        Patient patient;
        Assure assure;
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
            gbxPatient.Size = new Size(1132, 286);
            lblNum.Visible = true;
            lblC.Visible = true;
            gbxAssure.Visible = false;
            lblTitle.Location = new Point(495, 344);
            dgvDocuments.Location= new Point(5, 395);
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



            this.Size = new Size(1195, 955);
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

                if(person.NomArabe!=string.Empty && person.PrenomArabe!=  string.Empty)
                    lblARNometPrenomPatient.Text = person.NomArabe +" "+ person.PrenomArabe;
                else lblARNometPrenomPatient.Text = "---";

                if (person.Email != string.Empty)
                    lblEmailPatient.Text = person.Email;
                else lblEmailPatient.Text = "---";

                
                lblAddressPatient.Text = person.Adresse + " " + person.Commune + " " + person.Wilaya;

                lblTelephonePatient.Text = person.Telephones[0];
                if (person.Telephones.Length > 1)
                {
                    lblTelephonePatient.Text +="/"+person.Telephones[1];
                    if (person.Telephones.Length > 2) lblTelephonePatient.Text += "/"+person.Telephones[2];
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
                
                if(personassure.NomArabe!= string.Empty && personassure.PrenomArabe!= string.Empty)
                    lblARNometPrenomAssure.Text = personassure.NomArabe + " " + personassure.PrenomArabe;
                else lblARNometPrenomAssure.Text = "---";

                if(personassure.Email != string.Empty)
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
            dgvAccord.Columns[2].Width = 130;

            dgvAccord.Columns[3].HeaderText = "Désignation";
            dgvAccord.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvAccord.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[3].Width = 230;

            dgvAccord.Columns[4].HeaderText = "Quantité";
            dgvAccord.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[4].Width = 100;

            dgvAccord.Columns[5].HeaderText = "Description";
            dgvAccord.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[5].Width = 150;

            dgvAccord.Columns[6].HeaderText = "Date d'accord";
            dgvAccord.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[6].Width = 100;

            dgvAccord.Columns[7].HeaderText = "etat d'accord";
            dgvAccord.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[7].Width = 130;

            dgvAccord.Columns[8].Visible = false;
            dgvAccord.Columns[8].HeaderText = "délai";
            dgvAccord.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccord.Columns[8].Width = 70;
        }

        private void FillDgvDocumentsWithData()
        {
            DataTable devis = Devis.GetAllDevisDePatient(Numero_Patient);
            DataTable facture = Facture.GetAllFacturesDePatient(Numero_Patient);
            DataTable bon_livraison = Bon_Livraison.GetAllBonDePatient(Numero_Patient);

            if (devis.Rows.Count == 0) { return; }
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
            //dgvDocuments.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[1].Width = 80;

            dgvDocuments.Columns[2].HeaderText = "Numéro";
            dgvDocuments.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvDocuments.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[2].Width = 80;

            dgvDocuments.Columns[3].HeaderText = "Référence";
            dgvDocuments.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvDocuments.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[3].Width = 110;

            dgvDocuments.Columns[4].Width = 170;
            dgvDocuments.Columns[5].Width = 100;

            dgvDocuments.Columns[6].HeaderText = "QTE";
            dgvDocuments.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[6].Width = 50;

            dgvDocuments.Columns[7].HeaderText = "TVA%";
            dgvDocuments.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[7].Width = 60;


            dgvDocuments.Columns[8].Width = 120;
            dgvDocuments.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[9].Width = 120;
            dgvDocuments.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDocuments.Columns[10].HeaderText = "Date";
            dgvDocuments.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[10].Width = 100;

            dgvDocuments.Columns[11].HeaderText = "Centre Pay";
            dgvDocuments.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocuments.Columns[11].Width = 100;

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


        //private void toolStripMenuItem4_Click(object sender, EventArgs e)
        //{
        //    QuestPDF.Settings.License = LicenseType.Community;

        //    List<(string GroupeID, int Montant, DateTime DateDebut, DateTime DateFin)> filters = new List<(string, int, DateTime, DateTime)>();

        //    foreach (DataGridViewRow row in dgvListDesDettes.SelectedRows)
        //    {
        //        string groupeId = row.Cells["GroupeID"].Value.ToString();
        //        int montant = (int)row.Cells["Montant"].Value;
        //        string periode = row.Cells["Periode"].Value.ToString(); // Example: "05/09/2025 - 04/10/2025"
        //        string[] dates = periode.Split(new string[] { " - " }, StringSplitOptions.None);

        //        DateTime datedebut = DateTime.ParseExact(dates[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        DateTime datefin = DateTime.ParseExact(dates[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //        filters.Add((groupeId, montant, datedebut, datefin));
        //    }

        //    // ✅ Generate document
        //    var document = RecuDePaiement.GenerateDocument(eleveID, filters);

        //    // ✅ Set save path
        //    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    string folderPath = Path.Combine(documentsPath, "SysSco Document");

        //    // Ensure the folder exists
        //    Directory.CreateDirectory(folderPath);

        //    string fileName = $"{person.NomEtPrenom}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.pdf";
        //    string filePath = Path.Combine(folderPath, fileName);

        //    // ✅ Save the PDF correctly
        //    document.GeneratePdf(filePath);

        //    // ✅ Wait briefly to ensure file write completes (optional but helpful)
        //    System.Threading.Thread.Sleep(200);

        //    // ✅ Open the generated PDF
        //    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
        //    {
        //        FileName = filePath,
        //        UseShellExecute = true
        //    });
        //}

        //private void toolStripMenuItem5_Click(object sender, EventArgs e)
        //{
        //    QuestPDF.Settings.License = LicenseType.Community;

        //    List<(string GroupeID, int Montant, DateTime DateDebut, DateTime DateFin)> filters = new List<(string, int, DateTime, DateTime)>();

        //    foreach (DataGridViewRow row in dgvhistoriquedepaiment.SelectedRows)
        //    {
        //        string groupeId = row.Cells["GroupeID"].Value.ToString();
        //        int montant = (int)row.Cells["Montant"].Value;
        //        string periode = row.Cells["Periode"].Value.ToString(); // Example: "05/09/2025 - 04/10/2025"
        //        string[] dates = periode.Split(new string[] { " - " }, StringSplitOptions.None);

        //        DateTime datedebut = DateTime.ParseExact(dates[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        DateTime datefin = DateTime.ParseExact(dates[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //        filters.Add((groupeId, montant, datedebut, datefin));
        //    }

        //    // ✅ Generate document
        //    var document = RecuDePaiement.GenerateDocument(eleveID, filters);

        //    // ✅ Set save path
        //    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    string folderPath = Path.Combine(documentsPath, "SysSco Document");

        //    // Ensure the folder exists
        //    Directory.CreateDirectory(folderPath);

        //    string fileName = $"{person.NomEtPrenom}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.pdf";
        //    string filePath = Path.Combine(folderPath, fileName);

        //    // ✅ Save the PDF correctly
        //    document.GeneratePdf(filePath);

        //    // ✅ Wait briefly to ensure file write completes (optional but helpful)
        //    System.Threading.Thread.Sleep(200);

        //    // ✅ Open the generated PDF
        //    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
        //    {
        //        FileName = filePath,
        //        UseShellExecute = true
        //    });
        //}
    }
}