using CodeSource;
using CodeSourceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS_UI
{
    public partial class FormModifierEtatAccord : Form
    {
        public bool isHim = false;
        public int accordID;
        public FormModifierEtatAccord(int accordid)
        {
            InitializeComponent();
            this.accordID = accordid;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {

            if (Accord.UpdateEtatAccord(accordID, cmbxetat.Text))
            {
                MessageBox.Show("État de l'accord mis à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Échec de la mise à jour de l'état de l'accord.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
