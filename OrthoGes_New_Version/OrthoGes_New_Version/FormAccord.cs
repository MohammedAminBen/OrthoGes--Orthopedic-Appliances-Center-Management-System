
using CodeSourceLayer_;
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

namespace OrthoGes_New_Version
{
    public partial class FormAccord : Form
    {
        private DataTable dtEleveList;
        public FormAccord()
        {
            InitializeComponent();
        }
        private void checkPrivileges()
        {
            if (!Global.utilisateurActuel.PrivManipulationAccord)
            {
                btnSupprimer.Enabled = false;
                btnDetails.Enabled = false;
                btnModifierEtat.Enabled = false;
                btnPatientDetails.Enabled = false;
                btnModifier.Enabled = false;
            }
        }
        public void ApplyFilters()
        {
            DataTable dtAccordListe = Accord.GetAll();

            if (dtAccordListe.Rows.Count == 0)
            {
                btnSupprimer.Enabled = false;
                btnDetails.Enabled = false;
                btnModifierEtat.Enabled = false;
                btnPatientDetails.Enabled = false;
                btnModifier.Enabled = false;
                dgvAccordListe.DataSource = null;
                btnPatientDetails.Enabled = false;
                return;
            }

            btnSupprimer.Enabled = true;
            btnDetails.Enabled = true;
            btnModifierEtat.Enabled = true;
            btnPatientDetails.Enabled = true;
            btnModifierEtat.Enabled = true;

            checkPrivileges();

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
            dgvAccordListe.Columns[5].Width = 120;

            dgvAccordListe.Columns[6].Visible = false;
            dgvAccordListe.Columns[6].HeaderText = "Caisse";
            dgvAccordListe.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[6].Width = 100;

            dgvAccordListe.Columns[7].HeaderText = "Référence";
            dgvAccordListe.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[7].Width = 150;

            //dgvAccordListe.Columns[9].Visible = false;
            dgvAccordListe.Columns[8].HeaderText = "Description";
            dgvAccordListe.Columns[8].Width = 150;

            dgvAccordListe.Columns[9].HeaderText = "Quantité";
            dgvAccordListe.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[9].Width = 100;


            dgvAccordListe.Columns[10].HeaderText = "Date";
            dgvAccordListe.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[10].Width = 100;

            dgvAccordListe.Columns[11].HeaderText = "etat";
            dgvAccordListe.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccordListe.Columns[11].Width = 90;
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
                if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, $"Supprimer l'accord {(int)dgvAccordListe.CurrentRow.Cells[1].Value} du système", "Suppression"))
                {
                    MessageBox.Show("Accord supprimé avec succès.");
                    ApplyFilters();
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            FormAccordDetails frmAccordDetails = new FormAccordDetails((int)dgvAccordListe.CurrentRow.Cells[1].Value);
            frmAccordDetails.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormModifierAccord frmModifierAccord = new FormModifierAccord((int)dgvAccordListe.CurrentRow.Cells[1].Value);
            frmModifierAccord.ShowDialog();
            ApplyFilters();
        }

        private void tbxAccordsrecherche_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // prevents the "ding" sound
                ApplyFilters(); // or whatever method you want
            }
        }
    }
}
