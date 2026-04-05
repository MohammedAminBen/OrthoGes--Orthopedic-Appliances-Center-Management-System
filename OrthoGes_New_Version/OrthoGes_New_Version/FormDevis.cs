using CodeSourceLayer_;
using PDFTemplate;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using PDFTemplates;


namespace OrthoGes_New_Version
{
    public partial class FormDevis : Form
    {
        private DataTable dtDevisListe;
        public static List<(string Reference, string designation, string PUHT, string Quantity, string Montant_HT, string MontantTVA, string TVA)> produitsForPDF { get; set; } = new();

        private void checkPrivileges()
        {
            if (!Global.utilisateurActuel.PrivManipulationDevis)
            {
                btnDetails.Enabled = false;
                btnSupprimer.Enabled = false;
                btnModifier.Enabled = false;
                btnImprimer.Enabled = false;

            }
            if (!Global.utilisateurActuel.PrivManipulationPatient)
            {
                btnPatientDetails.Enabled = false;
            }
        }

        public void ApplyFilters()
        {
            dtDevisListe = Devis.GetAll();

            if (dtDevisListe.Rows.Count == 0)
            {
                btnSupprimer.Enabled = false;
                btnDetails.Enabled = false;
                btnImprimer.Enabled = false;
                btnPatientDetails.Enabled = false;
                btnModifier.Enabled = false;
                return;
            }

            btnSupprimer.Enabled = true;
            btnDetails.Enabled = true;
            btnImprimer.Enabled = true;
            btnPatientDetails.Enabled = true;
            btnModifier.Enabled = true;

            checkPrivileges();

            List<string> filters = new List<string>();

            if (cbxMoisAnnée.Checked)
            {
                /* ================= MONTH & YEAR FILTER ================= */

                Dictionary<string, int> moisFrancais = new Dictionary<string, int>()
                {
                 { "Janvier", 1 }, { "Février", 2 }, { "Mars", 3 },
                 { "Avril", 4 }, { "Mai", 5 }, { "Juin", 6 },
                 { "Juillet", 7 }, { "Août", 8 }, { "Septembre", 9 },
                 { "Octobre", 10 }, { "Novembre", 11 }, { "Décembre", 12 }
                };

                string mois = cmbxMois.Text.Trim();
                string annee = cmbxAnnee.Text.Trim();

                if (mois != "Tous" && annee != "Tous" &&
                    moisFrancais.ContainsKey(mois) && int.TryParse(annee, out int year))
                {
                    int month = moisFrancais[mois];

                    DateTime startDate = new DateTime(year, month, 1);
                    DateTime endDate = startDate.AddMonths(1);

                    filters.Add(
                        $"Date_Devis >= #{startDate:MM/dd/yyyy}# AND Date_Devis < #{endDate:MM/dd/yyyy}#"
                    );
                }
                else if (annee != "Tous" && int.TryParse(annee, out year))
                {
                    DateTime startDate = new DateTime(year, 1, 1);
                    DateTime endDate = startDate.AddYears(1);

                    filters.Add(
                        $"Date_Devis >= #{startDate:MM/dd/yyyy}# AND Date_Devis < #{endDate:MM/dd/yyyy}#"
                    );
                }
            }
            if (cbxDate.Checked)
            {
                filters.Add(
                    $"Date_Devis >= #{DateDe.Value:MM/dd/yyyy}# AND Date_Devis < #{DateA.Value:MM/dd/yyyy}#"
                );
            }


            /* ================= SEARCH FILTER ================= */

            string searchValue = tbxfacturesrecherche.Text.Trim();
            string searchFilter = cmbxRecherche.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue) && searchValue != "Taper ici...")
            {
                if (searchFilter == "Nom et Prénom")
                    filters.Add($"Patient LIKE '%{searchValue}%'");
                else if (searchFilter == "Numéro Devis")
                    filters.Add($"Numero_Devis LIKE '%{searchValue}%'");
            }

            /* ================= APPLY FILTER ================= */

            DataView dv = dtDevisListe.DefaultView;
            dv.RowFilter = filters.Count > 0 ? string.Join(" AND ", filters) : string.Empty;

            dgvDevisListe.AutoGenerateColumns = true;
            dgvDevisListe.DataSource = dv;

            lblnmbrEleves.Text = dv.Count + "  Devis       ";


            dgvDevisListe.Columns[1].HeaderText = "N°Devis";
            dgvDevisListe.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvFactureListe.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[1].Width = 70;

            dgvDevisListe.Columns[2].HeaderText = "Patient";
            //dgvFactureListe.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[2].Width = 140;


            //dgvFactureListe.Columns[3].Visible = false;
            dgvDevisListe.Columns[3].HeaderText = "N°patient";
            dgvDevisListe.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[3].Width = 80;

            dgvDevisListe.Columns[4].Width = 120;
            dgvDevisListe.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvFactureListe.Columns[5].Visible = false;
            dgvDevisListe.Columns[5].HeaderText = "N°assurance";
            dgvDevisListe.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[5].Width = 100;

            //dgvFactureListe.Columns[6].Visible = false;
            dgvDevisListe.Columns[6].HeaderText = "Caisse";
            dgvDevisListe.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[6].Width = 100;

            dgvDevisListe.Columns[7].Visible = false;
            dgvDevisListe.Columns[7].HeaderText = "Centre Payeur";
            dgvDevisListe.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[7].Width = 100;

            dgvDevisListe.Columns[8].HeaderText = "Référence";
            dgvDevisListe.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[8].Width = 160;

            //dgvFactureListe.Columns[13].Visible = false;
            dgvDevisListe.Columns[9].HeaderText = " TTC (Dz)";
            dgvDevisListe.Columns[9].Width = 120;
            dgvDevisListe.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvFactureListe.Columns[1].Width = 120;

            //dgvFactureListe.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // dgvFactureListe.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvFactureListe.Columns[14].Visible = false;

            dgvDevisListe.Columns[10].HeaderText = "Date";
            dgvDevisListe.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevisListe.Columns[10].Width = 90;


        }
        public FormDevis()
        {
            InitializeComponent();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMoisAnnée.Checked)
            {
                cbxDate.Checked = false;
                DateDe.Enabled = false;
                DateA.Enabled = false;
                cmbxMois.Enabled = true;
                cmbxAnnee.Enabled = true;
            }
            else
            {
                cmbxMois.Enabled = false;
                cmbxAnnee.Enabled = false;
                ApplyFilters();
            }
        }

        private void cmbxMois_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbxAnnee_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void DateDe_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void DateA_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbxDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDate.Checked)
            {
                cbxMoisAnnée.Checked = false;
                cmbxAnnee.Enabled = false;
                cmbxMois.Enabled = false;
                DateDe.Enabled = true;
                DateA.Enabled = true;
            }
            else
            {
                DateDe.Enabled = false;
                DateA.Enabled = false;
                ApplyFilters();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("êtes-vous sûr de vouloir supprimer ce devis ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Devis.DeleteDevis(dgvDevisListe.CurrentRow.Cells[1].Value.ToString());

                if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, $"Supprimer le devis {dgvDevisListe.CurrentRow.Cells[1].Value.ToString()} du système", "Suppression"))
                {
                    MessageBox.Show("devis supprimée avec succès.");
                }
                ApplyFilters();
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            FormDevisDetails frmDetails = new FormDevisDetails(dgvDevisListe.CurrentRow.Cells[1].Value.ToString());
            frmDetails.ShowDialog();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            FormPatientDetails formPatientDetails = new FormPatientDetails(
                dgvDevisListe.CurrentRow.Cells[3].Value.ToString()
            );
            formPatientDetails.ShowDialog();
        }
        private void PrintDevisPDF(string numerodevis)
        {
            Devis devis = Devis.FindByNumeroDevis(numerodevis);
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
            string devis_date;
            if (devis.Date_Devis == new DateTime(1753, 1, 1))
            {
                devis_date = "";
            }
            else
            {
                devis_date = devis.Date_Devis.ToString("d");
            }

            string date_Nai_p, date_Nai_a;
            if (person.DateNaissance != DateTime.MinValue)
            {
                date_Nai_p = person.DateNaissance.ToString("d");
            }
            else
            {
                date_Nai_p = person.Année_Naissance;
            }

            if (personAssure.DateNaissance != DateTime.MinValue)
            {
                date_Nai_a = personAssure.DateNaissance.ToString("d");
            }
            else
            {
                date_Nai_a = personAssure.Année_Naissance;
            }

            document = PDFDevis.GenerateDocument(numerodevis,
               person.Nom,
               person.Prenom,
               date_Nai_p,
               personAssure.Nom,
               personAssure.Prenom,
               date_Nai_a,
               assure.NumeroAssurance,
               assure.CaisseNom,
               devis.Centre_Payeur,
               person.Adresse,
               person.Wilaya,
               person.Commune,
               produitsForPDF,
               devis.Montant_TTC.ToString(),
               devis_date);

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
        private void btnAjouteraugroup_Click(object sender, EventArgs e)
        {
            PrintDevisPDF(dgvDevisListe.CurrentRow.Cells[1].Value.ToString());
        }

        private void btnModifier_Click_1(object sender, EventArgs e)
        {
            FormModifierDevis formModifierDevis = new FormModifierDevis(
                dgvDevisListe.CurrentRow.Cells[1].Value.ToString()
            );
            formModifierDevis.ShowDialog();
            ApplyFilters();
        }

        private void tbxfacturesrecherche_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // prevents the "ding" sound
                ApplyFilters(); // or whatever method you want
            }
        }

        private void FormDevis_Load(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void tbxfacturesrecherche_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // prevents the "ding" sound
                ApplyFilters(); // or whatever method you want
            }
        }
    }
}
