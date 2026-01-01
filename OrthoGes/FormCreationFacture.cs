using CodeSourceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes
{
    public partial class FormCreationFacture : Form
    {
        private int PersonID = -1;
        private string Numero_Patient = null;
        Person person;
        Patient patient;
        Assure assure;
        private bool _suppressSearch = false;
        public FormCreationFacture(string numero_patient)
        {
            InitializeComponent();
            Numero_Patient = numero_patient;
        }

        private void AssuredCheckedConfig()
        {
            gbxpatient.Size = new Size(766, 278);
            gbxAssure.Visible = false;
            gbxContact.Location = new System.Drawing.Point(11, 336);
            lblnum.Visible = true;
            tbxNumAssPatient.Visible = true;
            guna2GroupBox1.Location = new System.Drawing.Point(11, 502);
            this.btnEnregistrer.Location = new System.Drawing.Point(477, 855);
            this.btnAnnuler.Location = new System.Drawing.Point(643, 854);
            lblD.Location = new Point(218, 865);
            tbxDate.Location = new Point(285, 856);
            this.Size = new Size(805, 960);
        }
        private void LoadData()
        {
            patient = Patient.FindByNumeroPatient(Numero_Patient);
            tbxDate.Text = DateTime.Now.Date.ToString("d");
            if (patient == null)
            {
                MessageBox.Show("Error when trying to identify the patient");
                return;
            }
            if (patient.est_Assure == 1)
            {
                AssuredCheckedConfig() ;
                person = Person.Find(patient.PersonID);
                assure = Assure.FindByID(patient.AssureID);

                tbxNomPatient.Text = person.Nom;
                tbxPrenomPatient.Text = person.Prenom;
                tbxDateNaiPatient.Text = person.DateNaissance.ToString("d");
                tbxNumAssPatient.Text = assure.NumeroAssurance.ToString();
                tbxCaissePatient.Text = assure.CaisseNom;
                tbxadresse.Text = person.Adresse;
                tbxWilaya.Text = person.Wilaya;
                tbxCommune.Text = person.Commune;

            }
            else
            {
                person = Person.Find(patient.PersonID);
                assure = Assure.FindByID(patient.AssureID);

                Person personassure = Person.Find(assure.PersonID);

                tbxNomPatient.Text = person.Nom;
                tbxPrenomPatient.Text = person.Prenom;
                tbxDateNaiPatient.Text = person.DateNaissance.ToString("d");

                tbxNomAssure.Text = personassure.Nom;
                tbxPrenomAssure.Text = personassure.Prenom;

                tbxDateNaiAssure.Text = personassure.DateNaissance.ToString("d");



                tbxNumAssAssure.Text = assure.NumeroAssurance.ToString();
                tbxCaisseAssure.Text = assure.CaisseNom;

                tbxadresse.Text = person.Adresse;
                tbxWilaya.Text = person.Wilaya;
                tbxCommune.Text = person.Commune;
            }
        }
        private void FormCreationDevis_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tbxReference_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch) return;

            if (tbxReference.Text.Length == 0)
            {
                dgvProduits.Visible = false;
                return;
            }

            dgvProduits.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvProduits.DataSource = produits;

            for (int i = 1; i < dgvProduits.Columns.Count; i++)
                dgvProduits.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Reference LIKE '%{tbxReference.Text}%'";

            if (dv.Count == 0)
                dgvProduits.Visible = false;
        }
        private void dgvProduits_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch = true;

            tbxReference.Text = dgvProduits.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation.Text = dgvProduits.CurrentRow.Cells[1].Value.ToString();
            tbxPUHT.Text = dgvProduits.CurrentRow.Cells[4].Value.ToString();
            tbxTVA.Text = dgvProduits.CurrentRow.Cells[5].Value.ToString();
            //tbxTVAMontant.Text = dgvProduits.CurrentRow.Cells[6].Value.ToString();

            dgvProduits.Visible = false;

            _suppressSearch = false;

        }

        private void tbxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (tbxQuantity.Text == string.Empty || tbxPUHT.Text == string.Empty)
            {
                tbxMontant.Text = "0.00";
                return;
            }
            if (decimal.TryParse(tbxPUHT.Text, out decimal puht) &&
                decimal.TryParse(tbxQuantity.Text, out decimal quantity))
            {
                tbxMontant.Text = (puht * quantity).ToString("0.00");
            }
            else
            {
                tbxMontant.Text = "0.00";
            }

        }

        private void tbxMontant_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant.Text == string.Empty || tbxTVA.Text == string.Empty)
            {
                tbxTVAMontant.Text = "0.00";
                return;
            }

            if (decimal.TryParse(tbxMontant.Text, out decimal montant) &&
                decimal.TryParse(tbxTVA.Text, out decimal tva))
            {
                tbxTVAMontant.Text = (montant * tva / 100).ToString("0.00");
            }
            else
            {
                tbxTVAMontant.Text = "0.00";
            }


            if (tbxMontant.Text == string.Empty || tbxTVAMontant.Text == string.Empty)
            {
                tbxTotale.Text = "0.00";
                return;
            }

            tbxTotale.Text = (Convert.ToDecimal(tbxMontant.Text) + Convert.ToDecimal(tbxTVAMontant.Text)).ToString("0.00");
        }

        private void tbxTVAMontant_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant.Text == string.Empty || tbxTVAMontant.Text == string.Empty)
            {
                tbxTotale.Text = "0.00";
                return;
            }

            if (decimal.TryParse(tbxMontant.Text, out decimal montant) &&
                decimal.TryParse(tbxTVAMontant.Text, out decimal tva))
            {
                tbxTotale.Text = (montant + tva).ToString("0.00");
            }
            else
                tbxTotale.Text = "0.00";

        }

        private void tbxDesignation_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch) return;

            if (tbxDesignation.Text.Length == 0)
            {
                dgvDesignation.Visible = false;
                return;
            }

            dgvDesignation.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvDesignation.DataSource = produits;

            dgvDesignation.Columns[0].Visible = false;
            for (int i = 2; i < dgvDesignation.Columns.Count; i++)
                dgvDesignation.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Nom_Produit LIKE '%{tbxDesignation.Text}%'";

            if (dv.Count == 0)
                dgvDesignation.Visible = false;
        }
        private void dgvDesignation_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch = true;

            tbxReference.Text = dgvDesignation.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation.Text = dgvDesignation.CurrentRow.Cells[1].Value.ToString();
            tbxPUHT.Text = dgvDesignation.CurrentRow.Cells[4].Value.ToString();
            tbxTVA.Text = dgvDesignation.CurrentRow.Cells[5].Value.ToString();
            tbxTVAMontant.Text = dgvDesignation.CurrentRow.Cells[6].Value.ToString();

            dgvDesignation.Visible = false;

            _suppressSearch = false;
        }
        private void tbxTVA_TextChanged(object sender, EventArgs e)
        {
            if (tbxMontant.Text == string.Empty || tbxTVA.Text == string.Empty)
            {
                tbxTVAMontant.Text = "0.00";
                return;
            }
            if (decimal.TryParse(tbxMontant.Text, out decimal montant) &&
                decimal.TryParse(tbxTVA.Text, out decimal tva))
            {
                tbxTVAMontant.Text = (montant * tva / 100).ToString("0.00");
            }
            else
            {
                tbxTVAMontant.Text = "0.00";
            }
        }
        private DateTime GenerateDateDelai()
        {
            int Année = Produit.FindByReference(tbxReference.Text).Category_Delai_Année;
            int Mois = Produit.FindByReference(tbxReference.Text).Category_Delai_Mois;

            DateTime dateDelai = (DateTime.Parse(tbxDate.Text)).AddYears(Année).AddMonths(Mois);
            return dateDelai;
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            bool result = false;
            int payement = 0, cheque = 0;
            if (cbxPayement.Checked) payement = 1;
            if(cbxCheck.Checked) cheque = 1;    
            if (patient.est_Assure == 1)
            {
                result = Facture.CreateFacture(DateTime.Parse(tbxDate.Text), Numero_Patient, tbxReference.Text,payement,cheque, Convert.ToInt32(tbxQuantity.Text), Convert.ToDecimal(tbxTVAMontant.Text), Convert.ToDecimal(tbxTotale.Text), int.Parse(tbxTVA.Text), tbxCentrePayeurPatient.Text, GenerateDateDelai());
            }
            else
            {
                result = Facture.CreateFacture(DateTime.Parse(tbxDate.Text), Numero_Patient, tbxReference.Text, payement, cheque, Convert.ToInt32(tbxQuantity.Text), Convert.ToDecimal(tbxTVAMontant.Text), Convert.ToDecimal(tbxTotale.Text), int.Parse(tbxTVA.Text), tbxCentrePayeurAssure.Text, GenerateDateDelai());
            }
            if (result)
            {
                MessageBox.Show("Facture a été créé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Erreur lors de la création du facture.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }

    }
}
