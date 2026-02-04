using CodeSourceLayer_;
using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes_New_Version
{
    public partial class FormFinancement : Form
    {
        FormRecouvrement frmRC = null;
        private GunaLineDataset cRevenu = new GunaLineDataset
        {
            Label = "Recouvrement Total Mensuels (DZD)",
            BorderColor = Color.CornflowerBlue,
            PointRadius = 3,
            BorderWidth = 2
        };
        private GunaLineDataset cRevenuReel = new GunaLineDataset
        {
            Label = "Recouvrement Réel Monsuels (DZD)",
            BorderColor = Color.Lime,
            PointRadius = 3,
            BorderWidth = 2
        };
        private GunaLineDataset cResterImpayee = new GunaLineDataset
        {
            Label = "Rester Impayée Monsuels (DZD)",
            BorderColor = Color.Red,
            PointRadius = 3,
            BorderWidth = 2
        };
        public FormFinancement()
        {
            InitializeComponent();
        }
        private void FillChartWithData()
        {
            DataTable monthlyData = Financement.GetRecouvrementHistorique();
            DataTable RevenuReel = Financement.GetRecouvrementReelHistorique();
            DataTable ResterImpayee = Financement.GetResterImpayerHistorique();

            var culture = new CultureInfo("fr-FR");
            string[] months = new[] { "janvier", "février", "mars", "avril", "mai", "juin", "juillet", "août", "septembre", "octobre", "novembre", "décembre", };

            cRevenu.DataPoints.Clear();
            cRevenuReel.DataPoints.Clear();
            cResterImpayee.DataPoints.Clear();
            Dictionary<string, double> currentSeasonData = months.ToDictionary(m => m, m => 0.0);

            foreach (DataRow row in monthlyData.Rows)
            {
                string month = row["Mois"].ToString();
                double revenue = Convert.ToDouble(row["Somme"]);

                currentSeasonData[month] = revenue;
            }

            foreach (var month in months)
            {
                cRevenu.DataPoints.Add(month, currentSeasonData[month]);
            }

            foreach (DataRow row in RevenuReel.Rows)
            {
                string month = row["Mois"].ToString();
                double revenue = Convert.ToDouble(row["Somme"]);

                currentSeasonData[month] = revenue;
            }

            foreach (var month in months)
            {
                cRevenuReel.DataPoints.Add(month, currentSeasonData[month]);
            }

            foreach (DataRow row in ResterImpayee.Rows)
            {
                string month = row["Mois"].ToString();
                double revenue = Convert.ToDouble(row["Somme"]);

                currentSeasonData[month] = revenue;
            }

            foreach (var month in months)
            {
                cResterImpayee.DataPoints.Add(month, currentSeasonData[month]);
            }

            chart.Datasets.Clear();
            chart.Datasets.Add(cRevenu);
            chart.Datasets.Add(cRevenuReel);
            chart.Datasets.Add(cResterImpayee);
            chart.Update();
        }
        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        public void LoadFinancementData()
        {
            lblTotal.Text = Financement.GetRevenuTotalMensuelle().ToString();
            lblRecouvrementReel.Text = Financement.GetRevouvrementReelMensuelle().ToString();
            lblResterImapyee.Text = Financement.GetResterImpayeeMensuelle().ToString();
            FillChartWithData();
        }
        private void FormFinancement_Load_1(object sender, EventArgs e)
        {
            LoadFinancementData();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            FormRecouvrementTotalHistorique frm = new FormRecouvrementTotalHistorique();
            frm.ShowDialog();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            FormRecouvrementRéelHistorique frm = new FormRecouvrementRéelHistorique();
            frm.ShowDialog();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            FormResterImpayéeHistorique frm = new FormResterImpayéeHistorique();
            frm.ShowDialog();
        }

        private void btnfinEleve_Click(object sender, EventArgs e)
        {
            if (frmRC == null)
            {
                frmRC = new FormRecouvrement();
                frmRC.FormClosed += RecouvrementForm_FormClosed;
                Form mainForm = Application.OpenForms["FormMain"];
                frmRC.MdiParent = mainForm;
                frmRC.Dock = DockStyle.Fill;
                frmRC.Show();
            }
            else
            {
                frmRC.Activate();
                frmRC.ApplyFilters();
            }
        }
        private void RecouvrementForm_FormClosed(object sender, EventArgs e)
        {
            frmRC = null;
        }
    }
}
