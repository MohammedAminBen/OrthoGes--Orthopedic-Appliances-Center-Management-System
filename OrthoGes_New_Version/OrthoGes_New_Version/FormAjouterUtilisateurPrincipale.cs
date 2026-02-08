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
    public partial class FormAjouterUtilisateurPrincipale : Form
    {
        Person person = new Person();
        Utilisateur utilisateur = new Utilisateur();
        public string UserName = "";
        public string MotDpasse = "";
        public FormAjouterUtilisateurPrincipale()
        {
            InitializeComponent();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (tbxNom.Text == string.Empty) { tbxNom.BorderColor = Color.Red; lblNom.ForeColor = Color.Red; return; } else { tbxNom.BorderColor = Color.Black; lblNom.ForeColor = Color.Black; }
            if (tbxPrenom.Text == string.Empty) { tbxPrenom.BorderColor = Color.Red; lblprenom.ForeColor = Color.Red; return; } else { tbxPrenom.BorderColor = Color.Black; lblprenom.ForeColor = Color.Black; }
            if (tbxDateNai.Text == string.Empty) { tbxDateNai.BorderColor = Color.Red; lbldate.ForeColor = Color.Red; return; } else { tbxDateNai.BorderColor = Color.Black; lbldate.ForeColor = Color.Black; }

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
            person.DateNaissance = DateTime.Parse(tbxDateNai.Text.Trim());
            if (!person.AddNewPerson())
            {
                MessageBox.Show("Erreur : les données n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbxNomUtilisateur.Text == string.Empty) { tbxNomUtilisateur.BorderColor = Color.Red; lblnomUtil.ForeColor = Color.Red; return; } else { tbxNomUtilisateur.BorderColor = Color.Black; lblnomUtil.ForeColor = Color.Black; }
            if (tbxMotDePasse.Text == string.Empty) { tbxMotDePasse.BorderColor = Color.Red; lblmotdpasse.ForeColor = Color.Red; return; } else { tbxMotDePasse.BorderColor = Color.Black; lblmotdpasse.ForeColor = Color.Black; }

            utilisateur.Person_ID = person.PersonID;
            utilisateur.Nom_Utilisateur = tbxNomUtilisateur.Text.Trim();
            utilisateur.Mot_De_Passe = tbxMotDePasse.Text.Trim();
            utilisateur.Est_Admin = true;
            utilisateur.PrivManipulationPatient = true;
            utilisateur.PrivManipulationPatient = true;
            utilisateur.PrivManipulationProduits = true;
            utilisateur.PrivManipulationFacture = true;
            utilisateur.PrivManipulationRecouvrement = true;
            utilisateur.PrivManipulationAccord = true;
            utilisateur.PrivManipulationDevis = true;

            if (utilisateur.AjouterUtilisateur())
            {
                    UserName = utilisateur.Nom_Utilisateur;
                    MotDpasse = utilisateur.Mot_De_Passe;
                    MessageBox.Show($"Données enregistrées avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
            }
            else
            {
                MessageBox.Show("Erreur : l'enregistrement de l'utilisateur a échoué.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAjouterlutilisateurprincipale_Load(object sender, EventArgs e)
        {
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
    }
}
