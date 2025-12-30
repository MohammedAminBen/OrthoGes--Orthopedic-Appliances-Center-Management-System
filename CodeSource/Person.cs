
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace CodeSourceLayer
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NomArabe { get; set; }
        public string PrenomArabe { get; set; }
        public string[] Telephones { get; set; }
        public string Email { get; set; }
        public string Wilaya { get; set; }
        public string Commune { get; set; }
        public string Adresse { get; set; }
        public DateTime DateNaissance { get; set; }
        public int Genre { get; set; }
        public string NomEtPrenom => $"{Nom} {Prenom}";

        // Default constructor
        public Person()
        {
            PersonID = -1;
            Nom = string.Empty;
            Prenom = string.Empty;
            NomArabe = string.Empty;
            PrenomArabe = string.Empty;
            Telephones = new string[0];
            Email = string.Empty;
            Wilaya = string.Empty;
            Commune = string.Empty;
            Adresse = string.Empty;
            DateNaissance = DateTime.MinValue;
            Genre = -1;
        }

        // Private constructor for loading existing data
        private Person(int personID, string nom, string prenom, string nomArabe, string prenomArabe,
                       string[] telephones, string email, string wilaya, string commune, string adresse, DateTime dateNaissance,int genre)
        {
            PersonID = personID;
            Nom = nom;
            Prenom = prenom;
            NomArabe = nomArabe;
            PrenomArabe = prenomArabe;
            Telephones = telephones;
            Email = email;
            Wilaya = wilaya;
            Commune = commune;
            Adresse = adresse;
            DateNaissance = dateNaissance;
            Genre = genre;
        }

        // Add a new person
        public bool AddNewPerson()
        {
            PersonID = PersonData.AddNewPerson(Nom, Prenom, NomArabe, PrenomArabe, Telephones, Email, Wilaya, Commune, Adresse, DateNaissance,Genre);
            return PersonID != -1;
        }

        // Update existing person
        public bool UpdatePerson()
        {
            return PersonData.UpdatePerson(PersonID, Nom, Prenom, NomArabe, PrenomArabe, Telephones, Email, Wilaya, Commune, Adresse, DateNaissance,Genre);
        }

        // Find person by ID
        public static Person Find(int personID)
        {
            string nom = string.Empty;
            string prenom = string.Empty;
            string nomArabe = string.Empty;
            string prenomArabe = string.Empty;
            string[] telephones = new string[0];
            string email = string.Empty;
            string wilaya = string.Empty;
            string commune = string.Empty;
            string adresse = string.Empty;
            DateTime dateNaissance = DateTime.MinValue;
            int genre = -1;

            bool isFound = PersonData.GetPersonInfoByID(personID, ref nom, ref prenom, ref nomArabe, ref prenomArabe,
                                                         ref telephones, ref email, ref wilaya, ref commune, ref adresse, ref dateNaissance,ref genre);

            if (isFound)
            {
                return new Person(personID, nom, prenom, nomArabe, prenomArabe, telephones, email, wilaya, commune, adresse, dateNaissance,genre);
            }

            return null;
        }

        // Get all persons
        public static DataTable GetAllPersons()
        {            
             return PersonData.GetAllPersons();
        }

        // Delete a person
        public static bool DeletePerson(int personID)
        {
            return PersonData.DeletePerson(personID);
        }

        // Check if person exists
        public static bool IsPersonExist(int personID)
        {
            return PersonData.IsPersonExist(personID);
        }
    }

}
