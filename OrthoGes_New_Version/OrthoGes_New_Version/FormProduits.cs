
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
    public partial class FormProduits : Form
    {
        public FormProduits()
        {
            InitializeComponent();
        }
        private void FillCmbxWithData()
        {
            cmbxCategory.Items.Clear();
            DataTable dtCategories = Produit.GetAllCategories();
            cmbxCategory.Items.Add("Tous");
            foreach (DataRow dr in dtCategories.Rows)
            {
                cmbxCategory.Items.Add(dr["Category_Nom"]);
            }
        }
        private void ApplyFilters()
        {
            DataTable dtProduitsListe = Produit.GetAllProduits();

            if (dtProduitsListe.Rows.Count == 0)
            {
                return;
            }

            List<string> filters = new List<string>();


            if (cmbxCategory.Text != "Tous" && cmbxCategory.Text != string.Empty)
            {
                filters.Add(
                    $"Category_Nom LIKE'%{cmbxCategory.Text}%'"
                );
            }
            /* ================= SEARCH FILTER ================= */

            string searchValue = tbxProduitrecherche.Text.Trim();
            string searchFilter = cmbxRecherche.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue) && searchValue != "Taper ici...")
            {
                if (searchFilter == "Désignation")
                    filters.Add($"Nom_Produit LIKE '%{searchValue}%'");
                else if (searchFilter == "Référence")
                    filters.Add($"Reference LIKE '%{searchValue}%'");
            }

            /* ================= APPLY FILTER ================= */

            DataView dv = dtProduitsListe.DefaultView;
            dv.RowFilter = filters.Count > 0 ? string.Join(" AND ", filters) : string.Empty;

            dgvProduitsListe.DataSource = dv;

            lblnmbrEleves.Text = dv.Count + "  Produits       ";

            dgvProduitsListe.Columns[1].HeaderText = "Référence";
            dgvProduitsListe.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[1].Width = 120;

            dgvProduitsListe.Columns[2].HeaderText = "Désignation";
            dgvProduitsListe.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[2].Width = 300;

            dgvProduitsListe.Columns[3].Visible = false;

            dgvProduitsListe.Columns[4].HeaderText = "Catégorie";
            dgvProduitsListe.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[4].Width = 250;

            dgvProduitsListe.Columns[5].HeaderText = "Tarif HT";
            dgvProduitsListe.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[5].Width = 150;

            dgvProduitsListe.Columns[6].HeaderText = "TVA %";
            dgvProduitsListe.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[6].Width = 100;

            dgvProduitsListe.Columns[7].HeaderText = "Tarif TTC";
            dgvProduitsListe.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduitsListe.Columns[7].Width = 150;

            dgvProduitsListe.Columns[8].Visible = false;
            //dgvProduitsListe.Columns[9].Visible = false;


        }

        private void FormFactures_Load(object sender, EventArgs e)
        {
            ApplyFilters();
            FillCmbxWithData();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnAjouterProduit_Click(object sender, EventArgs e)
        {
            FormAjouterProduit formAjouterProduit = new FormAjouterProduit();
            formAjouterProduit.ShowDialog();
            ApplyFilters();
        }
    }
}
