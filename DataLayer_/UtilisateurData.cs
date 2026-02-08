using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataLayer_
{
    public class UtilisateurData
    {
        private static string SaveUserImage(string userId, string sourceFilePath)
        {
            string folderPath = Path.Combine(@"C:\SysSco\UtilisateursImages", userId);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileExtension = Path.GetExtension(sourceFilePath);
            string destFilePath = Path.Combine(folderPath, "profile" + fileExtension);

            File.Copy(sourceFilePath, destFilePath, true);
            return destFilePath; // Return the saved image path
        }

        public static bool GetUtilisateurByID(int utilisateurID, ref int personID, ref string nomUtilisateur, ref string motDePasse, ref string pathDimage, ref bool isAdmin, ref DateTime date,
                                        ref bool privilegePatient, ref bool privilegeDevis, ref bool privilegeFacture, ref bool privilegeBonLivraison, ref bool privilegeAccord, ref bool privilegeProduits, ref bool privilegeRecouvrement)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"SELECT u.Person_ID, u.Nom_Utilisateur, u.Mot_De_Passe,
                                u.Path_Image, u.Est_Admin, u.Date_De_Connection,
                                p.Privilege_Manupilation_Patient,
                                p.Privilege_Manupilation_Devis,
                                p.Privilege_Manupilation_Facture,
                                p.Privilege_Manupilation_Bon_Livraison,
                                p.Privilege_Manupilation_Accord,
                                p.Privilege_Manupilation_Produits,
                                p.Privilege_Manupilation_Recouvrement
                         FROM A_Utilisateur u
                         LEFT JOIN A_Privilege_Utilisateur p
                                ON u.Utilisateur_ID = p.Utilisateur_ID
                         WHERE u.Utilisateur_ID = @UtilisateurID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UtilisateurID", utilisateurID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            personID = (int)reader["Person_ID"];
                            nomUtilisateur = reader["Nom_Utilisateur"].ToString();
                            motDePasse = reader["Mot_De_Passe"].ToString();
                            pathDimage = reader["Path_Image"] == DBNull.Value ? null : reader["Path_Image"].ToString();
                            isAdmin = (int)reader["Est_Admin"] ==1;
                            date = (DateTime)reader["Date_De_Connection"];

                            privilegePatient = (int)reader["Privilege_Manupilation_Patient"] == 1;
                            privilegeDevis = (int)reader["Privilege_Manupilation_Devis"] == 1;
                            privilegeFacture = (int)reader["Privilege_Manupilation_Facture"] == 1;
                            privilegeBonLivraison = (int)reader["Privilege_Manupilation_Bon_Livraison"] == 1;
                            privilegeAccord = (int)reader["Privilege_Manupilation_Accord"] == 1;
                            privilegeProduits = (int)reader["Privilege_Manupilation_Produits"] == 1;
                            privilegeRecouvrement = (int)reader["Privilege_Manupilation_Recouvrement"] == 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

            return isFound;
        }




        public static bool GetUtilisateurByPersonID(ref int utilisateurID, int personID, ref string nomUtilisateur, ref string motDePasse, ref string pathDimage, ref bool isAdmin, ref DateTime date,
                                            ref bool privilegePatient, ref bool privilegeDevis, ref bool privilegeFacture, ref bool privilegeBonLivraison, ref bool privilegeAccord, ref bool privilegeProduits, ref bool privilegeRecouvrement)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"SELECT u.Utilisateur_ID, u.Person_ID, u.Nom_Utilisateur, u.Mot_De_Passe,
                                u.Path_Image, u.Est_Admin, u.Date_De_Connection,
                                p.Privilege_Manupilation_Patient,
                                p.Privilege_Manupilation_Devis,
                                p.Privilege_Manupilation_Facture,
                                p.Privilege_Manupilation_Bon_Livraison,
                                p.Privilege_Manupilation_Accord,
                                p.Privilege_Manupilation_Produits,
                                p.Privilege_Manupilation_Recouvrement
                         FROM A_Utilisateur u
                         LEFT JOIN A_Privilege_Utilisateur p ON u.Utilisateur_ID = p.Utilisateur_ID
                         WHERE u.Person_ID = @PersonID AND u.Est_Supprimer = 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", personID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            utilisateurID = (int)reader["Utilisateur_ID"];
                            nomUtilisateur = reader["Nom_Utilisateur"].ToString();
                            motDePasse = reader["Mot_De_Passe"].ToString();
                            pathDimage = reader["Path_Image"] == DBNull.Value ? null : reader["Path_Image"].ToString();
                            isAdmin = (int)reader["Est_Admin"] == 1;
                            date = (DateTime)reader["Date_De_Connection"];

                            privilegePatient = (int)reader["Privilege_Manupilation_Patient"] == 1;
                            privilegeDevis = (int)reader["Privilege_Manupilation_Devis"] == 1;
                            privilegeFacture = (int)reader["Privilege_Manupilation_Facture"] == 1;
                            privilegeBonLivraison = (int)reader["Privilege_Manupilation_Bon_Livraison"] == 1;
                            privilegeAccord = (int)reader["Privilege_Manupilation_Accord"] == 1;
                            privilegeProduits = (int)reader["Privilege_Manupilation_Produits"] == 1;
                            privilegeRecouvrement = (int)reader["Privilege_Manupilation_Recouvrement"] == 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

            return isFound;
        }

        public static bool GetUtilisateurByNomUtilisateurEtMotDePasse(ref int utilisateurID, ref int personID, string nomUtilisateur, string motDePasse, ref string pathDimage, ref bool isAdmin, ref DateTime date,
                                                              ref bool privilegePatient, ref bool privilegeDevis, ref bool privilegeFacture, ref bool privilegeBonLivraison, ref bool privilegeAccord, ref bool privilegeProduits, ref bool privilegeRecouvrement)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"SELECT u.Utilisateur_ID, u.Person_ID, u.Nom_Utilisateur, u.Mot_De_Passe,
                                u.Path_Image, u.Est_Admin, u.Date_De_Connection,
                                p.Privilege_Manupilation_Patient,
                                p.Privilege_Manupilation_Devis,
                                p.Privilege_Manupilation_Facture,
                                p.Privilege_Manupilation_Bon_Livraison,
                                p.Privilege_Manupilation_Accord,
                                p.Privilege_Manupilation_Produits,
                                p.Privilege_Manupilation_Recouvrement
                         FROM A_Utilisateur u
                         LEFT JOIN A_Privilege_Utilisateur p ON u.Utilisateur_ID = p.Utilisateur_ID
                         WHERE u.Nom_Utilisateur = @NomUtilisateur
                         AND u.Mot_De_Passe = @MotDePasse
                         AND u.Est_Supprimer = 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomUtilisateur", nomUtilisateur);
                command.Parameters.AddWithValue("@MotDePasse", motDePasse);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            utilisateurID = (int)reader["Utilisateur_ID"];
                            personID = (int)reader["Person_ID"];
                            pathDimage = reader["Path_Image"] == DBNull.Value ? null : reader["Path_Image"].ToString();
                            isAdmin = (int)reader["Est_Admin"] == 1;
                            date = (DateTime)reader["Date_De_Connection"];

                            privilegePatient = (int)reader["Privilege_Manupilation_Patient"] == 1;
                            privilegeDevis = (int)reader["Privilege_Manupilation_Devis"] == 1;
                            privilegeFacture = (int)reader["Privilege_Manupilation_Facture"] == 1;
                            privilegeBonLivraison = (int)reader["Privilege_Manupilation_Bon_Livraison"] == 1;
                            privilegeAccord = (int)reader["Privilege_Manupilation_Accord"] == 1;
                            privilegeProduits = (int)reader["Privilege_Manupilation_Produits"] == 1;
                            privilegeRecouvrement = (int)reader["Privilege_Manupilation_Recouvrement"] == 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

            return isFound;
        }

        public static DataTable GetAllUtilisateurs()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "select A_Utilisateur.Utilisateur_ID,A_Utilisateur.Nom_Utilisateur,CASE WHEN A_Utilisateur.Est_Admin = 1 THEN 'Admin' ELSE 'Normale' END AS Type_Utilisateur,NomEtPrenom = D_Person.Nom + ' ' + D_Person.Prenom,A_Utilisateur.Date_De_Connection From A_Utilisateur INNER JOIN D_Person ON A_Utilisateur.Person_ID = D_Person.Person_ID WHERE A_Utilisateur.Est_Supprimer = 0;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static bool AddUtilisateur(
     int personID, string nomUtilisateur, string motDePasse, bool isAdmin, DateTime dateDeNaissance,
     bool privilegePatient, bool privilegeDevis, bool privilegeFacture, bool privilegeBonLivraison,
     bool privilegeAccord, bool privilegeProduits, bool privilegeRecouvrement,
     string pathImage = "")
        {
            if (!string.IsNullOrEmpty(pathImage))
                pathImage = SaveUserImage(nomUtilisateur, pathImage);

            string insertUserQuery = @"INSERT INTO A_Utilisateur
        (Person_ID, Nom_Utilisateur, Mot_De_Passe, Path_Image, Est_Admin, Date_De_Connection, Est_Supprimer)
        VALUES
        (@PersonID, @NomUtilisateur, @MotDePasse, @PathDimage, @isAdmin, @date, 0);
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            string insertPrivilegesQuery = @"INSERT INTO A_Privilege_Utilisateur
        (Utilisateur_ID, Privilege_Manupilation_Patient, Privilege_Manupilation_Devis,
         Privilege_Manupilation_Facture, Privilege_Manupilation_Bon_Livraison,
         Privilege_Manupilation_Accord, Privilege_Manupilation_Produits,
         Privilege_Manupilation_Recouvrement)
        VALUES
        (@UtilisateurID, @PrivilegePatient, @PrivilegeDevis, @PrivilegeFacture,
         @PrivilegeBonLivraison, @PrivilegeAccord, @PrivilegeProduits, @PrivilegeRecouvrement);";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    int utilisateurID;

                    using (SqlCommand command = new SqlCommand(insertUserQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@NomUtilisateur", nomUtilisateur);
                        command.Parameters.AddWithValue("@MotDePasse", motDePasse);
                        command.Parameters.AddWithValue("@PathDimage", (object)pathImage ?? DBNull.Value);
                        command.Parameters.AddWithValue("@isAdmin", isAdmin ? 1 : 0);
                        command.Parameters.AddWithValue("@date", DateTime.Now.Date);

                        utilisateurID = (int)command.ExecuteScalar();
                    }

                    using (SqlCommand command = new SqlCommand(insertPrivilegesQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@UtilisateurID", utilisateurID );
                        command.Parameters.AddWithValue("@PrivilegePatient", privilegePatient ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeDevis", privilegeDevis ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeFacture", privilegeFacture ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeBonLivraison", privilegeBonLivraison ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeAccord", privilegeAccord ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeProduits", privilegeProduits ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeRecouvrement", privilegeRecouvrement ? 1 : 0);

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Erreur : " + ex.Message);
                    return false;
                }
            }
        }


        public static bool UpdateUtilisateur(
      int utilisateurID, string nomUtilisateur, string motDePasse, string pathImage, bool isAdmin,
      bool privilegePatient, bool privilegeDevis, bool privilegeFacture, bool privilegeBonLivraison,
      bool privilegeAccord, bool privilegeProduits, bool privilegeRecouvrement)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                string updateUserQuery = @"UPDATE A_Utilisateur SET
                                   Nom_Utilisateur = @NomUtilisateur,
                                   Mot_De_Passe = @MotDePasse,
                                   Path_Image = @PathDimage,
                                   Est_Admin = @isAdmin
                                   WHERE Utilisateur_ID = @UtilisateurID;";

                string updatePrivilegesQuery = @"UPDATE A_Privilege_Utilisateur SET
                                         Privilege_Manupilation_Patient = @PrivilegePatient,
                                         Privilege_Manupilation_Devis = @PrivilegeDevis,
                                         Privilege_Manupilation_Facture = @PrivilegeFacture,
                                         Privilege_Manupilation_Bon_Livraison = @PrivilegeBonLivraison,
                                         Privilege_Manupilation_Accord = @PrivilegeAccord,
                                         Privilege_Manupilation_Produits = @PrivilegeProduits,
                                         Privilege_Manupilation_Recouvrement = @PrivilegeRecouvrement
                                         WHERE Utilisateur_ID = @UtilisateurID;";

                try
                {
                    using (SqlCommand command = new SqlCommand(updateUserQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@UtilisateurID", utilisateurID);
                        command.Parameters.AddWithValue("@NomUtilisateur", nomUtilisateur);
                        command.Parameters.AddWithValue("@MotDePasse", motDePasse);
                        command.Parameters.AddWithValue("@PathDimage", (object)pathImage ?? DBNull.Value);
                        command.Parameters.AddWithValue("@isAdmin", isAdmin ? 1 : 0);

                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(updatePrivilegesQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@UtilisateurID", utilisateurID);
                        command.Parameters.AddWithValue("@PrivilegePatient", privilegePatient ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeDevis", privilegeDevis ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeFacture", privilegeFacture ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeBonLivraison", privilegeBonLivraison ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeAccord", privilegeAccord ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeProduits", privilegeProduits ? 1 : 0);
                        command.Parameters.AddWithValue("@PrivilegeRecouvrement", privilegeRecouvrement ? 1 : 0);

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Erreur : " + ex.Message);
                    return false;
                }
            }
        }

        public static bool DeleteUtilisateur(int utilisateurID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "Update A_Utilisateur SET Est_Supprimer = 1 WHERE Utilisateur_ID = @UtilisateurID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UtilisateurID", utilisateurID);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool AddActivité( int UtilisateurID, string activité,string TypeActivite)
        {
            int insertedrow = 0;
            DateTime date = DateTime.Now.Date;
            TimeSpan Heur = DateTime.Now.TimeOfDay;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO A_Utilisateur_Activites_Historique (Utilisateur_ID,Date_Activite,Heur_Activite,Type_Activite,Activite)
                     VALUES 
                    (@ID,@date,@heur,@type,@activité)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", UtilisateurID);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.Add("@heur", SqlDbType.Time).Value = Heur;
            command.Parameters.AddWithValue("@type", TypeActivite);
            command.Parameters.AddWithValue("@activité", activité);

            try
            {
                connection.Open();
                insertedrow = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return insertedrow > 0;
        }
        public static DataTable GetAllActivités()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "select (select Nom_Utilisateur from A_Utilisateur where Utilisateur_ID = h.Utilisateur_ID) as Utilisateur ,Date_Activite,Heur_Activite,Type_Activite,Activite from A_Utilisateur_Activites_Historique h";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static DataTable GetActivitésDUtilisateur(int Utid)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "select (select Nom_Utilisateur from A_Utilisateur where Utilisateur_ID = h.Utilisateur_ID) as Utilisateur ,Date_Activite,Heur_Activite,Type_Activite,Activite from A_Utilisateur_Activites_Historique h WHERE h.Utilisateur_ID = @UtilisateurID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UtilisateurID", Utid);    

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
