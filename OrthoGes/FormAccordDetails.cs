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
    public partial class FormAccordDetails : Form
    {
        private int PersonID = -1;
        private int Accord_ID = 0;
        Person person;
        Patient patient;
        Assure assure;
        Accord accord;
        Produit produit;
        private bool _suppressSearch = false;
        public FormAccordDetails(int numero_patient)
        {
            InitializeComponent();
             Accord_ID= numero_patient;
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
            this.btnAnnuler.Location = new System.Drawing.Point(643, 727);
            this.lblD.Location = new System.Drawing.Point(378, 737);
            this.tbxDate.Location = new System.Drawing.Point(448, 730);
            this.Size = new Size(807, 845);
        }
        private void LoadData()
        {
            accord = Accord.FindByID(Accord_ID);
            patient = Patient.FindByNumeroPatient(accord.Numero_Patient);
            tbxDate.Text = accord.Date_Accord.ToString("d");
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

            produit = Produit.FindByReference(accord.Reference_Produit);
            tbxReference.Text = produit.Reference;
            tbxDesignation.Text = produit.Nom_Produit;
            tbxDelai.Text = accord.Delai_Accord.ToString();
            tbxQuantity.Text = accord.Quantity.ToString();
            tbxMesure.Text = accord.Mesures;
            cmbxEtat.Text = accord.Etat_Accord;
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
