using CodeSourceLayer_;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes_New_Version
{
    public partial class FormGestionCabinet : Form
    {
        public FormGestionCabinet()
        {
            InitializeComponent();
        }
        private void FillData()
        {
            if (Global.centre == null) { return; }

            tbxAddress.Text = Global.centre.Adresse;
            tbxMobile.Text = Global.centre.Mobile;
            tbxCentreNom.Text = Global.centre.CentreNom;
            tbxARTNum.Text = Global.centre.NumeroART;
            tbxNif.Text = Global.centre.NIF;
            tbxRCNum.Text = Global.centre.NumeroRC;
            tbxRIB.Text = Global.centre.RIB;
            tbxFAX.Text = Global.centre.FAX;
            tbxDescription.Text = Global.centre.Description_Centre;
            
            

            if (!string.IsNullOrEmpty(Global.centre.PathImage) && File.Exists(Global.centre.PathImage))
            {
                picbxImage.Image = Image.FromFile(Global.centre.PathImage);
            }
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Sélectionner une image";
                openFileDialog.Filter = "Fichiers image (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Tous les fichiers (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string filePath = openFileDialog.FileName;
                    Global.centre.PathImage = filePath; // Enregistrer le chemin de l'image dans l'objet utilisateur

                    picbxImage.Image = Image.FromFile(filePath);
                }
            }
        }

        private void btnEng_Click(object sender, EventArgs e)
        {
                Global.centre.CentreID = 1;
                Global.centre.NIF = tbxNif.Text;
                Global.centre.RIB = tbxRIB.Text;
                Global.centre.NumeroRC = tbxRCNum.Text;
                Global.centre.NumeroART = tbxARTNum.Text;
                Global.centre.CentreNom = tbxCentreNom.Text;
                Global.centre.Adresse = tbxAddress.Text;
                Global.centre.Mobile = tbxMobile.Text;
                Global.centre.FAX = tbxFAX.Text;
                Global.centre.Description_Centre = tbxDescription.Text;

            if (Centre_Appareillage.Find(1) == null)
            {

                if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, $"Ajouter le centre {tbxCentreNom.Text} au système", "Ajout"))
                {
                    Global.centre.AddNewCentre();
                    this.Close();
                }
            }
            else
            {
                if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, $"Modifier le centre {tbxCentreNom.Text}", "Modification"))
                {
                    Global.centre.UpdateCentre();
                    this.Close();
                }
            }
        }

        private void FormGestionCabinet_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
