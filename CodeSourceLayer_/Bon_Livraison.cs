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

        public string Reference_Produit { get; set; }
        public string Nom_Produit { get; set; }
        public decimal Prix { get; set; }

        public int Quantity_Produit { get; set; }
        public int TVA { get; set; }
        public decimal Montant_TVA { get; set; }
        public decimal Montant_TTC { get; set; }

        public DateTime Date_Devis { get; set; }
        public string Centre_Payeur { get; set; }
        public string Piece_Produit { get; set; }

        public Bon_Livraison(string numeroBon, string numeroPatient, string referenceProduit, string nomProduit, decimal prix, int quantity, int tva, decimal montantTva, decimal montantTtc, DateTime dateDevis, string centrePayeur, string pieceProduit)
        {
            Numero_Bon = numeroBon;
            Numero_Patient = numeroPatient;
            Reference_Produit = referenceProduit;
            Nom_Produit = nomProduit;
            Prix = prix;
            Quantity_Produit = quantity;
            TVA = tva;
            Montant_TVA = montantTva;
            Montant_TTC = montantTtc;
            Date_Devis = dateDevis;
            Centre_Payeur = centrePayeur;
            Piece_Produit = pieceProduit;
        }
        public static bool CreateBonLiv(string numeroPatient, string referenceProduit, DateTime dateDevis, int quantity, decimal montantTva, decimal montantTtc, string centrePayeur, int tva,string piece_produit)
        {
            return Bon_LivraisonData.CreateBonLiv(numeroPatient, referenceProduit, dateDevis, quantity, montantTva, montantTtc, centrePayeur, tva,piece_produit);
        }

        public static DataTable GetAll()
        {
            return Bon_LivraisonData.GetAllBon();
        }
        public static DataTable GetAllBonDePatient(string numeroPatient)
        {
            return Bon_LivraisonData.GetAllBonDePatient(numeroPatient);
        }
    }
}
