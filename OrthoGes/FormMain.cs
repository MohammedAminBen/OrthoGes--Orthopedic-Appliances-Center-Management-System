//using CodeSourceLayer;
//using DataLayer;
using Guna.UI2.WinForms;
//using PDFTemplates;
//using QuestPDF.Companion;
//using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrthoGes
{
    public partial class FormMain : Form
    {

        private Form activeForm = null;
        FormSeConnecter frmConnection;
        FormPatients frmPatients;
        FormFactures frmFactures;
        FormAccord frmAccords;
        FormProduits frmProduits;
        FormTabDeBord frmTabDeBord;
        FormFinancement frmFinancement;


        public FormMain()
        {//FormSeConnecter frm
            InitializeComponent();
            RemoveMDIBorder();
            //frmConnection = frm;


        }

        private void PnlButton_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;

            // Reset all button styles
            foreach (Control ctrl in pnlSideBar.Controls)
            {
                if (ctrl is Guna2Button btn)
                {
                    btn.FillColor = Color.White;
                    btn.ForeColor = Color.FromArgb(60, 75, 94);
                    btn.Font = new Font(btn.Font, FontStyle.Regular);
                }
            }

            // Highlight the clicked button
            clickedButton.FillColor = Color.CornflowerBlue;
            clickedButton.ForeColor = Color.White;
            clickedButton.Font = new Font(clickedButton.Font, FontStyle.Bold);

            // Open corresponding form using the Tag


            switch (clickedButton.Tag?.ToString())
            {
                case "tabdebord":
                    btnTabDeBoardHandling();
                    break;
                case "patients":
                    btnPatientsHandling();
                    break;
                case "factures":
                    btnFacturesHandling();
                    break;
                case "accords":
                    btnAccordsHandling();
                    break;
                case "produits":
                    btnProduitsHandling();
                    break;
                case "financement":
                    btnFinancementHandling();
                    break;
                    //case "utilisateurs":
                    //    btnUtilisateursHandling();
                    //    break;
                    //case "activite":
                    //    btnActiviteHandling();
                    //    break;
                    //case "participants":
                    //    btnParticipantsHandling();
                    //    break;
                    // Add others as needed
            }

        }

        private void RemoveMDIBorder()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient mdiClient)
                {
                    // Change the MDI Client background to match the form
                    mdiClient.BackColor = this.BackColor;

                    // Remove border using Windows API
                    int style = GetWindowLong(mdiClient.Handle, GWL_EXSTYLE);
                    SetWindowLong(mdiClient.Handle, GWL_EXSTYLE, style & ~WS_EX_CLIENTEDGE);

                    // Force redraw to apply changes
                    mdiClient.Invalidate();
                }
            }
        }
        // Import Windows API functions
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_CLIENTEDGE = 0x200;

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        private void Form1_Load(object sender, EventArgs e)
        {
            //InisialzeFinancement();
            btntab.ImageSize = new Size(45, 45);
            btnpatient.ImageSize = new Size(45, 45);
            btnfacture.ImageSize = new Size(45, 45);
            btnfin.ImageSize = new Size(45, 45);
            btnaccord.ImageSize = new Size(45, 45);
            btnUti.ImageSize = new Size(45, 45);
            btnGestionCabinet.ImageSize = new Size(45, 45);
            PnlButton_Click(btntab, EventArgs.Empty);
           // fillpnlUserData();
            //CheckPrivileges();
        }
        //private void CheckPrivileges()
        //{
        //    if (!Globale.utilisateurActuel.IsAdmin)
        //    {
        //        btnMonEcole.Visible = false;
        //        btnUti.Visible = false;
        //    }
        //    if (!Globale.utilisateurActuel.PrivEnsData)
        //    {
        //        btnfacture.Visible = false;
        //        btnaccord.Location = new Point(7, 282);
        //        btnfor.Location = new Point(7, 342);
        //        btnfin.Location = new Point(7, 402);
        //    }
        //    if (!Globale.utilisateurActuel.PrivFinancement)
        //    {
        //        btnfin.Visible = false;
        //    }
        //}
        //private void InisialzeFinancement()
        //{
        //    bool firsttime = false;
        //    DataTable dtcheck = Financement.GetRevenuTotaleHistorique();
        //    if (dtcheck.Rows.Count == 0) { firsttime = true; }

        //    DateTime? lastInit = Globale.ecole.date;
        //    DateTime now = DateTime.Now;
        //    DateTime thisMonth = new DateTime(now.Year, now.Month, 1);

        //    if (!firsttime && lastInit.HasValue && lastInit.Value.Year == now.Year && lastInit.Value.Month == now.Month)
        //        return;

        //    DateTime datedebut = thisMonth;
        //    DateTime datefin = thisMonth.AddMonths(1).AddDays(-1);

        //    if (!Financement.CheckifRevenuAlreadyInserted())
        //    {
        //        Financement.AddNewRevenuMonsuelle(datedebut, datefin);
        //    }

        //    if (!Financement.CheckifRevenuEcoleAlreadyInserted())
        //    {
        //        Financement.AddNewRevenuEcoleMonsuelle(datedebut, datefin);
        //    }

        //    if (!Financement.CheckifRevenuEnseignantAlreadyInserted())
        //    {
        //        DataTable dt = Enseignant.GetAllEnseignantsForFinancement();

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            bool payementparcycle = Convert.ToBoolean(dr["PayementParCycleDeSeance"]);
        //            if (payementparcycle) continue;

        //            string enseignantID = dr["EnseignantID"].ToString();
        //            int pourcentage = Convert.ToInt32(dr["PourcentagePay"]);

        //            Financement.AddNewRevenuEnseignantMonsuelle(enseignantID, pourcentage, datedebut, datefin);
        //        }
        //    }

        //    MonEcole.UpdateLastDate(thisMonth); // <-- implement in DB
        //}


        public void btnPatientsHandling()
        {
            if (frmPatients == null)
            {
                frmPatients = new FormPatients();
                frmPatients.FormClosed += Patients_FormClosed;
                frmPatients.MdiParent = this;
                frmPatients.Dock = DockStyle.Fill;
                frmPatients.Show();
            }
            else
            {
                frmPatients.Activate();
            }
        }
        private void Patients_FormClosed(object sender, EventArgs e)
        {
            frmPatients = null;
        }

        //private void btnUtilisateursHandling()
        //{
        //    if (frmUtilisateurs == null)
        //    {
        //        frmUtilisateurs = new FormUtilisateurs();
        //        frmUtilisateurs.FormClosed += Utilisateurs_FormClosed;
        //        frmUtilisateurs.MdiParent = this;
        //        frmUtilisateurs.Dock = DockStyle.Fill;
        //        frmUtilisateurs.Show();
        //    }
        //    else
        //    {
        //        frmUtilisateurs.Activate();
        //    }
        //}
        //private void Utilisateurs_FormClosed(object sender, EventArgs e)
        //{
        //    frmUtilisateurs = null;
        //}
        private void btnFinancementHandling()
        {
            if (frmFinancement == null)
            {
                frmFinancement = new FormFinancement();
                frmFinancement.FormClosed += Financement_FormClosed;
                frmFinancement.MdiParent = this;
                frmFinancement.Dock = DockStyle.Fill;
                frmFinancement.Show();
            }
            else
            {
                frmFinancement.Activate();
                frmFinancement.RefreshData();
            }
        }
        private void Financement_FormClosed(object sender, EventArgs e)
        {
            frmFinancement = null;
        }
        public void btnFacturesHandling()
        {
            if (frmFactures == null)
            {
                frmFactures = new FormFactures();
                frmFactures.FormClosed += Factures_FormClosed;
                frmFactures.MdiParent = this;
                frmFactures.Dock = DockStyle.Fill;
                frmFactures.Show();
            }
            else
            {
                frmFactures.Activate();
            }
        }
        private void Factures_FormClosed(object sender, EventArgs e)
        {
            frmFactures = null;
        }
        public void btnAccordsHandling()
        {
            if (frmAccords == null)
            {
                frmAccords = new FormAccord();
                frmAccords.FormClosed += Accords_FormClosed;
                frmAccords.MdiParent = this;
                frmAccords.Dock = DockStyle.Fill;
                frmAccords.Show();
            }
            else
            {
                frmAccords.Activate();
            }
        }

        private void Accords_FormClosed(object sender, EventArgs e)
        {
           frmAccords = null;
        }
        public void btnProduitsHandling()
        {
            if (frmProduits == null)
            {
                frmProduits = new FormProduits();
                frmProduits.FormClosed += Produits_FormClosed;
                frmProduits.MdiParent = this;
                frmProduits.Dock = DockStyle.Fill;
                frmProduits.Show();
            }
            else
            {
                frmProduits.Activate();
            }
        }

        private void Produits_FormClosed(object sender, EventArgs e)
        {
            frmProduits = null;
        }
        private void btnTabDeBoardHandling()
        {
            if (frmTabDeBord == null)
            {
                frmTabDeBord = new FormTabDeBord ();
                frmTabDeBord.FormClosed += TabDeBord_FormClosed;
                frmTabDeBord.MdiParent = this;
                frmTabDeBord.Dock = DockStyle.Fill;
                frmTabDeBord.Show();
            }
            else
            {
                frmTabDeBord.Activate();
               // frmTabDeBord.TableauDeBoardStarting();

            }
        }


        private void TabDeBord_FormClosed(object sender, EventArgs e)
        {
            frmTabDeBord = null;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //private void fillpnlUserData()
        //{
        //    if (!string.IsNullOrEmpty(Globale.utilisateurActuel.PathDimage) && File.Exists(Globale.utilisateurActuel.PathDimage))
        //    {
        //        picboxUtilisateur.Image = Image.FromFile(Globale.utilisateurActuel.PathDimage);
        //    }
        //    else
        //    {
        //        //picboxUtilisateur.Image = Image.FromFile(Globale.ecole.ImagePath);
        //    }
        //}

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmConnection.Close();
        }

        private void PnlUtilisateur_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    Globale.utilisateurActuel = null;
        //    frmConnection.Show();
        //    this.Close();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (PnlUtilisateur.Visible == true)
            { PnlUtilisateur.Visible = false; }
            else PnlUtilisateur.Visible = true;
        }
        //private void btnMonEcole_Click(object sender, EventArgs e)
        //{
        //    var frm = new FormEntrerMotDePasse();
        //    frm.ShowDialog();
        //    if (frm.isHim)
        //    {
        //        var form = new FormGestionScolaire();
        //        form.ShowDialog(); return;
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

        private void btnactivites_Click(object sender, EventArgs e)
        {

        }

        private void PnlUtilisateur_Leave(object sender, EventArgs e)
        {
            PnlUtilisateur.Visible = false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btntab_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            btntab.ImageSize = new Size(42, 45);
            btnpatient.ImageSize = new Size(45, 45);
            btnfacture.ImageSize = new Size(45, 45);
            btnfin.ImageSize = new Size(45, 45);
            btnaccord.ImageSize = new Size(45, 45);
            btnUti.ImageSize = new Size(45, 45);
            btnGestionCabinet.ImageSize = new Size(45, 45);
            btnproduits.ImageSize = new Size(45, 45);
            PnlButton_Click(btntab, EventArgs.Empty);
        }
    }

}