using CodeSourceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes
{
    public partial class FormPatients : Form
    {
        private DataTable dtPatientList;
        public FormPatients()
        {
            InitializeComponent();
            InitializePlaceholder();
        }

        private void btnAjouterPatient_Click(object sender, EventArgs e)
        {
            FormAjouterPatient frmAjouterPatient = new FormAjouterPatient();
            frmAjouterPatient.ShowDialog();
            ApplyFilters();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            FormPatientDetails frmPatientDetails = new FormPatientDetails(dgvPatientsListe.CurrentRow.Cells[1].Value.ToString());
            frmPatientDetails.ShowDialog();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            FormModifierPatient frmModifierPatient = new FormModifierPatient(dgvPatientsListe.CurrentRow.Cells[1].Value.ToString());
            frmModifierPatient.ShowDialog();
            ApplyFilters();
        }
        private void InitializePlaceholder()
        {
            tbxRecherche.Text = "Taper ici...";
            tbxRecherche.ForeColor = System.Drawing.Color.Gray;

            tbxRecherche.Enter += tbxRecherche_Enter;
            tbxRecherche.Leave += tbxRecherche_Leave;
        }

        private void tbxRecherche_Enter(object sender, EventArgs e)
        {
            if (tbxRecherche.Text == "Taper ici...")
            {
                tbxRecherche.Text = "";
                tbxRecherche.ForeColor = System.Drawing.Color.Black; // Change text color
            }
        }

        private void tbxRecherche_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxRecherche.Text))
            {
                tbxRecherche.Text = "Taper ici...";
                tbxRecherche.ForeColor = System.Drawing.Color.Gray; // Set text to gray
            }
        }
        private void ApplyFilters()
        {
            dtPatientList = Patient.GetAllPatients();
            if (dtPatientList.Rows.Count == 0)
            {

                btnSupprimer.Enabled = false;
                btnModifier.Enabled = false;
                btnDetails.Enabled = false;
                return;
            }
            else
            {
                btnSupprimer.Enabled = true;
                btnModifier.Enabled = true;
                btnDetails.Enabled = true;
            }

            List<string> filters = new List<string>();

                // Search bar filters
                string searchValue = tbxRecherche.Text.Trim();
            string searchFilter = cmbxRecherche.Text.Trim();
            if (!string.IsNullOrEmpty(searchValue) && searchValue != "Taper ici...")
            {
                if (searchFilter == "Nom et Prénom")
                    filters.Add($"Nom_et_Prenom LIKE '%{searchValue}%'");
                else if (searchFilter == "Numéro Patient")
                    filters.Add($"Numero_Patient LIKE '%{searchValue}%'");
            }

            // Combine all filters
            string filterString = string.Join(" AND ", filters);

            DataView dv = dtPatientList.DefaultView;
            dv.RowFilter = filterString;

            dgvPatientsListe.DataSource = dv;
            dgvPatientsListe.Columns[1].HeaderText = "  Numéro patient";
            dgvPatientsListe.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[1].Width = 50;

            dgvPatientsListe.Columns[2].HeaderText = "Nom et prénom";
            dgvPatientsListe.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[2].Width = 120;

            dgvPatientsListe.Columns[3].HeaderText = " Date de naissance";
            dgvPatientsListe.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[3].Width = 70;

            dgvPatientsListe.Columns[4].HeaderText = " Téléphone";
            dgvPatientsListe.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[4].Width = 100;

            dgvPatientsListe.Columns[5].HeaderText = " Numéro d'assurance";
            dgvPatientsListe.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[5].Width = 90;

            dgvPatientsListe.Columns[6].HeaderText = " Caisse";
            dgvPatientsListe.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatientsListe.Columns[6].Width = 80;
            lblnmbrEnseignants.Text = dgvPatientsListe.Rows.Count.ToString() + "  Patients       ";
        }

        private void FormPatients_Load(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dgvPatientsListe_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormPatientDetails frmPatientDetails = new FormPatientDetails(dgvPatientsListe.CurrentRow.Cells[1].Value.ToString());
            frmPatientDetails.ShowDialog();
        }

        private void btnCreationDevis_Click(object sender, EventArgs e)
        {
            FormCreationDevis frmDevis = new FormCreationDevis(dgvPatientsListe.CurrentRow.Cells[1].Value.ToString());
            frmDevis.ShowDialog();
        }

        private void btnCreationFacture_Click(object sender, EventArgs e)
        {
            FormCreationFacture frmFacture = new FormCreationFacture(dgvPatientsListe.CurrentRow.Cells[1].Value.ToString());
            frmFacture.ShowDialog();
        }

        private void btnCreationBonLiv_Click(object sender, EventArgs e)
        {
            FormCreationBonLiv frmBonLiv = new FormCreationBonLiv(dgvPatientsListe.CurrentRow.Cells[1].Value.ToString());
            frmBonLiv.ShowDialog();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("êtes-vous sûr de vouloir supprimer ce patient ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Patient.DeletePatient(dgvPatientsListe.CurrentRow.Cells[1].Value.ToString());
                MessageBox.Show("Patient supprimé avec succès.");
                ApplyFilters();
            }
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (Globale.utilisateurActuel.PrivPayementEns == false)
        //    {
        //        FormEnseignantDetailsSansFin formEnseignantDetailsSansFin = new FormEnseignantDetailsSansFin(dgvEnseignantsListe.CurrentRow.Cells[1].Value.ToString());
        //        formEnseignantDetailsSansFin.ShowDialog();
        //        ApplyFilters();
        //    }
        //    else
        //    {
        //        FormEnseignantDetails frmEnseignantDetails = new FormEnseignantDetails(dgvEnseignantsListe.CurrentRow.Cells[1].Value.ToString());
        //        frmEnseignantDetails.ShowDialog();
        //        ApplyFilters();
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    FormAjouterEnseignant frmAjouterEnseignant = new FormAjouterEnseignant();
        //    if (frmAjouterEnseignant.ShowDialog() == DialogResult.OK)
        //    {
        //        RefreshEleveList();
        //    }
        //}

        //private void btnAffecterauGroup_Click(object sender, EventArgs e)
        //{
        //    var form = new FormGroupeAffectationEnseignant(dgvEnseignantsListe.CurrentRow.Cells[1].Value.ToString());
        //    form.ShowDialog();
        //    ApplyFilters();
        //}

        //private void btnSupprimer_Click(object sender, EventArgs e)
        //{
        //    string DeletedEnseignantID = dgvEnseignantsListe.CurrentRow.Cells[1].Value.ToString();
        //    int DeletedPersonID = Enseignant.FindByEnseignantID(DeletedEnseignantID).PersonID;

        //    if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer l'enseignant [ " + dgvEnseignantsListe.CurrentRow.Cells[1].Value.ToString() + " ]", "confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        if (Enseignant.checkifEnseignantHasUnpayedSalaire(DeletedEnseignantID))
        //        {
        //            if (MessageBox.Show("ce enseignant a des salaires impayés, êtes-vous sûr de vouloir le supprimer ? ?", "Impayés salaires sont détectées !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        //            {
        //                return;
        //            }
        //        }
        //        if (Enseignant.DeleteEnseignant(DeletedEnseignantID))
        //        {
        //            if (Person.DeletePerson(DeletedPersonID))
        //            {
        //                if(Utilisateurs.AddActivité(Globale.utilisateurActuel.UtilisateurID, "Supprimer l'enseignant " + DeletedEnseignantID + " du système"))
        //                {
        //                    MessageBox.Show("Enseignant supprimé avec succès.", "Succés", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    dtEnseignantList = Enseignant.GetAllEnseignants();
        //                    dgvEnseignantsListe.DataSource = dtEnseignantList;
        //                    lblnmbrEnseignants.Text = dgvEnseignantsListe.Rows.Count.ToString() + " Enseignants";
        //                    ApplyFilters();
        //                }

        //            }
        //            else { MessageBox.Show("L'enseignant n'a pas été supprimé.", "Succés", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        //        }
        //        else MessageBox.Show("L'enseignant n'a pas été suppriméeee.", "Succés", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    ApplyFilters();
        //}

        //private void guna2TileButton2_Click(object sender, EventArgs e)
        //{
        //    ApplyFilters();
        //}

    }
}
