using DataLayer_;
using System;
using System.Data;

namespace CodeSourceLayer_
{
    public class Devis
    {
        public string Numero_Devis { get; set; }
        public string Numero_Patient { get; set; }
        public DateTime Date_Devis { get; set; }
        public string Centre_Payeur { get; set; }

        // List of products for this devis
        public List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA)> Produits { get; set; } = new();
        public decimal Montant_TTC { get; set; }

        // Constructor
        public Devis(string numeroDevis, string numeroPatient, DateTime dateDevis, string centrePayeur, decimal montant_ttc, List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA)> produit)
            => (Numero_Devis, Numero_Patient, Date_Devis, Centre_Payeur, Montant_TTC, Produits) = (numeroDevis, numeroPatient, dateDevis, centrePayeur, montant_ttc, produit);

        // Create Devis method using the list of products in one line
        public static string CreateDevis(string Num,string numeroPatient, DateTime dateDevis, string centrePayeur, List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA)> produits, decimal montant_ttc)
            => DevisData.CreateDevis(Num,numeroPatient, dateDevis, centrePayeur, produits, montant_ttc);

        // Get all devis
        public static Devis FindByNumeroDevis(string numeroDevis)
        {
            string numeroPatient = "", centrePayeur = "";
            decimal montantTTC = 0;
            DateTime dateDevis = DateTime.MinValue;

            bool found = DevisData.GetDevisData(numeroDevis, ref numeroPatient, ref dateDevis, ref montantTTC, ref centrePayeur);

            if (!found)
                return null;

            return new Devis(numeroDevis, numeroPatient, dateDevis, centrePayeur, montantTTC, DevisData.GetDevisProduits(numeroDevis));
        }

        public static DataTable GetAll() => DevisData.GetAllDevis();

        // Get all devis for a patient
        public static DataTable GetAllDevisDePatient(string numeroPatient) => DevisData.GetAllDevisDePatient(numeroPatient);

        public static bool DeleteDevis(string numeroDevis) => DevisData.DeleteDevis(numeroDevis);

        public static int GetDevisCount() => DevisData.GetDevisCount();

        public static bool UpdateDevis(string numero, DateTime dateDevis, decimal montant, string centrePayeur)
        {
            return DevisData.UpdateDevis(numero, dateDevis, montant, centrePayeur);
        }

        public static bool UpdateDevis_Produits(string devis, string oldReference, string reference, int quantity, decimal montantTva, decimal montantTtc, int tva)
        {
            return DevisData.UpdateDevis_Produits(devis, oldReference, reference, quantity, montantTva, montantTtc, tva);
        }

        public static string GenerateNumDevis()
        {
            return DevisData.GenerateNumeroDevis();
        }

    }

}

