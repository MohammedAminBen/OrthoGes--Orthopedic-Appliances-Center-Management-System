using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CodeSource
{
        public class Accord
        {
            public int Accord_ID { get; set; }
            public string Numero_Patient { get; set; }
            public DateTime Date_Accord { get; set; }
            public string Etat_Accord { get; set; }
            public string Mesures { get; set; }
            public string Reference_Produit { get; set; }
            public int Delai_Accord { get; set; }
            public int Quantity { get; set; }

            public Accord(int accordID, string numeroPatient, DateTime dateAccord, string etatAccord, string mesures, string referenceProduit, int delaiAccord,int quantity)
            {
                Accord_ID = accordID;
                Numero_Patient = numeroPatient;
                Date_Accord = dateAccord;
                Etat_Accord = etatAccord;
                Mesures = mesures;
                Reference_Produit = referenceProduit;
                Delai_Accord = delaiAccord;
                Quantity = quantity;
            }

            public static Accord FindByID(int accordID)
            {
                string numeroPatient = "";
                DateTime dateAccord = DateTime.MinValue;
            string etatAccord = "";
                string mesures = "";
                string referenceProduit = "";
                int delaiAccord = 0;
            int quantity = 0;

                bool found = AccordData.GetAccordByID(accordID, ref numeroPatient, ref dateAccord, ref etatAccord, ref mesures, ref referenceProduit, ref delaiAccord,ref quantity);

                if (found)
                    return new Accord(accordID, numeroPatient, dateAccord, etatAccord, mesures, referenceProduit, delaiAccord,quantity);
                else
                    return null;
            }

            public static bool CreateAccord(string numeroPatient, DateTime dateAccord, string etatAccord, string mesures, string referenceProduit, int delaiAccord,int quantity)
            {
                return AccordData.CreateAccord(numeroPatient, dateAccord, etatAccord, mesures, referenceProduit, delaiAccord,quantity);
            }

            public static DataTable GetAll()
            {
                return AccordData.GetAllAccords();
            }

            public static DataTable GetAllByPatient(string numeroPatient)
            {
                return AccordData.GetAccordsByPatient(numeroPatient);
            }

            public static bool UpdateEtatAccord(int accordID, string etatAccord)
            {
                return AccordData.UpdateEtatAccord(accordID, etatAccord);
            }

            public static bool DeleteAccord(int accordID)
            {
                return AccordData.DeleteAccord(accordID);
            }
            public static DataTable GetAllAccordDeTaches()
            {
            return AccordData.GetAllAccordForTaches();
            }
            public static bool UpdateEtatTachesAccord(int accordID, int etat_tache)
             {
            return AccordData.UpdateTache_etat(accordID, etat_tache);
              }
        

        }
}
