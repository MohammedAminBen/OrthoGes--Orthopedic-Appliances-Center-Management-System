using CodeSourceLayer_;
using OrthoGes_New_Version;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SMS_UI
{
    
    public partial class TacheUserControl : UserControl
    {
        Tache tache;
        int tacheId;
        FormTabDeBord parentForm;
        public TacheUserControl(int tache, FormTabDeBord parentForm)
        {
            InitializeComponent();
            this.tacheId = tache;
            this.parentForm = parentForm;
            LoadData();
        }
        private void LoadData()
        {
            tache = Tache.FindByID(tacheId);
            tbxText.Text = tache.Tache_Text;
            lblDate.Text = tache.Tache_Date.ToString("dd/MM/yyyy");
            if (tache.Est_Fini == 1)
            {
               picboxIsDone.Visible = true;
               btnFini.Enabled = false;
               //TacheHandled();
                return;
            }
            if(tache.Est_Annuler == 1)
            {
                picboxIsCanceled.Visible = true;
                btnAnnuler.Enabled = false;
                //TacheHandled();
                return;
            }
            else
            {
                TacheNotHandled();
            }

        }
        private void TacheNotHandled()
        {
            lblT.ForeColor = Color.White;
            lblD.ForeColor = Color.White;
            lblDate.ForeColor = Color.White;
            tbxText.FillColor = Color.Red;
            tbxText.ForeColor = Color.White;
            pnlComponents.FillColor = Color.Red;
        }
        private void TacheHandled()
        {
            lblT.ForeColor = Color.Black;
            lblD.ForeColor = Color.Black;
            lblDate.ForeColor = Color.Black;
            tbxText.FillColor = Color.AliceBlue;
            tbxText.ForeColor = Color.Black;
            pnlComponents.FillColor = Color.AliceBlue;
        }
        private void btnAnnuler_Click_1(object sender, EventArgs e)
        { 
            if (picboxIsDone.Visible)
            {
                picboxIsDone.Visible = false;
                btnFini.Enabled = true;
                Tache.UpdateEtatFini(tacheId, 0);
                TacheNotHandled();
                return;
            }
            if (picboxIsCanceled.Visible) 
            {
                picboxIsCanceled.Visible = false;
                btnFini.Enabled = true;
                Tache.UpdateEtatAnnuler(tacheId, 0);
                TacheNotHandled();
                return;
            }
            picboxIsCanceled.Visible = true;
            btnFini.Enabled = false;
            Tache.UpdateEtatAnnuler(tacheId, 1);
            TacheHandled();
        }

        private void pnlComponents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFini_Click(object sender, EventArgs e)
        {
            picboxIsDone.Visible = true;
            btnFini.Enabled=false;
            Tache.UpdateEtatFini(tacheId, 1);
            TacheHandled();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tache.DeleteTache(tacheId);
            parentForm.FillTachesData();
        }
    }
}
