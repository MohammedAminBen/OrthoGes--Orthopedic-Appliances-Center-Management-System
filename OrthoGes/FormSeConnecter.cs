//using CodeSourceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes
{
    public partial class FormSeConnecter : Form
    {
        public FormSeConnecter()
        {
            InitializeComponent();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Utilisateurs utilisateur = Utilisateurs.FindByNomUtilisateurEtMotDePasse( tbxNomUtilisateur.Text,tbxMotDpasse.Text);
            //if (utilisateur != null)
            //{
            //    Globale.utilisateurActuel = utilisateur;
            //    Globale.ecole = MonEcole.Find();
            //    tbxMotDpasse.Text = string.Empty;
            //    this.Hide();
            //    FormMain formMain = new FormMain(this);
            //    formMain.ShowDialog();
            //}
            //else
            //{
            //    tbxMotDpasse.BorderColor = Color.Red;
            //    tbxMotDpasse.BorderThickness = 2;
            //    tbxNomUtilisateur.BorderColor = Color.Red;
            //    tbxNomUtilisateur.BorderThickness = 2;
            //}
        }

        private void guna2ControlBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCeConnecter_Load(object sender, EventArgs e)
        {
            //if(MonEcole.Find() == null)
            //{
            //    btnCréercompte.Visible = true;
            //    lblConnecter.Visible = false;
            //    tbxNomUtilisateur.Visible = false;
            //    tbxMotDpasse.Visible = false;
            //    btnSeConnecter.Visible = false;

            //}
        }

        private void btnCréercompte_Click(object sender, EventArgs e)
        {

                //this.Hide();
                //var frm = new FormAjouterlutilisateurprincipale();
                //frm.ShowDialog();
                //if( frm.DialogResult != DialogResult.OK ) { this.Close(); return;}

                //Globale.utilisateurActuel = Utilisateurs.FindByNomUtilisateurEtMotDePasse(frm.UserName, frm.MotDpasse);
                //var form = new FormGestionScolaire();
                //form.ShowDialog();

                //var formmain = new FormMain(this);
                //formmain.ShowDialog();
                //return;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
