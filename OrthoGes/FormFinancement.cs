//using CodeSourceLayer;
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

namespace OrthoGes
{
    public partial class FormFinancement : Form
    {
        //FormFinancementEleves frmfinEleve;
        //FormFinancementEnseignant frmfinEnseignant;
        private GunaLineDataset cRevenu = new GunaLineDataset
        {
            Label = "Revenus Mensuels (DZD)",
            BorderColor = Color.CornflowerBlue,
            PointRadius = 4,
            BorderWidth = 2
        };
        private GunaLineDataset cRevenuPrevious = new GunaLineDataset
        {
            Label = "Revenus Mensuels Previous (DZD)",
            BorderColor = Color.Gainsboro,
            PointRadius = 4,
            BorderWidth = 2
        };
        public FormFinancement()
        {
            InitializeComponent();
        }
        public void RefreshData()
        {
            //lblTotal.Text = Financement.GetRevenuTotaleMensuelle().ToString();
            //lblEcole.Text = Financement.GetRevenuEcoleMensuelle().ToString();
            //lblEnseignants.Text = Financement.GetRevenuTotaleEnseignantMensuelle().ToString();
            FillChartWithData();
        }   
        private void FormFinancement_Load(object sender, EventArgs e)
        {
            //lblTotal.Text = Financement.GetRevenuTotaleMensuelle().ToString();
            //lblEcole.Text = Financement.GetRevenuEcoleMensuelle().ToString();
            //lblEnseignants.Text = Financement.GetRevenuTotaleEnseignantMensuelle().ToString();
            FillChartWithData();
        }

        private void btnfinEleve_Click(object sender, EventArgs e)
        {
            //if (frmfinEleve == null)
            //{
            //    frmfinEleve = new FormFinancementEleves();
            //    frmfinEleve.FormClosed += EleveForm_FormClosed;
            //    Form mainForm = Application.OpenForms["FormMain"];
            //    frmfinEleve.MdiParent = mainForm;
            //    frmfinEleve.Dock = DockStyle.Fill;
            //    frmfinEleve.Show();
            //}
            //else
            //{
            //    frmfinEleve.Activate();
            //}
        }
        private void EleveForm_FormClosed(object sender, EventArgs e)
        {
            //frmfinEleve = null;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private string GetCurrentSeason()
        {
            DateTime now = DateTime.Now;
            int year = now.Year;
            if (now.Month >= 8)
                return $"{year}/{year + 1}";
            else
                return $"{year - 1}/{year}";
        }
        private void FillChartWithData()
        {
        //    DataTable monthlyData = Financement.GetRevenuEcoleHistorique();

        //    string currentSeason = GetCurrentSeason();
        //    var culture = new CultureInfo("fr-FR");
        //    string[] months = new[] { "août", "septembre", "octobre", "novembre", "décembre", "janvier", "février", "mars", "avril", "mai", "juin", "juillet" };

        //    cRevenu.DataPoints.Clear();
        //    cRevenuPrevious.DataPoints.Clear();
        //    Dictionary<string, double> currentSeasonData = months.ToDictionary(m => m, m => 0.0);
        //    Dictionary<string, double> previousSeasonData = months.ToDictionary(m => m, m => 0.0);

        //    foreach (DataRow row in monthlyData.Rows)
        //    {
        //        string season = row["Season"].ToString();
        //        string month = row["Mois"].ToString();
        //        double revenue = Convert.ToDouble(row["Somme"]);

        //        if (season == currentSeason && currentSeasonData.ContainsKey(month))
        //        {
        //            currentSeasonData[month] = revenue;
        //        }
        //        else if (previousSeasonData.ContainsKey(month))
        //        {
        //            previousSeasonData[month] = revenue;
        //        }
        //    }

        //    foreach (var month in months)
        //    {
        //        cRevenu.DataPoints.Add(month, currentSeasonData[month]);
        //        cRevenuPrevious.DataPoints.Add(month, previousSeasonData[month]);
        //    }

        //    gunaChart1.Datasets.Clear();
        //    gunaChart1.Datasets.Add(cRevenu);
        //    gunaChart1.Datasets.Add(cRevenuPrevious);
        //    gunaChart1.Update();
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (frmfinEnseignant == null)
            //{
            //    frmfinEnseignant = new FormFinancementEnseignant();
            //    frmfinEnseignant    .FormClosed += EnseignantForm_FormClosed;
            //    Form mainForm = Application.OpenForms["FormMain"];
            //    frmfinEnseignant.MdiParent = mainForm;
            //    frmfinEnseignant.Dock = DockStyle.Fill;
            //    frmfinEnseignant.Show();
            //}
            //else
            //{
            //    frmfinEnseignant.Activate();
            //}
        }
        private void EnseignantForm_FormClosed(object sender, EventArgs e)
        {
            //frmfinEnseignant = null;
        }

        private void FormFinancement_LocationChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //FormRevenuTotaleHistorique formRevenuTotaleHistorique = new FormRevenuTotaleHistorique();
            //formRevenuTotaleHistorique.ShowDialog();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //FormRevenuEcoleHistorique form = new FormRevenuEcoleHistorique();
            //form.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //FormRevenuEnseignant form = new FormRevenuEnseignant();
            //form.ShowDialog();
        }
    }
}
