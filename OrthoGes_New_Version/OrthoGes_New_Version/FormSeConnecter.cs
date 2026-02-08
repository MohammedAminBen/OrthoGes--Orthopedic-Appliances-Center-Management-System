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
    public partial class FormSeConnecter : Form
    {
        public FormSeConnecter()
        {
            InitializeComponent();
        }

        private void FormCeConnecter_Load(object sender, EventArgs e)
        {
            if (Utilisateur.GetAllUtilisateurs().Rows.Count == 0)
            {
                btnCréercompte.Visible = true;
                lblConnecter.Visible = false;
                tbxNomUtilisateur.Visible = false;
                tbxMotDpasse.Visible = false;
                btnSeConnecter.Visible = false;
            }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormSeConnecter_Load(object sender, EventArgs e)
        {

        }

        private void btnCréercompte_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new FormAjouterUtilisateurPrincipale();
            frm.ShowDialog();
            if (frm.DialogResult != DialogResult.OK) { this.Close(); return; }

            Global.utilisateurActuel = Utilisateur.FindByNomUtilisateurEtMotDePasse(frm.UserName, frm.MotDpasse);
            var form = new FormGestionCabinet();
            form.ShowDialog();

            var formmain = new FormMain(this);
            formmain.ShowDialog();
            return;
        }

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            Utilisateur utilisateur = Utilisateur.FindByNomUtilisateurEtMotDePasse(tbxNomUtilisateur.Text, tbxMotDpasse.Text);
            if (utilisateur != null)
            {
                Global.utilisateurActuel = utilisateur;
                Global.centre = Centre_Appareillage.Find(1);
                tbxMotDpasse.Text = string.Empty;
                this.Hide();
                FormMain formMain = new FormMain(this);
                formMain.ShowDialog();
            }
            else
            {
                tbxMotDpasse.BorderColor = Color.Red;
                tbxMotDpasse.BorderThickness = 2;
                tbxNomUtilisateur.BorderColor = Color.Red;
                tbxNomUtilisateur.BorderThickness = 2;
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxNomUtilisateur_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // remove beep
                this.SelectNextControl(
                    (Control)sender,
                    true,   // forward
                    true,   // tabStopOnly
                    true,   // nested
                    true    // wrap
                );
            }
        }

        private void tbxMotDpasse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // prevents the "ding" sound
                Utilisateur utilisateur = Utilisateur.FindByNomUtilisateurEtMotDePasse(tbxNomUtilisateur.Text, tbxMotDpasse.Text);
                if (utilisateur != null)
                {
                    Global.utilisateurActuel = utilisateur;
                    Global.centre = Centre_Appareillage.Find(1);
                    tbxMotDpasse.Text = string.Empty;
                    this.Hide();
                    FormMain formMain = new FormMain(this);
                    formMain.ShowDialog();
                }
                else
                {
                    tbxMotDpasse.BorderColor = Color.Red;
                    tbxMotDpasse.BorderThickness = 2;
                    tbxNomUtilisateur.BorderColor = Color.Red;
                    tbxNomUtilisateur.BorderThickness = 2;
                }
            }
        }
    }
}
