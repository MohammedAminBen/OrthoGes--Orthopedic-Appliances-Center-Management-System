using DataLayer;
using System;
using System.Data;

namespace CodeSourceLayer
{
    public class Facture
    {
        public string Numero_Facture { get; set; }
        public string Numero_Patient { get; set; }
        public string Reference_Produit { get; set; }
        public string Nom_Produit { get; set; }
        public decimal Prix { get; set; }
        public int Quantity { get; set; }
        public int TVA { get; set; }
        public decimal Montant_TVA { get; set; }
        public decimal Montant_TTC { get; set; }
        public DateTime Date_Facture { get; set; }
        public string Centre_Payeur { get; set; }
        public int Etat_Payement { get; set; }
        public int Payement_Cheque { get; set; }

        public Facture(string numeroFacture, string numeroPatient, string referenceProduit, string nomProduit, decimal prix, int quantity, int tva, decimal montantTva, decimal montantTtc, DateTime dateFacture, string centrePayeur, int etatPayement, int payementCheque)
        {
            Numero_Facture = numeroFacture;
            Numero_Patient = numeroPatient;
            Reference_Produit = referenceProduit;
            Nom_Produit = nomProduit;
            Prix = prix;
            Quantity = quantity;
            TVA = tva;
            Montant_TVA = montantTva;
            Montant_TTC = montantTtc;
            Date_Facture = dateFacture;
            Centre_Payeur = centrePayeur;
            Etat_Payement = etatPayement;
            Payement_Cheque = payementCheque;
        }

        public static bool CreateFacture(DateTime dateFacture, string numeroPatient, string referenceProduit, int etatPayement, int payementCheque, int quantity, decimal montantTva, decimal montantTtc, int tva, string centrePayeur)
        {
            return FactureData.CreateFacture( dateFacture, numeroPatient, referenceProduit, etatPayement, payementCheque, quantity, montantTva, montantTtc, tva, centrePayeur);
        }

        public static DataTable GetAll()
        {
            return FactureData.GetAllFactures();
        }

        public static DataTable GetAllFacturesDePatient(string numeroPatient)
        {
            return FactureData.GetAllFacturesDePatient(numeroPatient);
        }
    }
}
