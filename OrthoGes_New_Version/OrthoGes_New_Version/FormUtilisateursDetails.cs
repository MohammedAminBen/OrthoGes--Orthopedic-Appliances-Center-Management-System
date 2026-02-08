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
using System.IO;

namespace OrthoGes_New_Version
{
    public partial class FormUtilisateursDetails : Form
    {
        int UtilisateurID = -1;
        Utilisateur utilisateur = new Utilisateur();
        Person person = new Person();
        public FormUtilisateursDetails(int id)
        {
            InitializeComponent();
            UtilisateurID = id;
        }
        private void LoadData()
        {
            utilisateur = Utilisateur.FindByUtilisateurID(UtilisateurID);
            person = Person.Find(utilisateur.Person_ID);
            if (utilisateur == null || person == null)
            {
                MessageBox.Show("Pas D'utilisateur [ " + UtilisateurID + " ]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblAddress.Text = person.Adresse;
            lblEmail.Text = person.Email;
            lblMotDpasse.Text = utilisateur.Mot_De_Passe;
            lblNometPrenom.Text = person.NomEtPrenom;
            lblNomUtili.Text = utilisateur.Nom_Utilisateur;
            string telephone = string.Join("/", person.Telephones);
            lblTelephone.Text = telephone;
            lblDate.Text = utilisateur.Date_De_Connection.ToString("dd/MM/yyyy");
            if (utilisateur.PrivManipulationBonLivraison) {lblbonliv.Visible = true; }
            if (utilisateur.PrivManipulationFacture) { lblfactures.Visible = true; }
            if (utilisateur.PrivManipulationDevis) { lbldevis.Visible = true; }
            if (utilisateur.PrivManipulationPatient) { lblpatient.Visible = true; }
            if (utilisateur.PrivManipulationAccord) { lblaccord.Visible = true; }
            if (utilisateur.PrivManipulationProduits) { lblproduits.Visible = true; }
            if (utilisateur.PrivManipulationRecouvrement) { lblrecouv.Visible = true; }

            if (!string.IsNullOrEmpty(utilisateur.Path_Image) && File.Exists(utilisateur.Path_Image))
            {
                guna2CirclePictureBox1.Image = Image.FromFile(utilisateur.Path_Image);
            }
            else
            {
                guna2CirclePictureBox1.Image = Image.FromFile(Global.centre.PathImage);
            }

        }
        private void FormUtilisateursDetails_Load(object sender, EventArgs e)
        {
            LoadData();
            FillDgvWithData();
        }
        private void FillDgvWithData()
        {
            DataTable dt = Utilisateur.GetActivitésDUtilisateur(UtilisateurID);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Aucune activité trouvée pour cet utilisateur.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModifier_Click_1(object sender, EventArgs e)
        {
            var form = new FormModifierUtilisateur(UtilisateurID);
            form.ShowDialog();
            LoadData();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            int DeletedPersonID = Utilisateur.FindByUtilisateurID(UtilisateurID).Person_ID;
            if (result == DialogResult.Yes)
            {
                if (Utilisateur.DeleteUtilisateur(UtilisateurID))
                {
                    if (Person.DeletePerson(DeletedPersonID))
                    {
                        if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, $"L'utilisateur {Utilisateur.FindByUtilisateurID(UtilisateurID).Nom_Utilisateur} a été supprimé du système.","Suppression"))
                        {
                            MessageBox.Show("Utilisateur supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression de l'utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
