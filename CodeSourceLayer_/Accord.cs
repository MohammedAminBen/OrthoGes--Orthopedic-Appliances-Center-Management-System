using DataLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CodeSourceLayer_
{
    public class Accord
    {
        public int Accord_ID { get; set; }
        public string Numero_Patient { get; set; }
        public DateTime Date_Accord { get; set; }
        public string Etat_Accord { get; set; }
        public int Delai_Accord { get; set; }

        public List<(string Reference, string Description, int Quantity)> Produits { get; set; } = new();

        public Accord(int accordID, string numeroPatient, DateTime dateAccord, string etatAccord, int delaiAccord, List<(string Reference, string Description, int Quantity)> produits)
        {
            Accord_ID = accordID;
            Numero_Patient = numeroPatient;
            Date_Accord = dateAccord;
            Etat_Accord = etatAccord;
            Delai_Accord = delaiAccord;
            Produits = produits;
        }

        // =========================
        // FIND BY ID
        // =========================
        public static Accord FindByID(int accordID)
        {
            string numeroPatient = "", etatAccord = "";
            DateTime dateAccord = DateTime.MinValue;
            int delaiAccord = 0;

            bool found = AccordData.GetAccordData(accordID, ref numeroPatient, ref dateAccord, ref etatAccord, ref delaiAccord);

            if (!found)
                return null;

            var produits = AccordData.GetAccordProduits(accordID);

            return new Accord(accordID, numeroPatient, dateAccord, etatAccord, delaiAccord, produits);
        }

        // =========================
        // CREATE
        // =========================
        public static int CreateAccord(string numeroPatient, DateTime dateAccord, string etatAccord, int delaiAccord, List<(string Reference, string Description, int Quantity)> produits)
        {
            return AccordData.CreateAccord(numeroPatient, dateAccord, etatAccord, delaiAccord, produits);
        }

        // =========================
        // GET LISTS
        // =========================
        public static DataTable GetAll()
        {
            return AccordData.GetAllAccords();
        }

        public static DataTable GetAllByPatient(string numeroPatient)
        {
            return AccordData.GetAccordsByPatient(numeroPatient);
        }

        // =========================
        // UPDATES
        // =========================
        public static bool UpdateEtatAccord(int accordID, string etatAccord)
        {
            return AccordData.UpdateEtatAccord(accordID, etatAccord);
        }

        public static bool DeleteAccord(int accordID)
        {
            return AccordData.DeleteAccord(accordID);
        }

        // =========================
        // TACHES
        // =========================
        public static DataTable GetAllAccordDeTaches()
        {
            return AccordData.GetAllAccordForTaches();
        }

        public static bool UpdateEtatTachesAccord(int accordID, int etatTache)
        {
            return AccordData.UpdateTache_etat(accordID, etatTache);
        }
        public static int GetAccordsCount() => AccordData.GetAccordsCount();

        public static bool UpdateAccord(int accordid, DateTime dateAccord, string etatAccord, int delaiAccord)
        {
            return AccordData.UpdateAccord(accordid, dateAccord, etatAccord, delaiAccord);
        }
        public static bool UpdateAccord_Produits(int Accord, string oldReference, string Reference, string Description, int Quantity)
        {
            return AccordData.UpdateAccord_Produits(Accord, oldReference, Reference, Description, Quantity);
        }
    }
}
