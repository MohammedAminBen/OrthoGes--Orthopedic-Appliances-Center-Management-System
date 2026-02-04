
using CodeSourceLayer_;
using Guna.UI2.WinForms;
using SMS_UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes_New_Version
{
    public partial class FormTabDeBord : Form
    {

        public FormTabDeBord()
        {
            InitializeComponent();

        }
        public void FillTachesData()
        {
            flowLayoutPanel1.Controls.Clear();
            DataTable Tachedt = Tache.GetAll();
            if (Tachedt.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow row in Tachedt.Rows)
            {

                int TacheID = (int)row["Tache_ID"];

                TacheUserControl userControl = new TacheUserControl(TacheID, this);
                flowLayoutPanel1.Controls.Add(userControl);
            }
        }

        private void btnAjouteraugroup_Click(object sender, EventArgs e)
        {
            FormAjouterTache frmtache = new FormAjouterTache();
            frmtache.ShowDialog();
            FillTachesData();
        }

        private void CheckifthereisFactureForTaches()
        {
            DataTable facDT = Facture.GetAllFactureDeTaches();
            foreach (DataRow row in facDT.Rows)
            {
                string numeroFacture = row["Numero_Facture"]?.ToString() ?? "";
                if (Facture.FindByNumeroFacture(numeroFacture) != null)
                {
                    AjouterTachePourFacture(Facture.FindByNumeroFacture(numeroFacture));
                }
            }
        }
        private void CheckifthereisAccordForTaches()
        {
            DataTable accordDT = Accord.GetAllAccordDeTaches();
            foreach (DataRow row in accordDT.Rows)
            {
                int accordID = (int)row["Accord_ID"];
                if (Accord.FindByID(accordID) != null)
                {
                    AjouterTachePourAccord(Accord.FindByID(accordID));
                }
            }
        }
        private void AjouterTachePourFacture(Facture facture)
        {
            Person person = Person.Find(Patient.FindByNumeroPatient(facture.Numero_Patient).PersonID);
            string lblTelephonePatient = person.Telephones[0];
            if (person.Telephones.Length > 1)
            {
                lblTelephonePatient += "/" + person.Telephones[1];
                if (person.Telephones.Length > 2) lblTelephonePatient += "/" + person.Telephones[2];
            }
            //string TacheDescription = $"Appeler le patient N° {facture.Numero_Facture} – {person.NomEtPrenom} (Tél : {lblTelephonePatient}) afin de renouveler le produit {}.";

            //Tache.CreateTache(TacheDescription,facture.Numero_Facture,DateTime.Now,0,0);
            // Facture.UpdateTache_etat(facture.Numero_Facture);
        }
        private void AjouterTachePourAccord(Accord accord)
        {
            Person person = Person.Find(Patient.FindByNumeroPatient(accord.Numero_Patient).PersonID);
            string lblTelephonePatient = person.Telephones[0];
            if (person.Telephones.Length > 1)
            {
                lblTelephonePatient += "/" + person.Telephones[1];
                if (person.Telephones.Length > 2) lblTelephonePatient += "/" + person.Telephones[2];
            }
            string TacheDescription = $"Appeler le patient N° {accord.Numero_Patient} – {person.NomEtPrenom} (Tél : {lblTelephonePatient}) afin de l’informer que le produit est prêt.";

            Tache.CreateTache(TacheDescription, accord.Accord_ID.ToString(), DateTime.Now, 0, 0);
            Accord.UpdateEtatTachesAccord(accord.Accord_ID, 1);
        }
        public void RefreshTaches()
        {
            lblAccord.Text = Accord.GetAccordsCount().ToString();
            nmbrEleves.Text = Patient.GetPatientsCount().ToString();
            lblbondelivraison.Text = Bon_Livraison.GetBonsCount().ToString();
            lblDevis.Text = Devis.GetDevisCount().ToString();
            lblfacture.Text = Facture.GetFactureCount().ToString();
            CheckifthereisFactureForTaches();
            CheckifthereisAccordForTaches();
            FillTachesData();
        }
        private void FormTabDeBord_Load(object sender, EventArgs e)
        {
            lblAccord.Text = Accord.GetAccordsCount().ToString();
            nmbrEleves.Text = Patient.GetPatientsCount().ToString();
            lblbondelivraison.Text = Bon_Livraison.GetBonsCount().ToString();
            lblDevis.Text = Devis.GetDevisCount().ToString();
            lblfacture.Text = Facture.GetFactureCount().ToString();
            CheckifthereisFactureForTaches();
            CheckifthereisAccordForTaches();
            FillTachesData();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
