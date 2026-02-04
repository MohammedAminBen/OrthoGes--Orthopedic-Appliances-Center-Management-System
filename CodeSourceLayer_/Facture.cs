using DataLayer_;
using System;
using System.Data;

namespace CodeSourceLayer_
{
    public class Facture
    {
        public string Numero_Facture { get; set; }
        public string Numero_Patient { get; set; }
        public decimal Montant_TTC { get; set; }
        public DateTime Date_Facture { get; set; }
        public string Centre_Payeur { get; set; }
        public int Etat_Payement { get; set; }
        public int Payement_Cheque { get; set; }
        public List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA, DateTime Date_Delai)> Produits { get; set; } = new();




        public Facture(string numeroFacture, string numeroPatient, decimal montantTtc, DateTime dateFacture, string centrePayeur, int etatPayement, int payementCheque, List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA, DateTime Date_Delai)> produit)
        {
            Numero_Facture = numeroFacture;
            Numero_Patient = numeroPatient;
            Montant_TTC = montantTtc;
            Date_Facture = dateFacture;
            Centre_Payeur = centrePayeur;
            Etat_Payement = etatPayement;
            Payement_Cheque = payementCheque;
            Produits = produit;
        }
        public static Facture FindByNumeroFacture(string numeroFacture)
        {
            string numeropatient = "";
            decimal montantttc = 0;
            DateTime dateFacture = DateTime.MinValue;
            string centrepayeur = "";
            int etatpayement = 0;
            int payementcheque = 0;
            bool found = FactureData.GetFactureData(numeroFacture, ref numeropatient, ref dateFacture, ref etatpayement, ref payementcheque, ref montantttc, ref centrepayeur);
            if (found)
            {
                return new Facture(numeroFacture, numeropatient, montantttc, dateFacture, centrepayeur, etatpayement, payementcheque, FactureData.GetFactureProduits(numeroFacture));
            }
            else
            {
                return null;
            }
        }

        public static string CreateFacture(string num,DateTime dateFacture, string numeroPatient, int etatPayement, int payementCheque, decimal montantTtc, string centrePayeur, List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA, DateTime Date_Delai)> produit)
        {
            return FactureData.CreateFacture(num,dateFacture, numeroPatient, etatPayement, payementCheque, montantTtc, centrePayeur, produit);
        }

        public static DataTable GetAll()
        {
            return FactureData.GetAllFactures();
        }

        public static DataTable GetAllFacturesDePatient(string numeroPatient)
        {
            return FactureData.GetAllFacturesDePatient(numeroPatient);
        }

        public static bool UpdateEtatPayement(string numeroFacture, int etatPayement)
        {
            return FactureData.UpdatePayement(numeroFacture, etatPayement);
        }

        public static bool UpdatePayementCheque(string numeroFacture, int payementCheque)
        {
            return FactureData.UpdateChèque(numeroFacture, payementCheque);
        }
        public static bool DeleteFacture(string numeroFacture)
        {
            return FactureData.DeleteFacture(numeroFacture);
        }
        public static DataTable GetAllFactureDeTaches()
        {
            return FactureData.GetAllFacturesForTaches();
        }
        public static bool UpdateTache_etat(string Numero_facture, string reference_produit)
        {
            return FactureData.UpdateTache_etat(Numero_facture, reference_produit);
        }
        public static int GetFactureCount()
        {
            return FactureData.GetFacturesCount();
        }
        public static bool UpdateFacture(string numero, DateTime dateDevis, decimal montant, string centrePayeur,int etat,int check)
        {
            return FactureData.UpdateFacture(numero, dateDevis, montant, centrePayeur, etat,check);
        }
        public static bool UpdateFacture_Produits(string facture, string oldReference, string reference, int quantity, decimal montantTva, decimal montantTtc, int tva)
        {
            return FactureData.UpdateFacture_Produits(facture, oldReference, reference, quantity, montantTva, montantTtc, tva);
        }
        public static string GetlastFactureNum()
        {
            return FactureData.GenerateNumeroFacture();
        }
    }

}
