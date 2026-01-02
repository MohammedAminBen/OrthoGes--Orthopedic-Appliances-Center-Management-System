using CodeSourceLayer;
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

namespace OrthoGes
{
    public partial class FormFactures : Form
    {
        private DataTable dtFactureListe;
        public FormFactures()
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
        public void ApplyFilters()
        {
            dtFactureListe = Facture.GetAll();

            if (dtFactureListe.Rows.Count == 0)
            {
                btnSupprimer.Enabled = false;
                btnDetails.Enabled = false;
                btnAjouteraugroup.Enabled = false;
                dgvFactureListe.DataSource = null;
                return;
            }

            btnSupprimer.Enabled = true;
            btnDetails.Enabled = true;
            btnAjouteraugroup.Enabled = true;

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
                        $"Date_Facture >= #{startDate:MM/dd/yyyy}# AND Date_Facture < #{endDate:MM/dd/yyyy}#"
                    );
                }
                else if (annee != "Tous" && int.TryParse(annee, out year))
                {
                    DateTime startDate = new DateTime(year, 1, 1);
                    DateTime endDate = startDate.AddYears(1);

                    filters.Add(
                        $"Date_Facture >= #{startDate:MM/dd/yyyy}# AND Date_Facture < #{endDate:MM/dd/yyyy}#"
                    );
                }
            }
            if (cbxDate.Checked)
            {
                filters.Add(
                    $"Date_Facture >= #{DateDe.Value:MM/dd/yyyy}# AND Date_Facture < #{DateA.Value:MM/dd/yyyy}#"
                );  
            }
            if (cmbxEtat.Text != "Tous" && cmbxEtat.Text != string.Empty)
            {
                if (cmbxEtat.Text == "Payé avec chèque")
                {
                    filters.Add(
                        $"etat_Payement = 1 AND Payement_cheque = 1"
                    );
                }
                else if (cmbxEtat.Text == "Payé sans chèque")
                {
                    filters.Add(
                        $"etat_Payement = 1 AND Payement_cheque = 0"
                    );
                }
                else if (cmbxEtat.Text == "Pas payé avec chèque")
                {
                    filters.Add(
                        $"etat_Payement = 0 AND Payement_cheque = 1"
                    );
                }
                else if (cmbxEtat.Text == "Pas payé sans chèque")
                {
                    filters.Add(
                        $"etat_Payement = 0 AND Payement_cheque = 0"
                    );
                }
            }

            /* ================= SEARCH FILTER ================= */

            string searchValue = tbxfacturesrecherche.Text.Trim();
            string searchFilter = cmbxRecherche.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue) && searchValue != "Taper ici...")
            {
                if (searchFilter == "Nom et Prénom")
                    filters.Add($"Patient LIKE '%{searchValue}%'");
                else if (searchFilter == "Numéro Facture")
                    filters.Add($"Numero_Facture LIKE '%{searchValue}%'");
            }

            /* ================= APPLY FILTER ================= */

            DataView dv = dtFactureListe.DefaultView;
            dv.RowFilter = filters.Count > 0 ? string.Join(" AND ", filters) : string.Empty;

            dgvFactureListe.AutoGenerateColumns = true;
            dgvFactureListe.DataSource = dv;

            SetupCheckBoxColumns();
            lblnmbrEleves.Text = dv.Count + "  Factures       ";


            dgvFactureListe.Columns[1].HeaderText = "N°facture";
            dgvFactureListe.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvFactureListe.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[1].Width = 60;

            dgvFactureListe.Columns[2].HeaderText = "Patient";
            //dgvFactureListe.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[2].Width = 120;


            //dgvFactureListe.Columns[3].Visible = false;
            dgvFactureListe.Columns[3].HeaderText = "N°patient";
            dgvFactureListe.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[3].Width = 80;

            dgvFactureListe.Columns[4].Width = 120;
            dgvFactureListe.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvFactureListe.Columns[5].Visible = false;
            dgvFactureListe.Columns[5].HeaderText = "N°assurance";
            dgvFactureListe.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[5].Width = 100;

            dgvFactureListe.Columns[6].Visible = false;
            dgvFactureListe.Columns[6].HeaderText = "Caisse";
            dgvFactureListe.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[6].Width = 100;

            dgvFactureListe.Columns[7].Visible = false;
            dgvFactureListe.Columns[7].HeaderText = "Centre Pay";
            dgvFactureListe.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[7].Width = 100;

            dgvFactureListe.Columns[8].HeaderText = "Référence";
            dgvFactureListe.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[8].Width = 110;

            //dgvFactureListe.Columns[9].Visible = false;
            dgvFactureListe.Columns[9].HeaderText = "Désignation";
            dgvFactureListe.Columns[9].Width = 200;

            dgvFactureListe.Columns[10].HeaderText = "   Montant HT";
            dgvFactureListe.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[10].Width = 100;

            dgvFactureListe.Columns[11].HeaderText = "QTE";
            dgvFactureListe.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[11].Width = 40;

            dgvFactureListe.Columns[12].HeaderText = "TVA%";
            dgvFactureListe.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[12].Width = 50;

            dgvFactureListe.Columns[13].Visible = false;
            dgvFactureListe.Columns[14].HeaderText = " TTC(Dz)";
            dgvFactureListe.Columns[14].Width = 120;
            dgvFactureListe.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvFactureListe.Columns[1].Width = 120;

            //dgvFactureListe.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvFactureListe.Columns[14].Visible = false;

            dgvFactureListe.Columns[15].HeaderText = "Date";
            dgvFactureListe.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[15].Width = 90;

            dgvFactureListe.Columns[16].HeaderText = "Payé";
            dgvFactureListe.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[16].Width = 60;

            dgvFactureListe.Columns[17].HeaderText = "chèque";
            dgvFactureListe.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[17].Width = 60;


        }
        private void SetupCheckBoxColumns()
        {
            // Prevent duplicate columns
            if (dgvFactureListe.Columns.Contains("etat_Payement"))
                dgvFactureListe.Columns.Remove("etat_Payement");

            if (dgvFactureListe.Columns.Contains("Payement_cheque"))
                dgvFactureListe.Columns.Remove("Payement_cheque");

            // ===== Payment status checkbox =====
            DataGridViewCheckBoxColumn colPayement = new DataGridViewCheckBoxColumn();
            colPayement.Name = "etat_Payement";
            colPayement.HeaderText = "Payée";
            colPayement.DataPropertyName = "etat_Payement";
            colPayement.TrueValue = 1;
            colPayement.FalseValue = 0;
            colPayement.IndeterminateValue = 0;
            colPayement.ReadOnly = false; // change to true if display only

            // ===== Cheque payment checkbox =====
            DataGridViewCheckBoxColumn colCheque = new DataGridViewCheckBoxColumn();
            colCheque.Name = "Payement_cheque";
            colCheque.HeaderText = "Chèque";
            colCheque.DataPropertyName = "Payement_cheque";
            colCheque.TrueValue = 1;
            colCheque.FalseValue = 0;
            colCheque.IndeterminateValue = 0;
            colCheque.ReadOnly = false; // change to true if display only

            dgvFactureListe.Columns.Add(colPayement);
            dgvFactureListe.Columns.Add(colCheque);
        }
            

        private void FormFactures_Load(object sender, EventArgs e)
        {
            ApplyFilters();
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
                cmbxAnnee.Enabled = false ;
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

        private void dgvFactureListe_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // skip header

            var row = dgvFactureListe.Rows[e.RowIndex];

            // Example for Payment status
            if (dgvFactureListe.Columns[e.ColumnIndex].Name == "etat_Payement")
            {
                string numeroFacture = row.Cells["Numero_Facture"].Value.ToString();
                bool isPaid = Convert.ToBoolean(row.Cells["etat_Payement"].Value);

                // Update database
                if(!Facture.UpdateEtatPayement(numeroFacture, isPaid ? 1 : 0))
                {
                
                    MessageBox.Show("Échec de la mise à jour du statut de paiement.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Example for Cheque payment
            if (dgvFactureListe.Columns[e.ColumnIndex].Name == "Payement_cheque")
            {
                string numeroFacture = row.Cells["Numero_Facture"].Value.ToString();
                bool isCheque = Convert.ToBoolean(row.Cells["Payement_cheque"].Value);

                // Update database
                if(!Facture.UpdatePayementCheque(numeroFacture,isCheque? 1 : 0))
                {
                     MessageBox.Show("Échec de la mise à jour du statut de paiement par chèque.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbxEtat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("êtes-vous sûr de vouloir supprimer cette facture ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Facture.DeleteFacture(dgvFactureListe.CurrentRow.Cells[1].Value.ToString());
                MessageBox.Show("Facture supprimée avec succès.");
                ApplyFilters();
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            FormFactureDetails frmDetails = new FormFactureDetails(dgvFactureListe.CurrentRow.Cells[1].Value.ToString());
            frmDetails.ShowDialog();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            FormPatientDetails formPatientDetails = new FormPatientDetails(
                dgvFactureListe.CurrentRow.Cells[3].Value.ToString()
            );
            formPatientDetails.ShowDialog();
        }
    }
}
