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
    public partial class FormEntrerMotDePasse : Form
    {
        public bool isHim = false;
        public FormEntrerMotDePasse()
        {
            InitializeComponent();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (tbxMotDePasse.Text == Global.utilisateurActuel.Mot_De_Passe)
            {
                isHim = true;
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Mot de passe incorrect !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isHim = false;
                this.Close();
            }

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxMotDePasse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbxMotDePasse.Text == Global.utilisateurActuel.Mot_De_Passe)
                {
                    isHim = true;
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Mot de passe incorrect !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isHim = false;
                    this.Close();
                }
            }
        }
    }
}
