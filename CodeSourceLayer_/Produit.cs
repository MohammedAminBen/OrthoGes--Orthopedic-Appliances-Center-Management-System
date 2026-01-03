using DataLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSourceLayer_
{
    public class Produit
    {
        public string Reference { get; set; }
        public string Nom_Produit { get; set; }
        public double Prix { get; set; }
        public int TVA { get; set; }
        public double Prix_TVA { get; set; }
        public int Quantite { get; set; }

        public int Category_ID { get; set; }
        public string Category_Nom { get; set; }
        public int Category_Delai_Année { get; set; }
        public int Category_Delai_Mois { get; set; }

        public Produit(string reference, string nomProduit, double prix, int tva, double prixTva, int quantite, int categoryId, string categoryNom, int categoryDelaiAnnée, int categoryDelaiMois)
        {
            Reference = reference;
            Nom_Produit = nomProduit;
            Prix = prix;
            TVA = tva;
            Prix_TVA = prixTva;
            Quantite = quantite;
            Category_ID = categoryId;
            Category_Nom = categoryNom;
            Category_Delai_Année = categoryDelaiAnnée;
            Category_Delai_Mois = categoryDelaiMois;
        }

        // 🔹 SAME PATTERN AS Assure.FindByID
        public static Produit FindByReference(string reference)
        {
            string designation = string.Empty;
            double tarif = 0;
            int tva = 0;
            double tarifTTC = 0;
            int quantite = 0;
            int categoryID = 0;
            string categoryNom = string.Empty;
            int delaiAnnée = 0;
            int delaiMois = 0;

            bool isFound = DataLayer_.ProduitData.GetProduitInfoByReference(reference, ref designation, ref tarif, ref tva, ref tarifTTC, ref quantite, ref categoryID, ref categoryNom, ref delaiAnnée, ref delaiMois);

            if (isFound)
            {
                return new Produit(reference, designation, tarif, tva, tarifTTC, quantite, categoryID, categoryNom, delaiAnnée, delaiMois);
            }

            return null;
        }
        public static DataTable GetAllProduits()
        {
            return DataLayer_.ProduitData.GetAllProduits();
        }
        public static DataTable GetAllCategories()
        {
            return ProduitData.GetAllCategories();
        }
    }
}
