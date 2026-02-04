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
            cmbxEtat.Location = new Point(67, 734);
            lblEtat.Location = new Point(7, 739);
            this.Size = new Size(810, 845);
        }
        private void LoadData()
        {
            accord = Accord.FindByID(Accord_ID);
            if(accord == null)
            {
                return;
            }
            patient = Patient.FindByNumeroPatient(accord.Numero_Patient);
            tbxDate.Text = accord.Date_Accord.ToString("d");
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

            if (accord.Produits.Count >= 1)
            {
                Produit p1 = Produit.FindByReference(accord.Produits[0].Reference);
                tbxReference.Text = p1.Reference;
                tbxDesignation.Text = p1.Nom_Produit;
                tbxQuantity.Text = accord.Produits[0].Quantity.ToString();
                tbxDescription.Text = accord.Produits[0].Description;
                if (accord.Produits.Count >= 2)
                {
                    Produit p2 = Produit.FindByReference(accord.Produits[1].Reference);
                    tbxReference2.Text = p2.Reference;
                    tbxDesignation2.Text = p2.Nom_Produit;
                    tbxQuantity2.Text = accord.Produits[1].Quantity.ToString();
                    tbxDescription2.Text = accord.Produits[1].Description;
                    pnlProduit2.Visible = true;
                    if (accord.Produits.Count >= 3)
                    {
                        Produit p3 = Produit.FindByReference(accord.Produits[2].Reference);
                        tbxReference3.Text = p3.Reference;
                        tbxDesignation3.Text = p3.Nom_Produit;
                        tbxQuantity3.Text = accord.Produits[2].Quantity.ToString();
                        tbxDescription3.Text = accord.Produits[2].Description;
                        pnlProduit3.Visible = true;
                    }
                }

                cmbxEtat.Text = accord.Etat_Accord;
            }
        }
        private void FormCreationDevis_Load(object sender, EventArgs e)
        {
            pnlProduit2.Visible = false;
            pnlProduit3.Visible = false;
            LoadData();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
