//using CodeSourceLayer;
using CodeSourceLayer_;
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

namespace OrthoGes_New_Version
{
    public partial class FormModifierProduit : Form
    {
        string Reference;
        Produit produit;
        DataTable dtCategorie;
        private DataTable dtEleveList;
        public FormModifierProduit(string reference)
        {
            InitializeComponent();
            Reference = reference;
        }

        private void LoadData()
        {
            produit = Produit.FindByReference(Reference);  
            tbxReference.Text = produit.Reference;
            tbxDesignation.Text = produit.Nom_Produit;
            cmbxCategorie.SelectedValue = produit.Category_ID;
            tbxPUHT.Text = produit.Prix.ToString();
            tbxTVA.Text = produit.TVA.ToString();
            tbxTVAMontant.Text = produit.Prix_TVA.ToString();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (Produit.UpdateProduit(
                tbxReference.Text,
                tbxDesignation.Text,
                (int)cmbxCategorie.SelectedValue,
                decimal.Parse(tbxPUHT.Text),
                int.Parse(tbxTVA.Text),
                1,
                decimal.Parse(tbxTVAMontant.Text)
                ))
            {
                if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, $"Modifier le produit {tbxReference.Text} au système", "Modification"))
                {
                    MessageBox.Show("Produit modifié avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification du produit.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FillCmbxWithData()
        {
            dtCategorie = Produit.GetAllCategories();
            cmbxCategorie.DataSource = dtCategorie;
            cmbxCategorie.DisplayMember = "Category_Nom";
            cmbxCategorie.ValueMember = "Category_ID";
        }
        private void FormAjouterProduit_Load(object sender, EventArgs e)
        {
            
            FillCmbxWithData();
            LoadData();
        }


    }
}
