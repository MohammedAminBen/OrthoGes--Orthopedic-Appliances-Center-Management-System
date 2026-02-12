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

namespace OrthoGes_New_Version
{
    public partial class FormRecouvrement : Form
    {
        private DataTable dtFactureListe;
        public static List<(string Reference, string designation, string PUHT, string Quantity, string Montant_HT, string MontantTVA, string TVA)> produitsForPDF { get; set; } = new();

        public FormRecouvrement()
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
            dtFactureListe = Recouvrement.GetAll();

            if (dtFactureListe.Rows.Count == 0)
            {
                btnDetails.Enabled = false;
                dgvFactureListe.DataSource = null;
                return;
            }

            btnDetails.Enabled = true;

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
                        $"etat_Payement Like 'OUI' AND Payement_cheque Like 'OUI'"
                    );
                }
                else if (cmbxEtat.Text == "Payé sans chèque")
                {
                    filters.Add(
                        $"etat_Payement Like 'OUI' AND Payement_cheque Like 'NON'"
                    );
                }
                else if (cmbxEtat.Text == "Pas payé avec chèque")
                {
                    filters.Add(
                        $"etat_Payement Like 'NON' AND Payement_cheque Like 'OUI'"
                    );
                }
                else if (cmbxEtat.Text == "Pas payé sans chèque")
                {
                    filters.Add(
                        $"etat_Payement Like 'NON' AND Payement_cheque Like 'NON'"
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


            dgvFactureListe.Columns[1].HeaderText = "N°facture";
            dgvFactureListe.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[1].Width = 70;

            dgvFactureListe.Columns[2].HeaderText = "Date";
            dgvFactureListe.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[2].Width = 90;

            dgvFactureListe.Columns[3].HeaderText = "Patient";
            dgvFactureListe.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[3].Width = 140;


            dgvFactureListe.Columns[4].Visible = false;
            dgvFactureListe.Columns[4].HeaderText = "N°patient";
            dgvFactureListe.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[4].Width = 80;

            dgvFactureListe.Columns[5].Width = 120;
            dgvFactureListe.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvFactureListe.Columns[5].Visible = false;
            dgvFactureListe.Columns[6].HeaderText = "N°assurance";
            dgvFactureListe.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[6].Width = 100;

            //dgvFactureListe.Columns[7].Visible = false;
            dgvFactureListe.Columns[7].HeaderText = "Caisse";
            dgvFactureListe.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[7].Width = 100;

            //dgvFactureListe.Columns[8].Visible = false;
            dgvFactureListe.Columns[8].HeaderText = "Centre Payeur";
            dgvFactureListe.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[8].Width = 100;

            dgvFactureListe.Columns[9].HeaderText = "Référence";
            dgvFactureListe.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[9].Width = 160;

            //dgvFactureListe.Columns[13].Visible = false;
            dgvFactureListe.Columns[10].HeaderText = " TTC (Dz)";
            dgvFactureListe.Columns[10].Width = 120;
            dgvFactureListe.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvFactureListe.Columns[1].Width = 120;

            //dgvFactureListe.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // dgvFactureListe.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvFactureListe.Columns[14].Visible = false;



            dgvFactureListe.Columns[11].HeaderText = "Payé";
            dgvFactureListe.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[11].Width = 70;

            dgvFactureListe.Columns[12].HeaderText = "chèque";
            dgvFactureListe.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactureListe.Columns[12].Width = 70;


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
        private void cmbxEtat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void btnDetails_Click(object sender, EventArgs e)
        {
            FormFactureDetails frmDetails = new FormFactureDetails(dgvFactureListe.CurrentRow.Cells[1].Value.ToString());
            frmDetails.ShowDialog();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            FormPatientDetails formPatientDetails = new FormPatientDetails(
                dgvFactureListe.CurrentRow.Cells[4].Value.ToString()
            );
            formPatientDetails.ShowDialog();
        }
        private static readonly Font BoldFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold);

        private void dgvFactureListe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            string header = dgvFactureListe.Columns[e.ColumnIndex].HeaderText;
            string value = e.Value.ToString().Trim().ToUpper();

            // ===== PAYÉ COLUMN =====
            if (header == "Payé")
            {
                if (value == "OUI" || value == "1" || value == "TRUE")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.LimeGreen;
                    e.CellStyle.Font = BoldFont;
                }
                else if (value == "NON" || value == "0" || value == "FALSE")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                    e.CellStyle.Font = BoldFont;
                }
            }

            // ===== CHÈQUE COLUMN =====
            else if (header == "chèque")
            {
                if (value == "OUI" || value == "1" || value == "TRUE")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.LimeGreen;
                    e.CellStyle.Font = BoldFont;
                }
                else if (value == "NON" || value == "0" || value == "FALSE")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                    e.CellStyle.Font = BoldFont;
                }
            }
        }

        private void tbxfacturesrecherche_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // prevents the "ding" sound
                ApplyFilters(); // or whatever method you want
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            FormImprimerRecouvrementListe formImprimerRecouvrementListe = new FormImprimerRecouvrementListe();
            formImprimerRecouvrementListe.ShowDialog();
        }
    }
}
