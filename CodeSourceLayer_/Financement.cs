using DataLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSourceLayer_
{
    public class Financement
    {
        public static decimal GetRevenuTotalMensuelle()
        {
            return FinancementData.GetRevenuTotalMensuelle();
        }
        public static decimal GetRevouvrementReelMensuelle()
        {
            return FinancementData.GetRevouvrementReelMensuelle();
        }
        public static decimal GetResterImpayeeMensuelle()
        {
            return FinancementData.GetResterImpayeeMensuelle();
        }
        public static DataTable GetRecouvrementHistorique()
        {
            return FinancementData.GetRecouvrementHistorique();
        }
        public static DataTable GetRecouvrementReelHistorique()
        {
            return FinancementData.GetRecouvrementReelHistorique();
        }
        public static DataTable GetResterImpayerHistorique()
        {
            return FinancementData.GetResterImpayerHistorique();
        }
    }
}
