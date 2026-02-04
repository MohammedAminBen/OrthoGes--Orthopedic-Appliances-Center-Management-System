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
    public partial class FormAjouterProduit : Form
    {
        DataTable dtCategorie;
        private DataTable dtEleveList;
        public FormAjouterProduit()
        {
            InitializeComponent();
        }


        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (Produit.AddNewProduit(
                tbxReference.Text,
                tbxDesignation.Text,
                (int)cmbxCategorie.SelectedValue,
                decimal.Parse(tbxPUHT.Text),
                int.Parse(tbxTVA.Text),
                1,
                decimal.Parse(tbxTVAMontant.Text)
                ))
            {
                MessageBox.Show("Produit ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout du produit.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }


    }
}
