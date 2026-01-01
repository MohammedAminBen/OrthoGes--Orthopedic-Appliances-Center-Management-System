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
        public int Quantity { get; set; }
        public int TVA { get; set; }
        public decimal Montant_TVA { get; set; }
        public decimal Montant_TTC { get; set; }
        public DateTime Date_Facture { get; set; }
        public string Centre_Payeur { get; set; }
        public int Etat_Payement { get; set; }
        public int Payement_Cheque { get; set; }

        
        public Facture(string numeroFacture, string numeroPatient, string referenceProduit, int quantity, int tva, decimal montantTva, decimal montantTtc, DateTime dateFacture, string centrePayeur, int etatPayement, int payementCheque)
        {
            Numero_Facture = numeroFacture;
            Numero_Patient = numeroPatient;
            Reference_Produit = referenceProduit;
            Quantity = quantity;
            TVA = tva;
            Montant_TVA = montantTva;
            Montant_TTC = montantTtc;
            Date_Facture = dateFacture;
            Centre_Payeur = centrePayeur;
            Etat_Payement = etatPayement;
            Payement_Cheque = payementCheque;
        }
        public static Facture FindByNumeroFacture(string numeroFacture)
        {
            string numeropatient = "";
            string referenceproduit = "";
            int quantity = 0;
            int tva = 0;
            decimal montanttva = 0;
            decimal montantttc = 0;
            DateTime dateFacture = DateTime.MinValue;
            string centrepayeur = "";
            int etatpayement = 0;
            int payementcheque = 0;
            bool found = FactureData.GetFactureByNumeroFacture(numeroFacture, ref numeropatient, ref referenceproduit, ref etatpayement, ref dateFacture, ref payementcheque, ref montanttva, ref montantttc, ref tva, ref quantity, ref centrepayeur);
            if (found)
            {
                return new Facture(numeroFacture, numeropatient, referenceproduit, quantity, tva, montanttva, montantttc, dateFacture, centrepayeur, etatpayement, payementcheque);
            }
            else
            {
                return null;
            }
        }

        public static bool CreateFacture(DateTime dateFacture, string numeroPatient, string referenceProduit, int etatPayement, int payementCheque, int quantity, decimal montantTva, decimal montantTtc, int tva, string centrePayeur, DateTime dateDelai)
        {
            return FactureData.CreateFacture(dateFacture, numeroPatient, referenceProduit, etatPayement, payementCheque, quantity, montantTva, montantTtc, tva, centrePayeur, dateDelai);
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
        public static bool UpdateTache_etat(string Numero_facture)
        {
            return FactureData.UpdateTache_etat(Numero_facture);
        }
    }

}
