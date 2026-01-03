using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSourceLayer_
{
    public class Patient
    {
        public string NumeroPatient { get; set; }
        public int PersonID { get; set; }
        public int AssureID { get; set; }
        public int est_Assure { get; set; }
        public DateTime Date_Dinscription { get; set; }

        // Default constructor
        public Patient()
        {
            NumeroPatient = string.Empty;
            PersonID = -1;
            AssureID = -1;
            Date_Dinscription = DateTime.MinValue;
        }

        // Private constructor for loading existing data
        private Patient(string numeroPatient, int personID, int assureID,int Assure, DateTime date_dinscription)
        {
            NumeroPatient = numeroPatient;
            PersonID = personID;
            AssureID = assureID;
            est_Assure = Assure;
            Date_Dinscription = date_dinscription;
        }

        // Add a new patient
        public bool AddNewPatient()
        {
            return DataLayer_.PatientData.AddNewPatient(PersonID,est_Assure,AssureID);
        }

        // Update existing patient
        public bool UpdatePatient()
        {
            return DataLayer_.PatientData.UpdatePatient(NumeroPatient, PersonID,est_Assure,AssureID);
        }

        // Delete a patient
        public static bool DeletePatient(string numeroPatient)
        {
            return DataLayer_.PatientData.DeletePatient(numeroPatient);
        }

        // Find patient by NumeroPatient
        public static Patient FindByNumeroPatient(string numeroPatient)
        {
            int personID = -1;
            int assureID = -1;
            int est_Assure = -1;
            DateTime date_dinscription = DateTime.MinValue;
            bool isFound = DataLayer_.PatientData.GetPatientByNumeroPatient(numeroPatient, ref personID,ref est_Assure,ref assureID,ref date_dinscription);

            if (isFound)
            {
                return new Patient(numeroPatient, personID,assureID,est_Assure,date_dinscription);
            }
            return null;
        }

        // Find patient by PersonID
        public static Patient FindByPersonID(int personID)
        {
            string numeroPatient = string.Empty;
            int assureID = -1;
            int est_Assure = -1;
            DateTime date_dinscription = DateTime.MinValue;
            bool isFound = DataLayer_.PatientData.GetPatientByPersonID(personID, ref numeroPatient,ref assureID,ref est_Assure,ref date_dinscription);

            if (isFound)
            {
                return new Patient(numeroPatient, personID, assureID,est_Assure,date_dinscription);
            }
            return null;
        }

        // Get all patients
        public static DataTable GetAllPatients()
        {
            return DataLayer_.PatientData.GetAllPatients();
        }

        // Get count of patients
        public static int GetPatientsCount()
        {
            return DataLayer_.PatientData.GetPatientsCount();
        }
    }
}
