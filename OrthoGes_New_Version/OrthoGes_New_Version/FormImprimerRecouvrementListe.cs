//using CodeSourceLayer;
using CodeSourceLayer_;
using PDFTemplate;
using PDFTemplates;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
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
    public partial class FormImprimerRecouvrementListe : Form
    {
        private DataTable dtRecouvrementList;
        public FormImprimerRecouvrementListe()
        {
            InitializeComponent();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            Tache.CreateTache(tbxText.Text, "Manuel", DateTime.Now.Date, 0, 0);
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormImprimerRecouvrementListe_Load(object sender, EventArgs e)
        {

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
            }
        }

        private void cbxMoisAnnée_CheckedChanged(object sender, EventArgs e)
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
            }
        }

        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.MinValue, endDate = DateTime.MinValue;
            string etat = "";
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

                if ( moisFrancais.ContainsKey(mois) && int.TryParse(annee, out int year))
                {
                    int month = moisFrancais[mois];

                     startDate = new DateTime(year, month, 1);
                     endDate = startDate.AddMonths(1);
                }
            }
            if (cbxDate.Checked)
            {
                startDate = DateDe.Value.Date;
                endDate = DateA.Value.Date;
            }
            if (cmbxEtat.Text == "Non Payé") etat = "NON";
            else if (cmbxEtat.Text == "Payé") etat = "OUI";
            else if (cmbxEtat.Text == "Tous") etat = "TOUS";

            dtRecouvrementList = Recouvrement.GetRecouvrementsCompleteListe(startDate, endDate, etat);

            QuestPDF.Settings.License = LicenseType.Community;

            Document document = PDFRecouvrement.GenerateDocument(dtRecouvrementList,tbxText.Text);

            // ✅ Set save path
            string doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderPath = Path.Combine(doc, "OrthoGes Document\\Recouvrements");

            // Ensure the folder exists
            Directory.CreateDirectory(folderPath);

            string fileName = $"{tbxText.Text}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.pdf";
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
    }
}
