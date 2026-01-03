using DataLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSourceLayer_
{
    public class Tache
    {
        public int Tache_ID { get; set; }
        public string Tache_Text { get; set; }
        public string Tache_Type { get; set; }
        public DateTime Tache_Date { get; set; }
        public int Est_Fini { get; set; }
        public int Est_Annuler { get; set; }

        public Tache(int tacheId, string tacheText, string tacheType, DateTime tacheDate, int estFini, int estAnnuler)
        {
            Tache_ID = tacheId;
            Tache_Text = tacheText;
            Tache_Type = tacheType;
            Tache_Date = tacheDate;
            Est_Fini = estFini;
            Est_Annuler = estAnnuler;
        }

        public static Tache FindByID(int tacheId)
        {
            string tacheText = "";
            string tacheType = "";
            DateTime tacheDate = DateTime.MinValue;
            int estFini = 0;
            int estAnnuler = 0;

            bool found = TacheData.GetTacheByID(
                tacheId,
                ref tacheText,
                ref tacheType,
                ref tacheDate,
                ref estFini,
                ref estAnnuler
            );

            if (found)
            {
                return new Tache(tacheId, tacheText, tacheType, tacheDate, estFini, estAnnuler);
            }
            else
            {
                return null;
            }
        }

        public static bool CreateTache(string tacheText, string tacheType, DateTime tacheDate, int estFini, int estAnnuler)
        {
            return TacheData.CreateTache(tacheText, tacheType, tacheDate, estFini, estAnnuler);
        }

        public static DataTable GetAll()
        {
            return TacheData.GetAllTaches();
        }

        public static bool UpdateEtatFini(int tacheId, int estFini)
        {
            return TacheData.UpdateEstFini(tacheId, estFini);
        }

        public static bool UpdateEtatAnnuler(int tacheId, int estAnnuler)
        {
            return TacheData.UpdateEstAnnuler(tacheId, estAnnuler);
        }

        public static bool DeleteTache(int tacheId)
        {
            return TacheData.DeleteTache(tacheId);
        }
        public static bool DeleteTacheByAccord(int tacheId)
        {
            return TacheData.DeleteTacheByAccord(tacheId);
        }
    }

}
