//using CodeSourceLayer;
using CodeSource;
using CodeSourceLayer;
using SMS_UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes
{
    public partial class FormAccord : Form
    {
        private DataTable  dtEleveList;
        public FormAccord()
        {
          InitializeComponent();
            //InitializePlaceholder();
        }
        //private void InitializePlaceholder()
        //{
        //    tbxelevesrecherche.Text = "Taper ici...";
        //    tbxelevesrecherche.ForeColor = System.Drawing.Color.Gray;

        //    tbxelevesrecherche.Enter += tbxelevesrecherche_Enter;
        //    tbxelevesrecherche.Leave += tbxelevesrecherche_Leave;
        //}

        //private void Forméleves_Load(object sender, EventArgs e)
        //{
        //    FillNiveauAcademiqueInComboBox();
        //    ApplyFilters();
        //}
        //private void FillNiveauAcademiqueInComboBox()
        //{
        //    cmbxNiveau.Items.Clear();
        //    DataTable dtNiveaux = NiveauAcademique.GetAllNiveaux();
        //    cmbxNiveau.Items.Add("Tous");
        //    foreach (DataRow dr in dtNiveaux.Rows)
        //    {
        //        cmbxNiveau.Items.Add(dr["NiveauAcadémique"]);
        //    }
        //}
        //private void ApplyFilters()
        //{
        //    dtEleveList = Eleve.GetAllEleves();
        //    if (dtEleveList.Rows.Count == 0)
        //    {
        //        btnSupprimer.Enabled = false;
        //        btnModifier.Enabled = false;
        //        btnDetails.Enabled = false;
        //        btnAjouteraugroup.Enabled = false;
        //        return;
        //    }
        //    else
        //    {
        //        btnSupprimer.Enabled = true;
        //        btnModifier.Enabled = true;
        //        btnDetails.Enabled = true;
        //        btnAjouteraugroup.Enabled = true;
        //    }


        //    List<string> filters = new List<string>();

        //    // Niveau and Filiere filters
        //    string niveau = cmbxNiveau.Text.Trim();
        //    string filiere = cmbxFiliere.Text.Trim();
        //    if (!string.IsNullOrEmpty(niveau) && niveau!="Tous")
        //        filters.Add($"NiveauAcademique LIKE '%{niveau}%'");
        //    if (!string.IsNullOrEmpty(filiere) && filiere != "Tous")
        //        filters.Add($"NiveauAcademique LIKE '%{filiere}%'");

        //    // Search bar filters
        //    string searchValue = tbxelevesrecherche.Text.Trim();
        //    string searchFilter = cmbxRecherche.Text.Trim();
        //    if (!string.IsNullOrEmpty(searchValue) && searchValue != "Taper ici...")
        //    {
        //        if (searchFilter == "Nom Et Prénom")
        //            filters.Add($"NomEtPrenom LIKE '%{searchValue}%'");
        //        else if (searchFilter == "Identifiant")
        //            filters.Add($"EleveID LIKE '%{searchValue}%'");
        //    }

        //    // Combine all filters
        //    string filterString = string.Join(" AND ", filters);

        //    DataView dv = dtEleveList.DefaultView;
        //    dv.RowFilter = filterString;

        //    dgvElevesListe.DataSource = dv;
        //    dgvElevesListe.Columns[1].HeaderText = "Identifiant";
        //    dgvElevesListe.Columns[2].HeaderText = "Nom et Prénom";
        //    dgvElevesListe.Columns[3].HeaderText = "Niveau Académique";
        //    dgvElevesListe.Columns[4].HeaderText = "Contact (Téléphone/Email)";

        //    lblnmbrEleves.Text = dv.Count.ToString() + "  Élèves     ";
        //}


        //private void FiliereHandling(string Niveau)
        //{
        //    cmbxFiliere.Items.Clear();
        //    NiveauAcademique niveau = NiveauAcademique.Find(Niveau);

        //    DataTable dtFiliere = NiveauAcademique.GetAllFiliereDeNiveau(niveau.NiveauID);
        //    cmbxFiliere.Items.Add("Tous");
        //    foreach (DataRow dr in dtFiliere.Rows)
        //    {
        //        cmbxFiliere.Items.Add(dr["Filière"]);
        //    }
        //}

        //private void tbxelevesrecherche_Enter(object sender, EventArgs e)
        //{
        //    if (tbxelevesrecherche.Text == "Taper ici...")
        //    {
        //        tbxelevesrecherche.Text = "";
        //        tbxelevesrecherche.ForeColor = System.Drawing.Color.Black; // Change text color
        //    }
        //}

        //private void tbxelevesrecherche_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(tbxelevesrecherche.Text))
        //    {
        //        tbxelevesrecherche.Text = "Taper ici...";
        //        tbxelevesrecherche.ForeColor = System.Drawing.Color.Gray; 
        //    }
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    FormAjouterélevecs frmAjouterEleve = new FormAjouterélevecs();
        //    if (frmAjouterEleve.ShowDialog() == DialogResult.OK)
        //    {
        //        RefreshEleveList();
        //    }

        //}

        //private void dgvElevesListe_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    FormElevesDetails frmEleves = new FormElevesDetails(dgvElevesListe.CurrentRow.Cells[1].Value.ToString());
        //    frmEleves.Show();
        //    RefreshEleveList();
        //}

        //private void btnModifier_Click(object sender, EventArgs e)
        //{
        //    FormModiferElevesInfo formModiferElevesInfo = new FormModiferElevesInfo(dgvElevesListe.CurrentRow.Cells[1].Value.ToString());
        //    formModiferElevesInfo.ShowDialog();
        //    RefreshEleveList();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (Globale.utilisateurActuel.PrivPayementEleve)
        //    {
        //        FormElevesDetails frmEleves = new FormElevesDetails(dgvElevesListe.CurrentRow.Cells[1].Value.ToString());
        //        frmEleves.ShowDialog();
        //        RefreshEleveList();
        //    }
        //    else
        //    {
        //        FormEleveDetailsSansFin frmEleves = new FormEleveDetailsSansFin(dgvElevesListe.CurrentRow.Cells[1].Value.ToString());
        //        frmEleves.ShowDialog();
        //        RefreshEleveList();
        //    }
        //}

        //private void btnAjouteraugroup_Click(object sender, EventArgs e)
        //{
        //    var Form = new FormGroupeAffectation(dgvElevesListe.CurrentRow.Cells[1].Value.ToString());
        //    Form.ShowDialog();
        //    RefreshEleveList();
        //}

        //private void cmbxNiveau_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //        if (cmbxNiveau.SelectedItem != null)
        //        {
        //        if (cmbxNiveau.SelectedItem.ToString().Contains("Année Secondaire"))
        //        {
        //            cmbxFiliere.Visible = true;
        //            FiliereHandling(cmbxNiveau.SelectedItem.ToString());
        //        }
        //        else
        //        {
        //            cmbxFiliere.Items.Clear();
        //            cmbxFiliere.Visible = false;
        //        }
        //        }
        //        ApplyFilters();
        //}
        //private void cmbxRecherche_RightToLeftChanged(object sender, EventArgs e)
        //{

        //}

        //private void cmbxRecherche_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ApplyFilters();
        //}

        //private void guna2TileButton2_Click(object sender, EventArgs e)
        //{
        //    ApplyFilters();
        //}
        //private void RefreshEleveList()
        //{
        //    dtEleveList = Eleve.GetAllEleves();
        //    ApplyFilters();                     
        //}

        //private void cmbxFiliere_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ApplyFilters();
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{ 
        //    string DeletedEleveID = dgvElevesListe.CurrentRow.Cells[1].Value.ToString();
        //    int DeletedPersonID = Eleve.FindByEleveID(DeletedEleveID).PersonID;

        //    if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer l'étudiant [ " + dgvElevesListe.CurrentRow.Cells[1].Value.ToString()+" ]", "confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        if (Eleve.CheckifEleveHasDette(DeletedEleveID)) 
        //        {
        //            if (MessageBox.Show("Cet élève a des dettes à payer, êtes-vous sûr de le supprimer ?", "Des dettes sont détectées !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        //            {
        //                return;
        //            }
        //        }
        //            if (Eleve.DeleteEleve(DeletedEleveID))
        //            {
        //              if (Person.DeletePerson(DeletedPersonID))
        //              {
        //                if(Utilisateurs.AddActivité(Globale.utilisateurActuel.UtilisateurID, "Supprimer l'étudiant " + DeletedEleveID + " du système"))
        //                {
        //                    MessageBox.Show("étudiant supprimé avec succès.", "Succés", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    dtEleveList = Eleve.GetAllEleves();
        //                    dgvElevesListe.DataSource = dtEleveList;
        //                    lblnmbrEleves.Text = dgvElevesListe.Rows.Count.ToString() + " Élèves";
        //                    ApplyFilters();
        //                }
        //              }
        //              else { MessageBox.Show("L'étudiant n'a pas été supprimé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        //            }else MessageBox.Show("L'étudiant n'a pas été supprimé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    ApplyFilters();
        //}

        private void ApplyFilters()
        {
            DataTable dtAccordListe = Accord.GetAll();

            if (dtAccordListe.Rows.Count == 0)
            {
                btnSupprimer.Enabled = false;
                btnDetails.Enabled = false;
                btnAjouteraugroup.Enabled = false;
                dgvAccordListe.DataSource = null;
                return;
            }

            btnSupprimer.Enabled = true;
            btnDetails.Enabled = true;
            btnAjouteraugroup.Enabled = true;

            List<string> filters = new List<string>();

            if (cbxMoisAnnee.Checked)
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
                        $"Date_Accord >= #{startDate:MM/dd/yyyy}# AND Date_Accord < #{endDate:MM/dd/yyyy}#"
                    );
                }
                else if (annee != "Tous" && int.TryParse(annee, out year))
                {
                    DateTime startDate = new DateTime(year, 1, 1);
                    DateTime endDate = startDate.AddYears(1);

                    filters.Add(
                        $"Date_Accord >= #{startDate:MM/dd/yyyy}# AND Date_Accord < #{endDate:MM/dd/yyyy}#"
                    );
                }
            }
            if (cbxDate.Checked)
            {
                filters.Add(
                    $"Date_Accord >= #{DateDe.Value:MM/dd/yyyy}# AND Date_Accord < #{DateA.Value:MM/dd/yyyy}#"
                );
            }
            if (cmbxetat.Text != "Tous" && cmbxetat.Text != string.Empty)
            {
                filters.Add(
                    $"etat_Accord = '{cmbxetat.Text}'"
                );
            }
            /* ================= SEARCH FILTER ================= */

            string searchValue = tbxAccordsrecherche.Text.Trim();
            string searchFilter = cmbxRecherche.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue) && searchValue != "Taper ici...")
            {
                if (searchFilter == "Nom et Prénom")
                    filters.Add($"Patient LIKE '%{searchValue}%'");
                else if (searchFilter == "Numéro Patient")
                    filters.Add($"Numero_Patient LIKE '%{searchValue}%'");
            }

            /* ================= APPLY FILTER ================= */

            DataView dv = dtAccordListe.DefaultView;
            dv.RowFilter = filters.Count > 0 ? string.Join(" AND ", filters) : string.Empty;

            dgvAccordListe.DataSource = dv;
           
            lblnmbrEleves.Text = dv.Count + "  Accords       ";

            dgvAccordListe.Columns[1].Visible = false;

            dgvAccordListe.Columns[3].HeaderText = "Patient";
            //dgvAccordListe.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[3].Width = 160;


            //dgvAccordListe.Columns[3].Visible = false;
            dgvAccordListe.Columns[2].HeaderText = "N°patient";
            dgvAccordListe.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[2].Width = 100;

            dgvAccordListe.Columns[4].Width = 120;
            dgvAccordListe.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAccordListe.Columns[5].HeaderText = "N°assurance";
            dgvAccordListe.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[5].Width = 110;

            dgvAccordListe.Columns[6].HeaderText = "Caisse";
            dgvAccordListe.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[6].Width = 110;

            dgvAccordListe.Columns[7].HeaderText = "Référence";
            dgvAccordListe.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[7].Width = 110;

            //dgvAccordListe.Columns[9].Visible = false;
            dgvAccordListe.Columns[8].HeaderText = "Désignation";
            dgvAccordListe.Columns[8].Width = 230;

            dgvAccordListe.Columns[9].HeaderText = "Quantité";
            dgvAccordListe.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[9].Width = 80;

            dgvAccordListe.Columns[10].HeaderText = "Mésures";
            dgvAccordListe.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[10].Width = 110;

            dgvAccordListe.Columns[11].HeaderText = "Date";
            dgvAccordListe.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[11].Width = 100;

            dgvAccordListe.Columns[12].HeaderText = "etat";
            dgvAccordListe.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[12].Width = 100;
        }
        private void FormFactures_Load(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbxMois_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbxAnnee_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cbxMoisAnnee_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMoisAnnee.Checked)
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

        private void cbxDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDate.Checked)
            {
                cbxMoisAnnee.Checked = false;
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

        private void cmbxetat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            FormPatientDetails frmPatient = new FormPatientDetails(dgvAccordListe.CurrentRow.Cells[2].Value.ToString());
            frmPatient.ShowDialog();
        }

        private void btnAjouteraugroup_Click(object sender, EventArgs e)
        {
            FormModifierEtatAccord frmetat = new FormModifierEtatAccord((int)dgvAccordListe.CurrentRow.Cells[1].Value);
            frmetat.ShowDialog();
            ApplyFilters();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("êtes-vous sûr de vouloir supprimer ce accord ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Accord.DeleteAccord((int)dgvAccordListe.CurrentRow.Cells[1].Value);
                MessageBox.Show("Accord supprimé avec succès.");
                ApplyFilters();
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            FormAccordDetails frmAccordDetails = new FormAccordDetails((int)dgvAccordListe.CurrentRow.Cells[1].Value);
            frmAccordDetails.ShowDialog();
        }
    }
}
