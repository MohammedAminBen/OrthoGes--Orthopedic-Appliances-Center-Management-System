using DataLayer_;
using System;
using System.Data;

namespace CodeSourceLayer_
{
    public class Devis
    {
        public string Numero_Devis { get; set; }
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

        public Devis(string numeroDevis,string numeroPatient,string referenceProduit,string nomProduit,decimal prix,int quantity,int tva,decimal montantTva,decimal montantTtc,DateTime dateDevis,string centrePayeur)
        {
            Numero_Devis = numeroDevis;
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
        }
        public static bool CreateDevis(string numeroPatient,string referenceProduit,DateTime dateDevis,int quantity,decimal montantTva,decimal montantTtc,string centrePayeur,int tva)
        {
            return DevisData.CreateDevis(numeroPatient,referenceProduit,dateDevis,quantity,montantTva,montantTtc,centrePayeur,tva);
        }

        public static DataTable GetAll()
        {
            return DevisData.GetAllDevis();
        }
        public static DataTable GetAllDevisDePatient(string numeroPatient)
        {
            return DevisData.GetAllDevisDePatient(numeroPatient);
        }
    }
}
