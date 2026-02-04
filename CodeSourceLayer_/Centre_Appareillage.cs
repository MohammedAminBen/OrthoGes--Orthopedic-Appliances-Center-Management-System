using DataLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSourceLayer_
{
    public class Centre_Appareillage
    {
        public int CentreID { get; set; }
        public string CentreNom { get; set; }
        public string Adresse { get; set; }
        public string Mobile { get; set; }
        public string NumeroRC { get; set; }
        public string NIF { get; set; }
        public string RIB { get; set; }
        public string NumeroART { get; set; }
        public string PathImage { get; set; }
        public string FAX { get; set; }
        public string Description_Centre { get; set; }

        // Default constructor
        public Centre_Appareillage()
        {
            CentreID = -1;
            CentreNom = string.Empty;
            Adresse = string.Empty;
            Mobile = string.Empty;
            NumeroRC = string.Empty;
            NIF = string.Empty;
            RIB = string.Empty;
            NumeroART = string.Empty;
            PathImage = string.Empty;
            FAX = string.Empty;
            Description_Centre = string.Empty;
        }

        // Private constructor for loading existing data
        private Centre_Appareillage(int centreID, string centreNom, string adresse, string mobile,
                                    string numeroRC, string nif, string rib, string numeroART, string pathImage,string fax,string description)
        {
            CentreID = centreID;
            CentreNom = centreNom;
            Adresse = adresse;
            Mobile = mobile;
            NumeroRC = numeroRC;
            NIF = nif;
            RIB = rib;
            NumeroART = numeroART;
            PathImage = pathImage;
            FAX = fax;
            Description_Centre = description;
        }

        // Add new centre
        public bool AddNewCentre()
        {
            CentreID = Centre_AppareillageData.AddNewCentre(CentreNom, Adresse, Mobile, NumeroRC, NIF, RIB, NumeroART, PathImage,FAX,Description_Centre);
            return CentreID != -1;
        }

        // Update centre
        public bool UpdateCentre()
        {
            return Centre_AppareillageData.UpdateCentre(CentreID, CentreNom, Adresse,Mobile, NumeroRC, NIF, RIB, NumeroART, PathImage,FAX,Description_Centre);
        }

        // Find centre by ID
        public static Centre_Appareillage Find(int centreID)
        {
            string centreNom = string.Empty;
            string adresse = string.Empty;
            string mobile = string.Empty;
            string numeroRC = string.Empty;
            string nif = string.Empty;
            string rib = string.Empty;
            string numeroART = string.Empty;
            string pathImage = string.Empty;
            string Fax = string.Empty;
            string description = string.Empty;

            bool isFound = Centre_AppareillageData.GetCentreByID(centreID, ref centreNom, ref adresse, ref mobile,
                                                               ref numeroRC, ref nif, ref rib, ref numeroART, ref pathImage,ref Fax,ref description);

            if (isFound)
            {
                return new Centre_Appareillage(centreID, centreNom, adresse, mobile, numeroRC, nif, rib, numeroART, pathImage,Fax,description);
            }

            return null;
        }

        public static DataTable GetAllWillaya()
        { 
            return Centre_AppareillageData.GetAllWillaya();
        }

        public static DataTable GetAllCommuneDeWillaya(int wilayaId)
        {
            return Centre_AppareillageData.GetAllCommuneDeWillaya(wilayaId);
        }
    }
}
