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
    public partial class FormUtilisateurs : Form
    {
        public FormUtilisateurs()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void filldgvUtilisateurswithData()
        {
            DataTable dt = Utilisateur.GetAllUtilisateurs();
            DataView dv = dt.DefaultView;
            dgvUtilisateursListe.DataSource = dv;

            dgvUtilisateursListe.Columns["Utilisateur_ID"].Visible = false;
            dgvUtilisateursListe.Columns["Type_Utilisateur"].HeaderText = "Type d'utilisateur";
            dgvUtilisateursListe.Columns["Type_Utilisateur"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUtilisateursListe.Columns["Type_Utilisateur"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUtilisateursListe.Columns["Type_Utilisateur"].Width = 170;
            dgvUtilisateursListe.Columns["Nom_Utilisateur"].HeaderText = "Nom d'utilisateur";
            dgvUtilisateursListe.Columns["Nom_Utilisateur"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUtilisateursListe.Columns["Nom_Utilisateur"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUtilisateursListe.Columns["Nom_Utilisateur"].Width = 200;
            dgvUtilisateursListe.Columns["NomEtPrenom"].HeaderText = "Nom et Prénom";
            dgvUtilisateursListe.Columns["NomEtPrenom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUtilisateursListe.Columns["NomEtPrenom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUtilisateursListe.Columns["Date_De_Connection"].HeaderText = "Date De Connexion";
            dgvUtilisateursListe.Columns["Date_De_Connection"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUtilisateursListe.Columns["Date_De_Connection"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUtilisateursListe.Columns["Date_De_Connection"].Width = 170;
        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Sélectionnez une image";
                ofd.Filter = "Fichiers image|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    guna2CirclePictureBox1.Image = Image.FromFile(ofd.FileName);
                    guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Ajuste l’image au cadre
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new FormEntrerMotDePasse();
            frm.ShowDialog();
            if (!frm.isHim)
            {
                return;
            }
            var form = new FormAjouterUtilisateur();
            form.ShowDialog();
            filldgvUtilisateurswithData();
        }

        private void FormUtilisateurs_Load(object sender, EventArgs e)
        {
            LoadData();
            filldgvUtilisateurswithData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var frm = new FormEntrerMotDePasse();
            frm.ShowDialog();
            if (!frm.isHim)
            {
                return;
            }
            var form = new FormModifierUtilisateur((int)dgvUtilisateursListe.CurrentRow.Cells[1].Value);
            form.ShowDialog();
            filldgvUtilisateurswithData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new FormEntrerMotDePasse();
            frm.ShowDialog();
            if (!frm.isHim)
            {
                return;
            }
            var form = new FormUtilisateursDetails((int)dgvUtilisateursListe.CurrentRow.Cells[1].Value);
            form.ShowDialog();
            filldgvUtilisateurswithData();
        }
        private void LoadData()
        {
            Utilisateur utilisateur = Global.utilisateurActuel;
            Person person = Person.Find(utilisateur.Person_ID);
            lblAddress.Text = person.Adresse;
            lblEmail.Text = person.Email;
            lblNometPrenom.Text = person.NomEtPrenom;
            lblNomUtilisateur.Text = utilisateur.Nom_Utilisateur;
            string telephone = string.Join("/", person.Telephones);
            lblTelephone.Text = telephone;
            lblDate.Text = utilisateur.Date_De_Connection.ToString("dd/MM/yyyy");

            if (!string.IsNullOrEmpty(utilisateur.Path_Image) && File.Exists(utilisateur.Path_Image))
            {
                guna2CirclePictureBox1.Image = Image.FromFile(utilisateur.Path_Image);
            }
            else
            {
                guna2CirclePictureBox1.Image = Image.FromFile(Global.centre.PathImage);
            }

        }
        private void button7_Click(object sender, EventArgs e)
        {
            var frm = new FormEntrerMotDePasse();
            frm.ShowDialog();
            if (!frm.isHim)
            {
                return;
            }
            if (dgvUtilisateursListe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int utilisateurID = (int)dgvUtilisateursListe.CurrentRow.Cells[1].Value;
            int DeletedPersonID = Utilisateur.FindByUtilisateurID(utilisateurID).Person_ID;
            DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer l'utilisateur avec l'ID {utilisateurID} ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (Utilisateur.DeleteUtilisateur(utilisateurID))
                {
                    if (Person.DeletePerson(DeletedPersonID))
                    {
                        if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, $"Supprimer l'utilisateur {Utilisateur.FindByUtilisateurID(utilisateurID).Nom_Utilisateur} du système","Suppression"))
                        {
                            MessageBox.Show("Utilisateur supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            filldgvUtilisateurswithData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression de l'utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var frm = new FormEntrerMotDePasse();
            frm.ShowDialog();
            if (frm.isHim)
            {
                FormModifierUtilisateur form = new FormModifierUtilisateur(Global.utilisateurActuel.Utilisateur_ID);
                form.ShowDialog();
            }
            else
            {
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new FormEntrerMotDePasse();
            frm.ShowDialog();
            if (!frm.isHim)
            {
                return;
            }
            FormUtilisateursActivitésHistorique form = new FormUtilisateursActivitésHistorique();
            form.ShowDialog();
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
