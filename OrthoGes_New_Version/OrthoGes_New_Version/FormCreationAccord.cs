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
    public partial class FormCreationAccord : Form
    {
        private int PersonID = -1;
        private string Numero_Patient = null;
        Person person;
        Patient patient;
        Assure assure;

        private bool _suppressSearchAdd = false;
        private bool _suppressSearch = false;
        private bool _suppressSearch2 = false;
        private bool _suppressSearch3 = false;
        private DataTable communes = new DataTable();
        public static List<(string Reference, string Description, int Quantity)> Produits { get; set; } = new();

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
            cmbxEtat.Location = new System.Drawing.Point(12, 730);
            lblEtat.Location = new System.Drawing.Point(12, 705);
            gbxProduit.Location = new System.Drawing.Point(11, 498);
            this.btnEnregistrer.Location = new System.Drawing.Point(477, 730);
            this.btnAnnuler.Location = new System.Drawing.Point(643, 727);
            this.lblD.Location = new System.Drawing.Point(219, 737);
            this.tbxDate.Location = new System.Drawing.Point(288, 730);
            this.Size = new Size(810, 845);

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
                AssuredCheckedConfig();
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
            pnlProduit3.Visible = false;
            pnlProduit2.Visible = false;
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
            Produits.Clear();

            if (!string.IsNullOrWhiteSpace(tbxQuantity.Text))
            {
                Produits.Add((tbxReference.Text, tbxDescription.Text, int.Parse(tbxQuantity.Text)));
            }

            if (pnlProduit2.Visible && !string.IsNullOrWhiteSpace(tbxQuantity2.Text))
            {
                Produits.Add((tbxReference2.Text, tbxDescription2.Text, int.Parse(tbxQuantity2.Text)));
            }

            if (pnlProduit3.Visible && !string.IsNullOrWhiteSpace(tbxQuantity3.Text))
            {
                Produits.Add((tbxReference3.Text, tbxDescription3.Text, int.Parse(tbxQuantity3.Text)));
            }

            if (Produits.Count == 0)
            {
                MessageBox.Show("Veuillez ajouter au moins un produit.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Accord.CreateAccord(patient.NumeroPatient, DateTime.Parse(tbxDate.Text), cmbxEtat.Text, 0, Produits) != -1)
            {
                MessageBox.Show("Accord a été créé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void dgvDesignation2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbxReference2_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch2) return;

            if (tbxReference2.Text.Length == 0)
            {
                dgvProduit2.Visible = false;
                return;
            }

            dgvProduit2.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvProduit2.DataSource = produits;

            for (int i = 1; i < dgvProduit2.Columns.Count; i++)
                dgvProduit2.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Reference LIKE '%{tbxReference2.Text}%'";

            if (dv.Count == 0)
                dgvProduit2.Visible = false;
        }

        private void tbxDesignation2_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch2) return;

            if (tbxDesignation2.Text.Length == 0)
            {
                dgvDesignation2.Visible = false;
                return;
            }

            dgvDesignation2.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvDesignation2.DataSource = produits;

            dgvDesignation2.Columns[0].Visible = false;
            for (int i = 2; i < dgvDesignation2.Columns.Count; i++)
                dgvDesignation2.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Nom_Produit LIKE '%{tbxDesignation2.Text}%'";

            if (dv.Count == 0)
                dgvDesignation2.Visible = false;
        }

        private void dgvProduit2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch2 = true;

            tbxReference2.Text = dgvProduit2.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation2.Text = dgvProduit2.CurrentRow.Cells[1].Value.ToString();
            //tbxTVAMontant.Text = dgvProduits.CurrentRow.Cells[6].Value.ToString();

            dgvProduit2.Visible = false;

            _suppressSearch2 = false;
        }

        private void dgvDesignation2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch2 = true;

            tbxReference2.Text = dgvDesignation2.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation2.Text = dgvDesignation2.CurrentRow.Cells[1].Value.ToString();

            dgvDesignation2.Visible = false;

            _suppressSearch2 = false;
        }

        private void dgvProduits3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch3 = true;

            tbxReference3.Text = dgvProduits3.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation3.Text = dgvProduits3.CurrentRow.Cells[1].Value.ToString();
            //tbxTVAMontant.Text = dgvProduits3.CurrentRow.Cells[6].Value.ToString();

            dgvProduits3.Visible = false;

            _suppressSearch3 = false;
        }

        private void dgvDesignation3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch3 = true;

            tbxReference3.Text = dgvDesignation3.CurrentRow.Cells[0].Value.ToString();
            tbxDesignation3.Text = dgvDesignation3.CurrentRow.Cells[1].Value.ToString();

            dgvDesignation3.Visible = false;

            _suppressSearch3 = false;
        }

        private void tbxReference3_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch3) return;

            if (tbxReference3.Text.Length == 0)
            {
                dgvProduits3.Visible = false;
                return;
            }

            dgvProduits3.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvProduits3.DataSource = produits;

            for (int i = 1; i < dgvProduits3.Columns.Count; i++)
                dgvProduits3.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Reference LIKE '%{tbxReference3.Text}%'";

            if (dv.Count == 0)
                dgvProduits3.Visible = false;
        }

        private void tbxDesignation3_TextChanged(object sender, EventArgs e)
        {
            if (_suppressSearch3) return;

            if (tbxDesignation3.Text.Length == 0)
            {
                dgvDesignation3.Visible = false;
                return;
            }

            dgvDesignation3.Visible = true;

            DataTable produits = Produit.GetAllProduits();
            dgvDesignation3.DataSource = produits;

            dgvDesignation3.Columns[0].Visible = false;
            for (int i = 2; i < dgvDesignation3.Columns.Count; i++)
                dgvDesignation3.Columns[i].Visible = false;

            DataView dv = produits.DefaultView;
            dv.RowFilter = $"Nom_Produit LIKE '%{tbxDesignation3.Text}%'";

            if (dv.Count == 0)
                dgvDesignation3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pnlProduit2.Visible == false)
            {
                pnlProduit2.Visible = true;


            }
            else
            {
                pnlProduit3.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pnlProduit3.Visible == true)
            {
                pnlProduit3.Visible = false;
            }
            else
            {
                pnlProduit2.Visible = false;
            }
        }

        private void dgvProduits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                _suppressSearch = true;

                tbxReference.Text = dgvProduits.CurrentRow.Cells[0].Value.ToString();
                tbxDesignation.Text = dgvProduits.CurrentRow.Cells[1].Value.ToString();
                //tbxTVAMontant.Text = dgvProduits.CurrentRow.Cells[6].Value.ToString();

                dgvProduits.Visible = false;

                _suppressSearch = false;

            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Optional: keep full-row selection clean
                e.Handled = false; // let DataGridView handle navigation
            }

        }

        private void dgvDesignation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                _suppressSearch = true;

                tbxReference.Text = dgvDesignation.CurrentRow.Cells[0].Value.ToString();
                tbxDesignation.Text = dgvDesignation.CurrentRow.Cells[1].Value.ToString();
                //tbxTVAMontant.Text = dgvProduits.CurrentRow.Cells[6].Value.ToString();

                dgvDesignation.Visible = false;

                _suppressSearch = false;

            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Optional: keep full-row selection clean
                e.Handled = false; // let DataGridView handle navigation
            }
        }

        private void dgvProduit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                _suppressSearch2 = true;
                if(dgvDesignation2.Visible)
                {
                    tbxReference2.Text = dgvDesignation2.CurrentRow.Cells[0].Value.ToString();
                    tbxDesignation2.Text = dgvDesignation2.CurrentRow.Cells[1].Value.ToString();
                    dgvDesignation2.Visible = false;

                }
                else
                {
                    tbxReference2.Text = dgvProduit2.CurrentRow.Cells[0].Value.ToString();
                    tbxDesignation2.Text = dgvProduit2.CurrentRow.Cells[1].Value.ToString();
                    dgvProduit2.Visible = false;

                }

                //tbxTVAMontant.Text = dgvProduits.CurrentRow.Cells[6].Value.ToString();


                _suppressSearch2 = false;

            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Optional: keep full-row selection clean
                e.Handled = false; // let DataGridView handle navigation
            }
        }

        private void dgvProduits3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                _suppressSearch3 = true;

                if (dgvDesignation3.Visible)
                {
                    tbxReference3.Text = dgvDesignation3.CurrentRow.Cells[0].Value.ToString();
                    tbxDesignation3.Text = dgvDesignation3.CurrentRow.Cells[1].Value.ToString();
                    dgvDesignation3.Visible = false;

                }
                else
                {
                    tbxReference3.Text = dgvProduits3.CurrentRow.Cells[0].Value.ToString();
                    tbxDesignation3.Text = dgvProduits3.CurrentRow.Cells[1].Value.ToString();
                    dgvProduits3.Visible = false;

                }

                _suppressSearch3 = false;

            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Optional: keep full-row selection clean
                e.Handled = false; // let DataGridView handle navigation
            }
        }
        
    }
}
