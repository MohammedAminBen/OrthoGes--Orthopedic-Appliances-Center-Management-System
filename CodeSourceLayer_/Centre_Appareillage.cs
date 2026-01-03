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
        public string Contact { get; set; }
        public string NumeroRC { get; set; }
        public string NIF { get; set; }
        public string RIB { get; set; }
        public string NumeroART { get; set; }
        public string PathImage { get; set; }

        // Default constructor
        public Centre_Appareillage()
        {
            CentreID = -1;
            CentreNom = string.Empty;
            Adresse = string.Empty;
            Contact = string.Empty;
            NumeroRC = string.Empty;
            NIF = string.Empty;
            RIB = string.Empty;
            NumeroART = string.Empty;
            PathImage = string.Empty;
        }

        // Private constructor for loading existing data
        private Centre_Appareillage(int centreID, string centreNom, string adresse, string contact,
                                    string numeroRC, string nif, string rib, string numeroART, string pathImage)
        {
            CentreID = centreID;
            CentreNom = centreNom;
            Adresse = adresse;
            Contact = contact;
            NumeroRC = numeroRC;
            NIF = nif;
            RIB = rib;
            NumeroART = numeroART;
            PathImage = pathImage;
        }

        // Add new centre
        public bool AddNewCentre()
        {
            CentreID = Centre_AppareillageData.AddNewCentre(CentreNom, Adresse, Contact, NumeroRC, NIF, RIB, NumeroART, PathImage);
            return CentreID != -1;
        }

        // Update centre
        public bool UpdateCentre()
        {
            return Centre_AppareillageData.UpdateCentre(CentreID, CentreNom, Adresse, Contact, NumeroRC, NIF, RIB, NumeroART, PathImage);
        }

        // Find centre by ID
        public static Centre_Appareillage Find(int centreID)
        {
            string centreNom = string.Empty;
            string adresse = string.Empty;
            string contact = string.Empty;
            string numeroRC = string.Empty;
            string nif = string.Empty;
            string rib = string.Empty;
            string numeroART = string.Empty;
            string pathImage = string.Empty;

            bool isFound = Centre_AppareillageData.GetCentreByID(centreID, ref centreNom, ref adresse, ref contact,
                                                               ref numeroRC, ref nif, ref rib, ref numeroART, ref pathImage);

            if (isFound)
            {
                return new Centre_Appareillage(centreID, centreNom, adresse, contact, numeroRC, nif, rib, numeroART, pathImage);
            }

            return null;
        }
    }
}
