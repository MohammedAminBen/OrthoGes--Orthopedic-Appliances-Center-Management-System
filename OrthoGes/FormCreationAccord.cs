using CodeSource;
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
    public partial class FormCreationAccord : Form
    {
        private int PersonID = -1;
        private string Numero_Patient = null;
        Person person;
        Patient patient;
        Assure assure;
        private bool _suppressSearch = false;
        public FormCreationAccord(string numero_patient)
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
            gbxContact.Location = new Point(11, 336);
            gbxProduit.Location = new System.Drawing.Point(11, 498);
            this.btnEnregistrer.Location = new System.Drawing.Point(477, 730);
            this.btnAnnuler.Location = new System.Drawing.Point(643, 727);
            this.lblD.Location = new System.Drawing.Point(219, 737);
            this.tbxDate.Location = new System.Drawing.Point(288, 730);
            this.Size = new Size(807, 845);
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
            //tbxTVAMontant.Text = dgvProduits.CurrentRow.Cells[6].Value.ToString();

            dgvProduits.Visible = false;

            _suppressSearch = false;

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

            dgvDesignation.Visible = false;

            _suppressSearch = false;
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
           if(Accord.CreateAccord(patient.NumeroPatient, DateTime.Parse(tbxDate.Text), cmbxEtat.Text, tbxMesure.Text, tbxReference.Text, 0, int.Parse(tbxQuantity.Text)))
            {
                
                    MessageBox.Show("Accord a été créé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
            }
        }

    }
}
