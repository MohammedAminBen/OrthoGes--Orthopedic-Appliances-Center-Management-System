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
    public partial class FormAjouterUtilisateur : Form
    {
        Person person = new Person();
        Utilisateur utilisateur = new Utilisateur();
        public string UserName = "";
        public string MotDpasse = "";
        public FormAjouterUtilisateur()
        {
            InitializeComponent();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            person.Nom = tbxNom.Text.Trim();
            person.Prenom = tbxPrenom.Text.Trim();

            var telephones = new List<string>();

            if (!string.IsNullOrWhiteSpace(tbxTele1.Text))
                telephones.Add(tbxTele1.Text);

            if (!string.IsNullOrWhiteSpace(tbxTele2.Text))
                telephones.Add(tbxTele2.Text);

            if (!string.IsNullOrWhiteSpace(tbxTele3.Text))
                telephones.Add(tbxTele3.Text);

            person.Telephones = telephones.ToArray();
            person.Email = tbxEmail.Text.Trim();
            person.Adresse = tbxadresse.Text.Trim();
            person.DateNaissance = DateTime.Parse(tbxDateNai.Text.Trim());
            if (!person.AddNewPerson())
            {
                MessageBox.Show("Erreur : les données n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            utilisateur.Person_ID = person.PersonID;
            utilisateur.Nom_Utilisateur = tbxNomUtilisateur.Text.Trim();
            utilisateur.Mot_De_Passe = tbxMotDePasse.Text.Trim();
            utilisateur.Est_Admin = rdbAdmin.Checked;
            utilisateur.PrivManipulationPatient = cbxbonliv.Checked;
            utilisateur.PrivManipulationPatient = cbxpatient.Checked;
            utilisateur.PrivManipulationProduits = cbxproduits.Checked;
            utilisateur.PrivManipulationFacture = cbxfacture.Checked;
            utilisateur.PrivManipulationRecouvrement = cbxrecouv.Checked;
            utilisateur.PrivManipulationAccord = cbxaccord.Checked;
            utilisateur.PrivManipulationDevis = cbxdevis.Checked;
            if (utilisateur.AjouterUtilisateur())
            {
                if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, "Ajout de l'utilisateur " + utilisateur.Nom_Utilisateur + " au système","Ajout"))
                {
                    MessageBox.Show($"Données enregistrées avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Erreur : l'enregistrement de l'utilisateur a échoué.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAdmin.Checked)
            {
                cbxdevis.Checked = true;
                cbxdevis.Enabled = false;
                cbxfacture.Checked = true;
                cbxfacture.Enabled = false;
                cbxbonliv.Checked = true;
                cbxbonliv.Enabled = false;
                cbxpatient.Checked = true;
                cbxpatient.Enabled = false;
            }
            else
            {
                cbxdevis.Enabled = true;
                cbxfacture.Enabled = true;
                cbxbonliv.Enabled = true;
                cbxpatient.Enabled = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Sélectionner une image";
                openFileDialog.Filter = "Fichiers image (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Tous les fichiers (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    string filePath = openFileDialog.FileName;
                    utilisateur.Path_Image = filePath; // Enregistrer le chemin de l'image dans l'objet utilisateur

                    picbxImage.Image = Image.FromFile(filePath);
                }
            }

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAjouterUtilisateur_Load(object sender, EventArgs e)
        {
            if (Global.centre != null)
            {
                if (!string.IsNullOrEmpty(Global.centre.PathImage) && System.IO.File.Exists(Global.centre.PathImage))
                {
                    picbxImage.Image = Image.FromFile(Global.centre.PathImage);
                }
            }
        }
    }
}
