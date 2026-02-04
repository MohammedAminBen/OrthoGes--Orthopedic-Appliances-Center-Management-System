using CodeSourceLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes_New_Version
{
    public partial class FormRecouvrementTotalHistorique : Form
    {
        public FormRecouvrementTotalHistorique()
        {
            InitializeComponent();
        }
        private void FilldgvHistorique()
        {
            DataTable dt = Financement.GetRecouvrementHistorique();
            if (dt.Rows.Count == 0) { return; }

            DataView dv = dt.DefaultView;
            dgvhistoriqueduRevenu.DataSource = dv;



            if (!dgvhistoriqueduRevenu.Columns.Contains("Tendance"))
            {
                DataGridViewImageColumn trendColumn = new DataGridViewImageColumn();
                trendColumn.Name = "Tendance";
                trendColumn.HeaderText = "Tendance";
                trendColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvhistoriqueduRevenu.Columns.Add(trendColumn);
                trendColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                trendColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            // STEP 2: Fill trend images after data is loaded
            for (int i = 0; i < dgvhistoriqueduRevenu.Rows.Count; i++)
            {
                // Skip the new row at the end (if enabled)
                if (dgvhistoriqueduRevenu.Rows[i].IsNewRow)
                    continue;

                if (i == 0)
                {
                    // First row → no previous value to compare
                    dgvhistoriqueduRevenu.Rows[i].Cells["Tendance"].Value = Properties.Resources.triangle;
                    continue;
                }

                try
                {
                    // Read "Somme" values from current and previous rows
                    decimal currentSomme = Convert.ToDecimal(dgvhistoriqueduRevenu.Rows[i].Cells["Somme"].Value);
                    decimal previousSomme = Convert.ToDecimal(dgvhistoriqueduRevenu.Rows[i - 1].Cells["Somme"].Value);

                    if (currentSomme > previousSomme)
                    {
                        dgvhistoriqueduRevenu.Rows[i].Cells["Tendance"].Value = Properties.Resources.triangle; // up icon
                    }
                    else if (currentSomme < previousSomme)
                    {
                        dgvhistoriqueduRevenu.Rows[i].Cells["Tendance"].Value = Properties.Resources.down__1_; // down icon
                    }
                    else
                    {
                        dgvhistoriqueduRevenu.Rows[i].Cells["Tendance"].Value = Properties.Resources.equal; // same icon
                    }
                }
                catch
                {
                    // Avoid crash in case of null or format issues
                    dgvhistoriqueduRevenu.Rows[i].Cells["Tendance"].Value = null;
                }
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRevenuEnseignant_Load(object sender, EventArgs e)
        {
            FilldgvHistorique();
        }
    }
}
