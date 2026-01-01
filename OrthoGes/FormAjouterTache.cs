//using CodeSourceLayer;
using CodeSource;
using CodeSourceLayer;
using SMS_UI;
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

namespace OrthoGes
{
    public partial class FormAjouterTache : Form
    {
        private DataTable  dtEleveList;
        public FormAjouterTache()
        {
          InitializeComponent();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            Tache.CreateTache(tbxText.Text,"Manuel",DateTime.Now.Date,0,0);
            this.Close();
        }
    }
}
