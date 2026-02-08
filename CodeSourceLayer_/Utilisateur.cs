using DataLayer_;
using System;
using System.Data;

namespace CodeSourceLayer_
{
    public class Utilisateur
    {
        public int Utilisateur_ID { get; set; }
        public int Person_ID { get; set; }
        public string Nom_Utilisateur { get; set; }
        public string Mot_De_Passe { get; set; }
        public string Path_Image { get; set; }
        public bool Est_Admin { get; set; }
        public bool PrivManipulationPatient { get; set; }
        public bool PrivManipulationDevis { get; set; }
        public bool PrivManipulationFacture { get; set; }
        public bool PrivManipulationBonLivraison { get; set; }
        public bool PrivManipulationAccord { get; set; }
        public bool PrivManipulationProduits { get; set; }
        public bool PrivManipulationRecouvrement { get; set; }
        public DateTime Date_De_Connection { get; set; }

        public Utilisateur() 
        {
            Utilisateur_ID = -1;
            Person_ID = -1;
            Nom_Utilisateur = string.Empty;
            Mot_De_Passe = string.Empty;
            Path_Image = string.Empty;
            Est_Admin = false;
            PrivManipulationPatient = false;
            PrivManipulationDevis = false;
            PrivManipulationFacture = false;
            PrivManipulationBonLivraison = false;
            PrivManipulationAccord = false;
            PrivManipulationProduits = false;
            PrivManipulationRecouvrement = false;
            Date_De_Connection = DateTime.MinValue;

        }

        public Utilisateur(int utilisateurID, int personID, string nomUtilisateur, string motDePasse, string pathDimage,
            bool isAdmin, bool privpatient, bool privdevis, bool privFacture, bool privbonliv,bool privaccord,bool privproduits,bool privrecouvrement,DateTime date)
        {
            Utilisateur_ID = utilisateurID;
            Person_ID = personID;
            Nom_Utilisateur = nomUtilisateur;
            Mot_De_Passe = motDePasse;
            Path_Image = pathDimage;
            Est_Admin = isAdmin;
            PrivManipulationPatient = privpatient;
            PrivManipulationDevis = privdevis;
            PrivManipulationFacture = privFacture;
            PrivManipulationBonLivraison = privbonliv;
            PrivManipulationAccord = privaccord;
            PrivManipulationProduits = privproduits;
            PrivManipulationRecouvrement = privrecouvrement;
            Date_De_Connection = date;
        }

        public bool AjouterUtilisateur()
        {
            return UtilisateurData.AddUtilisateur(
                Person_ID, Nom_Utilisateur, Mot_De_Passe,
                Est_Admin, Date_De_Connection, PrivManipulationPatient, PrivManipulationDevis, PrivManipulationFacture, PrivManipulationBonLivraison, PrivManipulationAccord, PrivManipulationProduits, PrivManipulationRecouvrement,Path_Image);
        }

        public bool UpdateUtilisateur()
        {
            return UtilisateurData.UpdateUtilisateur(
                Utilisateur_ID, Nom_Utilisateur, Mot_De_Passe, Path_Image,
                Est_Admin, PrivManipulationPatient, PrivManipulationDevis, PrivManipulationFacture, PrivManipulationBonLivraison, PrivManipulationAccord, PrivManipulationProduits, PrivManipulationRecouvrement);
        }

        public static Utilisateur FindByUtilisateurID(int utilisateurID)
        {
            int personID = -1;
            string nomUtilisateur = null, motDePasse = null, pathDimage = null;
            bool isAdmin = false, privPatient = false, privdevis = false, privFacture = false, privbonliv = false,privaccord = false,privproduits = false,privrecouvrement = false;
            DateTime date = DateTime.MinValue;
            if (UtilisateurData.GetUtilisateurByID(utilisateurID, ref personID, ref nomUtilisateur, ref motDePasse, ref pathDimage,
                ref isAdmin, ref date, ref privPatient, ref privdevis, ref privFacture, ref privbonliv, ref privaccord, ref privproduits, ref privrecouvrement))
            {
                return new Utilisateur(utilisateurID, personID, nomUtilisateur, motDePasse, pathDimage,
                    isAdmin, privPatient, privdevis, privFacture, privbonliv, privaccord, privproduits, privrecouvrement, date);
            }
            else
            {
                return null;
            }
        }
        public static Utilisateur FindByNomUtilisateurEtMotDePasse(string Nomutilisateur, string Motdpasse)
        {
            int UtilisateurID = -1,personID = -1;
            string  pathDimage = null;
            bool isAdmin = false, privPatient = false, privdevis = false, privFacture = false, privbonliv = false, privaccord = false, privproduits = false, privrecouvrement = false;
            DateTime date = DateTime.MinValue;
            if (UtilisateurData.GetUtilisateurByNomUtilisateurEtMotDePasse(ref UtilisateurID, ref personID,  Nomutilisateur, Motdpasse, ref pathDimage,
                ref isAdmin, ref date, ref privPatient, ref privdevis, ref privFacture, ref privbonliv, ref privaccord, ref privproduits, ref privrecouvrement))
            {
                return new Utilisateur(UtilisateurID, personID, Nomutilisateur, Motdpasse, pathDimage,
                    isAdmin, privPatient, privdevis, privFacture, privbonliv, privaccord, privproduits, privrecouvrement, date);
            }
            else
            {
                return null;
            }
        }

        public static Utilisateur FindByPersonID(int personID)
        {
            int utilisateurID = -1;
            string nomUtilisateur = null, motDePasse = null, pathDimage = null;
            bool isAdmin = false, privPatient = false, privdevis = false, privFacture = false, privbonliv = false, privaccord = false, privproduits = false, privrecouvrement = false;
            DateTime date = DateTime.MinValue;

            if (UtilisateurData.GetUtilisateurByPersonID(ref utilisateurID, personID, ref nomUtilisateur, ref motDePasse, ref pathDimage,
                ref isAdmin,ref date, ref privPatient, ref privdevis, ref privFacture, ref privbonliv, ref privaccord, ref privproduits, ref privrecouvrement))
            {
                return new Utilisateur(utilisateurID, personID, nomUtilisateur, motDePasse, pathDimage,
                    isAdmin, privPatient, privdevis, privFacture, privbonliv, privaccord, privproduits, privrecouvrement, date);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllUtilisateurs()
        {
            return UtilisateurData.GetAllUtilisateurs();
        }

        public static bool DeleteUtilisateur(int utilisateurID)
        {
            return UtilisateurData.DeleteUtilisateur(utilisateurID);
        }
        public static bool AddActivité(int UtilisateurID, string activité, string type)
        {
            return UtilisateurData.AddActivité(UtilisateurID, activité, type);
        }

        public static DataTable GetActivitésDUtilisateur(int utilisateurID)
        {
            return UtilisateurData.GetActivitésDUtilisateur(utilisateurID);
        }
        public static DataTable GetAllActivités()
        {
            return UtilisateurData.GetAllActivités();
        }
    }
}
