using DataLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSourceLayer_
{
    public class Recouvrement
    {
        public int Recouvrement_ID { get; set; }
        public DateTime Date_Facture { get; set; }
        public string Numero_Facture { get; set; }
        public string Numero_Patient { get; set; }
        public string Etat_Payement { get; set; }
        public string Payement_Cheque { get; set; }
        public string Centre_Payeur { get; set; }
        public decimal Montant_TTC { get; set; }

        public Recouvrement(int recouvrementID, DateTime dateFacture, string numeroFacture, string numeroPatient, string etatPayement, string payementCheque, string centrePayeur,decimal montant_TTC)
        {
            Recouvrement_ID = recouvrementID;
            Date_Facture = dateFacture;
            Numero_Facture = numeroFacture;
            Numero_Patient = numeroPatient;
            Etat_Payement = etatPayement;
            Payement_Cheque = payementCheque;
            Centre_Payeur = centrePayeur;
            Montant_TTC = montant_TTC;
        }

        // =========================
        // FIND BY ID
        // =========================
        public static Recouvrement FindByID(int recouvrementID)
        {
            DateTime dateFacture = DateTime.MinValue;
            string numeroFacture = "";
            string numeroPatient = "";
            string etatPayement = "";
            string payementCheque = "";
            string centrePayeur = "";
            decimal montant = 0;

            bool found = RecouvrementData.GetRecouvrementByID(recouvrementID, ref dateFacture, ref numeroFacture, ref numeroPatient, ref etatPayement, ref payementCheque, ref centrePayeur,ref montant);

            if (!found)
                return null;

            return new Recouvrement(recouvrementID, dateFacture, numeroFacture, numeroPatient, etatPayement, payementCheque, centrePayeur,montant);
        }

        public static int CreateRecouvrement(string numeroFacture, DateTime dateFacture, string numeroPatient, string etatPayement, string payementCheque, string centrePayeur,decimal montant)
        {
            return RecouvrementData.CreateRecouvrement(numeroFacture, dateFacture, numeroPatient, etatPayement, payementCheque, centrePayeur, montant);
        }
        public static DataTable GetAll()
        {
            return RecouvrementData.GetAllRecouvrements();
        }
        public static bool UpdateEtatPayement(string numeroFacture, string etatPayement)
        {
            return RecouvrementData.UpdateEtatPayement(numeroFacture, etatPayement);
        }
        public static bool UpdatePayementCheque(string numeroFacture, string payementCheque)
        {
            return RecouvrementData.UpdatePayementCheque(numeroFacture, payementCheque);
        }
        public static bool Delete(int recouvrementID)
        {
            return RecouvrementData.DeleteRecouvrement(recouvrementID);
        }
        public static DataTable GetRecouvrementsCompleteListe(DateTime datedebut,DateTime datefin,string etat)
        {
            return RecouvrementData.GetRecouvrementsCompleteListe(datedebut, datefin, etat);
        }
    }

}
