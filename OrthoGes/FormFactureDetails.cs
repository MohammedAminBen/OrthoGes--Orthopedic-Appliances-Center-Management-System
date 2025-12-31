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
    public partial class FormFactureDetails : Form
    {
        private int PersonID = -1;
        private string Numero_Facture = null;
        Facture facture;
        Person person;
        Patient patient;
        Assure assure;
        Produit produit;
        private bool _suppressSearch = false;
        public FormFactureDetails(string numero_facture)
        {
            InitializeComponent();
            Numero_Facture = numero_facture;
        }

        private void AssuredCheckedConfig()
        {
            gbxpatient.Size = new Size(766, 278);
            gbxAssure.Visible = false;
            gbxContact.Location = new System.Drawing.Point(11, 336);
            lblnum.Visible = true;
            tbxNumAssPatient.Visible = true;
            guna2GroupBox1.Location = new System.Drawing.Point(11, 502);
            this.btnAnnuler.Location = new System.Drawing.Point(643, 854);
            this.btnEnregistrer.Location = new System.Drawing.Point(477, 855);
            lblD.Location = new Point(218, 865);
            tbxDate.Location = new Point(285, 856);
            this.Size = new Size(805, 960);
        }
        private void LoadData()
        {
            facture = Facture.FindByNumeroFacture(Numero_Facture);
            patient = Patient.FindByNumeroPatient(facture.Numero_Patient);
            produit = Produit.FindByReference(facture.Reference_Produit);
            tbxDate.Text = facture.Date_Facture.ToString("d");
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
                tbxCentrePayeurPatient.Text = facture.Centre_Payeur;

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
                tbxCentrePayeurAssure.Text = facture.Centre_Payeur;
            }
            if(produit == null)
            {
                MessageBox.Show("Error when trying to identify the product");
                return;
            }
            if(facture.Payement_Cheque == 1)
            {
                cbxCheck.Checked = true;
            }
            if (facture.Etat_Payement == 1)
            {
                cbxPayement.Checked = true;
            }
            tbxReference.Text = facture.Reference_Produit;
            tbxDesignation.Text = produit.Nom_Produit;
            tbxPUHT.Text = produit.Prix.ToString("F2");
            tbxQuantity.Text = facture.Quantity.ToString();
            tbxTVA.Text = facture.TVA.ToString();
            tbxTVAMontant.Text = facture.Montant_TVA.ToString("F2");
            tbxMontant.Text = (produit.Prix * facture.Quantity).ToString("F2");
            tbxTotale.Text = facture.Montant_TTC.ToString("F2");

        }
        private void FormCreationDevis_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
