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
    public partial class FormModifierUtilisateur : Form
    {
        int UtilisateurID = -1;
        Utilisateur utilisateur = new Utilisateur();
        Person person = new Person();
        public FormModifierUtilisateur(int id)
        {
            InitializeComponent();
            UtilisateurID = id;
        }

        private void FormModifierUtilisateur_Load(object sender, EventArgs e)
        {
            LoadData();
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
            tbxadresse.Text = person.Adresse;
            tbxEmail.Text = person.Email;
            tbxMotDePasse.Text = utilisateur.Mot_De_Passe;
            tbxNom.Text = person.Nom;
            tbxNomUtilisateur.Text = utilisateur.Nom_Utilisateur;
            tbxPrenom.Text = person.Prenom;

            tbxTele1.Text = person.Telephones[0];
            if (person.Telephones.Length > 1)
            {
                tbxTele2.Text = person.Telephones[1];
                if (person.Telephones.Length > 2) tbxTele3.Text = person.Telephones[2];
            }

            if (utilisateur.Est_Admin)
            {
                rdbAdmin.Checked = true;
                rdbNormal.Checked = false;
            }

            if (utilisateur.PrivManipulationPatient) { cbxpatient.Checked = true; }
            if (utilisateur.PrivManipulationDevis) { cbxdevis.Checked = true; }
            if (utilisateur.PrivManipulationFacture) { cbxfacture.Checked = true; }
            if (utilisateur.PrivManipulationBonLivraison) { cbxbonliv.Checked = true; }
            if (utilisateur.PrivManipulationAccord) { cbxaccord.Checked = true; }
            if (utilisateur.PrivManipulationProduits) { cbxproduits.Checked = true; }
            if (utilisateur.PrivManipulationRecouvrement) { cbxrecouv.Checked = true; }

            if (!string.IsNullOrEmpty(utilisateur.Path_Image) && File.Exists(utilisateur.Path_Image))
            {
                guna2CirclePictureBox1.Image = Image.FromFile(utilisateur.Path_Image);
            }
            else
            {
                guna2CirclePictureBox1.Image = Image.FromFile(Global.centre.PathImage);
            }
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
                telephones.Add(tbxTele3.Text); person.Email = tbxEmail.Text.Trim();

            person.Telephones = telephones.ToArray();
            person.Adresse = tbxadresse.Text.Trim();

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

            if (utilisateur.UpdateUtilisateur())
            {
                if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, $" L'utilisateur {utilisateur.Nom_Utilisateur} a été modifié.","Modification"))
                {
                    if (person.UpdatePerson())
                    {
                        MessageBox.Show($"Données enregistrées avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;

                    }
                    else
                    {
                        MessageBox.Show($"Données enregistrées avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                }
            }
            else if (person.UpdatePerson())
            {
                if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, $" L'utilisateur {utilisateur.Nom_Utilisateur} a été modifié.","Modification"))
                {
                    MessageBox.Show($"Données enregistrées avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Erreur : l'enregistrement de l'élève a échoué. ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAdmin.Checked)
            {
                cbxpatient.Checked = true;
                cbxpatient.Enabled = false;
                cbxdevis.Checked = true;
                cbxdevis.Enabled = false;
                cbxfacture.Checked = true;
                cbxfacture.Enabled = false;
                cbxbonliv.Checked = true;
                cbxbonliv.Enabled = false;
                cbxaccord.Checked = true;
                cbxaccord.Enabled = false;
                cbxproduits.Checked = true;
                cbxproduits.Enabled = false;
                cbxrecouv.Checked = true;
                cbxrecouv.Enabled = false;
            }
            else
            {
                cbxpatient.Enabled = true;
                cbxdevis.Enabled = true;
                cbxfacture.Enabled = true;
                cbxbonliv.Enabled = true;
                cbxaccord.Enabled = true;
                cbxproduits.Enabled = true;
                cbxrecouv.Enabled = true;
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

                    guna2CirclePictureBox1.Image = Image.FromFile(filePath);
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
