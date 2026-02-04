using DataLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSourceLayer_
{
    public class Bon_Livraison
    {
        public string Numero_Bon { get; set; }
        public string Numero_Patient { get; set; }
        public DateTime Date_Bon { get; set; }
        public string Centre_Payeur { get; set; }
        public decimal Montant_TTC { get; set; }
        public string PieceProduit;
        public List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA)> Produits { get; set; } = new();

        public Bon_Livraison(string numeroBon, string numeroPatient, DateTime dateBon, string centrePayeur, string pieceProduit, decimal montant, List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA)> produits)
        {
            Numero_Bon = numeroBon;
            Numero_Patient = numeroPatient;
            Date_Bon = dateBon;
            Centre_Payeur = centrePayeur;
            PieceProduit = pieceProduit;
            Produits = produits;
            Montant_TTC = montant;
        }

        public static Bon_Livraison FindByNumeroBon(string numeroBon)
        {
            string numeroPatient = "", centrePayeur = "";
            DateTime dateBon = DateTime.MinValue;
            string piece = "";
            decimal montant = 0;
            bool found = Bon_LivraisonData.GetBonLivData(numeroBon, ref numeroPatient, ref dateBon, ref centrePayeur, ref piece, ref montant);

            if (!found) return null;

            return new Bon_Livraison(numeroBon, numeroPatient, dateBon, centrePayeur, piece, montant, Bon_LivraisonData.GetBonLivProduits(numeroBon));
        }

        public static string CreateBonLiv(string Num,DateTime dateBon, string numeroPatient, string centrePayeur, string piece, decimal Montant_TTC, List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA)> produits)
        {
            return Bon_LivraisonData.CreateBonLiv(Num,dateBon, numeroPatient, centrePayeur, piece, Montant_TTC, produits);
        }

        public static DataTable GetAll()
        {
            return Bon_LivraisonData.GetAllBon();
        }

        public static DataTable GetAllBonDePatient(string numeroPatient)
        {
            return Bon_LivraisonData.GetAllBonDePatient(numeroPatient);
        }

        public static bool DeleteBon_Livraison(string numeroBon)
        {
            return Bon_LivraisonData.DeleteBon_Livraison(numeroBon);
        }

        public static int GetBonsCount()
        {
            return Bon_LivraisonData.GetBonsCount();
        }

        public static bool UpdateBon(string numero, DateTime dateBon, decimal Montant, string CentrePayeur, string Piece)
        {
            return Bon_LivraisonData.UpdateBon(numero, dateBon, Montant, CentrePayeur, Piece);
        }
        public static bool UpdateBon_Produits(string Bon,string oldReference,string reference,int quantity, decimal Montanttva, decimal Montantttc, int tva)
        {
            return Bon_LivraisonData.UpdateBon_Produits(Bon, oldReference, reference, quantity, Montanttva, Montantttc, tva);
        }
        public static string GetLastBonNum()
        {
            return Bon_LivraisonData.GenerateNumeroBon();
        }

    }
}
