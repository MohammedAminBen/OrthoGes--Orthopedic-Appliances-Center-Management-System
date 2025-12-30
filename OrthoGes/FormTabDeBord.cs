//using CodeSourceLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes
{
    public partial class FormTabDeBord : Form
    {
        
        public FormTabDeBord()
        {
            InitializeComponent();

        }

        private void btnAjouteruneSéance_Click(object sender, EventArgs e)
        {

        }
        //void FillSeanceData(string Jour)
        //{
        //    flowLayoutPanel1.Controls.Clear();
        //    DataTable timingdt = Seance.GetSeancesOfJour(Jour);
        //    if (timingdt.Rows.Count == 0)
        //    {
        //        return;
        //    }

        //    foreach (DataRow row in timingdt.Rows)
        //    {

        //        string Enseignant = row["Enseignant"]?.ToString() ?? "non affecter";
        //        string GroupeID = row["GroupeID"]?.ToString() ?? "";
        //        string horaire = row["Horaire"]?.ToString() ?? "";
        //        string salle = row["SaleNom"]?.ToString() ?? "";
        //        int EstAnnuler = Convert.ToInt32(row["EstAnnuler"]);

        //        DateTime DerniereDate = DateTime.MinValue;
        //        if (row["DerniereseanceDate"] != DBNull.Value)
        //        {
        //            DerniereDate = Convert.ToDateTime(row["DerniereseanceDate"]);
        //        }

        //        GroupProgramUserControl userControl = new GroupProgramUserControl(GroupeID);
        //        userControl.FillData(GroupeID, Enseignant, horaire, salle, Jour,DerniereDate,EstAnnuler); 
        //        flowLayoutPanel1.Controls.Add(userControl);
        //    }
        //}
        //void FillSeanceSpecialeData()
        //{
        //    flowLayoutPanel1.Controls.Clear();
        //    DataTable timingdt = Seance.GetSeancesSpeciales();
        //    if (timingdt.Rows.Count == 0)
        //    {
        //        return;
        //    }

        //    foreach (DataRow row in timingdt.Rows)
        //    {
        //        int SeanceID = (int)row["SeanceID"];
        //        string GroupeID = row["GroupeID"]?.ToString() ?? "";
        //        TimeSpan entree = (TimeSpan)row["heurEntree"];
        //        TimeSpan sortie = (TimeSpan)row["heurSortie"];
        //        int salle = (int)row["SalleID"];
        //        DateTime Date = (DateTime)row["DateDeSeance"];
        //        string Type = row["TypeDeSeance"].ToString();
        //        int esteffecter = Convert.ToInt32(row["EstEffecter"]);
        //        int estannuler = Convert.ToInt32(row["EstAnnuler"]);


        //        SeanceSpecialeUserControl userControl = new SeanceSpecialeUserControl();
        //        userControl.FillData(SeanceID,GroupeID,entree,sortie, salle,Date,Type,esteffecter,estannuler);
        //        flowLayoutPanel1.Controls.Add(userControl);
        //    }
        //}
        //private void DayButton_Click(object sender, EventArgs e)
        //{
        //    Guna2Button clickedButton = sender as Guna2Button;

        //    // ✅ Make sure to change `panelDays` to the name of your actual container
        //    foreach (Control ctrl in PanelDays.Controls)
        //    {
        //        if (ctrl is Guna2Button btn && btn.Tag?.ToString() == "dayButton")
        //        {
        //            btn.FillColor = Color.White;
        //            btn.ForeColor = Color.Gray;
        //            btn.Font = new Font(btn.Font, FontStyle.Regular);
                    
        //        }
               
        //    }

        //    // Highlight the clicked button
        //    clickedButton.FillColor = Color.CornflowerBlue;
        //    clickedButton.ForeColor = Color.White;
        //    clickedButton.Font = new Font(clickedButton.Font, FontStyle.Bold);
        //    if(clickedButton.Text == "Séances Speciales     ")
        //    {
        //        FillSeanceSpecialeData();
        //        return;
        //    }
        //    // Fill the data
        //    string jour = clickedButton.Text;
        //    FillSeanceData(jour);
        //}
        //public void InitializeDay()
        //{
        //    string today = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("fr-FR")); 

        //    foreach (Control ctrl in PanelDays.Controls) 
        //    {
        //        if (ctrl is Guna2Button btn && btn.Tag?.ToString() == "dayButton")
        //        {
        //            if (string.Equals(btn.Text, today, StringComparison.OrdinalIgnoreCase))
        //            {
        //                DayButton_Click(btn, EventArgs.Empty); 
        //                break;
        //            }
        //        }
        //    }
        //}
        //public void TableauDeBoardStarting()
        //{
        //    InitializeDay();
        //    nmbrEleves.Text = Eleve.GetElevesCount().ToString();
        //    nmbrGroupes.Text = Groupe.GetGroupesCount().ToString();
        //    nmbrEnseignant.Text = Enseignant.GetEnseignantsCount().ToString();
        //}
        //private void FormTableaudeboard2_Load(object sender, EventArgs e)
        //{
        //    InitializeDay();
        //    nmbrEleves.Text = Eleve.GetElevesCount().ToString();
        //    nmbrGroupes.Text = Groupe.GetGroupesCount().ToString();
        //    nmbrEnseignant.Text = Enseignant.GetEnseignantsCount().ToString();
        //    StartMinuteAlignedTimer();
        //}
        //private void StartMinuteAlignedTimer()
        //{
        //    // One-time timer to wait until the next full minute
        //    Timer alignTimer = new Timer();
        //    alignTimer.Interval = 1000; // check every second
        //    alignTimer.Tick += (s, e) =>
        //    {
        //        if (DateTime.Now.Second == 0)
        //        {
        //            alignTimer.Stop();
        //            alignTimer.Dispose();

        //            // Now start the main timer
        //            TimerUpdate = new Timer();
        //            TimerUpdate.Interval = 60000; // 60,000 ms = 1 minute
        //            TimerUpdate.Tick += TimerUpdate_Tick;
        //            TimerUpdate.Start();

        //            // Run the first update immediately
        //            TimerUpdate_Tick(null, null);
        //        }
        //    };
        //    alignTimer.Start();
        //}

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void guna2Panel4_Click(object sender, EventArgs e)
        //{
        //    if (frmEnseignant == null)
        //    {
        //        frmEnseignant = new FormEnseignantes();
        //        frmEnseignant.FormClosed += Enseignantes_FormClosed;
        //        frmEnseignant.MdiParent = this;
        //        frmEnseignant.Dock = DockStyle.Fill;
        //        frmEnseignant.Show();
        //    }
        //    else
        //    {
        //        frmEnseignant.Activate();
        //    }
        //}
        //private void Enseignantes_FormClosed(object sender, EventArgs e)
        //{
        //    frmEnseignant = null;
        //}

        //private void TimerUpdate_Tick(object sender, EventArgs e)
        //{
        //    flowLayoutPanel1.SuspendLayout();
        //    foreach (Control control in flowLayoutPanel1.Controls)
        //    {
        //        if (control is GroupProgramUserControl con)
        //        {
        //            con.UpdateEveryTimerTick();
        //        }
        //        if(control is SeanceSpecialeUserControl conn)
        //        {
        //            conn.UpdateEveryTimerTick();
        //        }
        //    }
        //    flowLayoutPanel1.ResumeLayout();

        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void guna2Panel4_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
