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
    public partial class FormUtilisateursActivitésHistorique : Form
    {
        public FormUtilisateursActivitésHistorique()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUtilisateursActivitésHistorique_Load(object sender, EventArgs e)
        {
            DataTable dt  = Utilisateur.GetAllActivités();
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Aucune activité trouvée.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            DataView dv = dt.DefaultView;
            dgvHistorique.DataSource = dv;
            dgvHistorique.Columns["Utilisateur"].HeaderText = "Utilisateur";
            dgvHistorique.Columns["Utilisateur"].Width = 150;
            dgvHistorique.Columns["Date_Activite"].HeaderText = "Date";
            dgvHistorique.Columns["Date_Activite"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorique.Columns["Date_Activite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorique.Columns["Date_Activite"].Width = 150;
            dgvHistorique.Columns["Heur_Activite"].HeaderText = "Heure";
            dgvHistorique.Columns["Heur_Activite"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorique.Columns["Heur_Activite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorique.Columns["Heur_Activite"].Width = 160;
            dgvHistorique.Columns["Type_Activite"].HeaderText = "Type de l'activité";
            dgvHistorique.Columns["Type_Activite"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorique.Columns["Type_Activite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorique.Columns["Type_Activite"].Width = 160;
            dgvHistorique.Columns["Activite"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
    }
}
