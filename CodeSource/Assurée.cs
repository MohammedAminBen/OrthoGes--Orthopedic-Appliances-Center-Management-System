using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CodeSourceLayer
{
        public class Assure
        {
            public int AssureID { get; set; }
            public int PersonID { get; set; }
            public string NumeroAssurance { get; set; }
            public int CaisseID { get; set; }
            public string CaisseNom { get; set; }
            public string RelationPatient { get; set; }

            // Default constructor
            public Assure()
            {
                AssureID = -1;
                PersonID = -1;
                NumeroAssurance = string.Empty;
                CaisseID = -1;
                CaisseNom = string.Empty;
                RelationPatient = string.Empty;
            }

            // Private constructor for loading existing data
            private Assure(int assureID, int personID, string numeroAssurance, int caisseID, string caisseNom, string relationPatient)
            {
                AssureID = assureID;
                PersonID = personID;
                NumeroAssurance = numeroAssurance;
                CaisseID = caisseID;
                CaisseNom = caisseNom;
                RelationPatient = relationPatient;
            }

            // Add a new assure
            public bool AddNewAssure()
            {
                AssureID = DataLayer.AssuréeData.AddNewAssure(PersonID, NumeroAssurance, CaisseID, RelationPatient);
                return AssureID != -1;
            }

            // Update existing assure
            public bool UpdateAssure()
            {
                return DataLayer.AssuréeData.UpdateAssure(AssureID, NumeroAssurance, CaisseID, RelationPatient);
            }

            // Find assure by AssureID
            public static Assure FindByID(int assureID)
            {
                int personID = -1;
                string numeroAssurance = string.Empty;
                int caisseID = -1;
                string caisseNom = string.Empty;
                string relationPatient = string.Empty;

                bool isFound = DataLayer.AssuréeData.GetAssureInfoByID(assureID, ref personID, ref numeroAssurance, ref caisseID, ref caisseNom, ref relationPatient);

                if (isFound)
                {
                    return new Assure(assureID, personID, numeroAssurance, caisseID, caisseNom, relationPatient);
                }
                return null;
            }

            // Find assure by PersonID
            public static Assure FindByPersonID(int personID)
            {
                int assureID = -1;
                string numeroAssurance = string.Empty;
                int caisseID = -1;
                string caisseNom = string.Empty;
                string relationPatient = string.Empty;

                bool isFound = DataLayer.AssuréeData.GetAssureInfoByPersonID(personID, ref assureID, ref numeroAssurance, ref caisseID, ref caisseNom, ref relationPatient);

                if (isFound)
                {
                    return new Assure(assureID, personID, numeroAssurance, caisseID, caisseNom, relationPatient);
                }
                return null;
            }

            // Get all assures
            public static DataTable GetAllAssures()
            {
                return DataLayer.AssuréeData.GetAllAssures();
            }

            // Delete an assure
            public static bool DeleteAssure(int assureID)
            {
                return DataLayer.AssuréeData.DeleteAssure(assureID);
            }

            // Get count of assures (or students, depending on your method)
            public static int GetAssuresCount()
            {
                return DataLayer.AssuréeData.GetAssuresCount();
            }
        }
}
