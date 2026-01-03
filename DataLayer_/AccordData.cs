using DataLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_
{
    public class AccordData
    {
        public static bool CreateAccord(
       string numeroPatient,
       DateTime dateAccord,
       string etatAccord,
       string mesures,
       string referenceProduit,
       int delaiAccord,int quantity
          )
        {
            string query = @"
        INSERT INTO D_Accord
        (Numero_Patient, Date_Accord, etat_Accord, Mesures, Reference_Produit, Delai_Accord,Quantity,est_Ajouter_Tache)
        VALUES
        (@Numero_Patient, @Date_Accord, @etat_Accord, @Mesures, @Reference_Produit, @Delai_Accord,@quantity,0)";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Numero_Patient", SqlDbType.VarChar).Value = numeroPatient;
                    command.Parameters.Add("@Date_Accord", SqlDbType.DateTime).Value = dateAccord;
                    command.Parameters.Add("@etat_Accord", SqlDbType.VarChar).Value = etatAccord;
                    command.Parameters.Add("@Mesures", SqlDbType.NVarChar).Value = mesures;
                    command.Parameters.Add("@Reference_Produit", SqlDbType.VarChar).Value = referenceProduit;
                    command.Parameters.Add("@Delai_Accord", SqlDbType.Int).Value = delaiAccord;
                    command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }
        }

        // =========================
        // GET ACCORD BY ID
        // =========================
        public static bool GetAccordByID(
            int accordID,
            ref string numeroPatient,
            ref DateTime dateAccord,
            ref string etatAccord,
            ref string mesures,
            ref string referenceProduit,
            ref int delaiAccord,
            ref int quantity)
        {
            bool isFound = false;

            string query = @"
        SELECT Numero_Patient, Date_Accord, etat_Accord, Mesures, Reference_Produit, Delai_Accord ,Quantity
        FROM D_Accord
        WHERE Accord_ID = @Accord_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Accord_ID", SqlDbType.Int).Value = accordID;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            numeroPatient = reader["Numero_Patient"].ToString();
                            dateAccord = Convert.ToDateTime(reader["Date_Accord"]);
                            etatAccord = reader["etat_Accord"].ToString();
                            mesures = reader["Mesures"]?.ToString();
                            referenceProduit = reader["Reference_Produit"]?.ToString();
                            delaiAccord = Convert.ToInt32(reader["Delai_Accord"]);
                            quantity = Convert.ToInt32(reader["Quantity"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }

            return isFound;
        }

        // =========================
        // GET ALL ACCORDS
        // =========================
        public static DataTable GetAllAccords()
        {
            DataTable dt = new DataTable();

            string query = @"
SELECT 
      a.Accord_ID,
	  pt.Numero_Patient,
      pr.Nom + ' ' + pr.Prenom AS Patient,
	  STRING_AGG(t.Telephone, ' / ') AS Téléphone,
      ass.Numero_Assurance,
      c.Nom_Caisse,
      a.Reference_Produit,
      p.Nom_Produit,
      a.Quantity,
	  a.Mesures,
      a.Date_Accord,
      a.etat_Accord
FROM D_Accord a
INNER JOIN R_Produit p ON a.Reference_Produit = p.Reference 
LEFT JOIN D_Patient pt ON a.Numero_Patient = pt.Numero_Patient
LEFT JOIN D_Person pr ON pt.Person_ID = pr.Person_ID
LEFT JOIN D_Assure ass ON pt.Assure_ID = ass.Assure_ID
LEFT JOIN R_Caisse c ON ass.Caisse_ID = c.Caisse_ID
LEFT JOIN D_Telephone t ON t.Person_ID = pr.Person_ID
GROUP BY
      a.Accord_ID,
      pr.Nom,
      pr.Prenom,
      pt.Numero_Patient,
      ass.Numero_Assurance,
      c.Nom_Caisse,
      a.Reference_Produit,
      p.Nom_Produit,
      a.Quantity,
	  a.Mesures,
	  a.Date_Accord,
	  a.etat_Accord";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dt;
        }

        // =========================
        // GET ACCORDS BY PATIENT
        // =========================
        public static DataTable GetAccordsByPatient(string numeroPatient)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
      d.Accord_ID,
      [Reference_Produit],
      p.Nom_Produit AS Désignation,
      d.Quantity,
	  d.Mesures,
	  d.Date_Accord,
      d.etat_Accord,
	  d.Delai_Accord
FROM D_Accord d
INNER JOIN R_Produit p ON d.Reference_Produit = p.Reference
    WHERE d.Numero_Patient = @Numero_Patient";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Numero_Patient", SqlDbType.VarChar).Value = numeroPatient;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dt;
        }

        // =========================
        // UPDATE ETAT ACCORD
        // =========================
        public static bool UpdateEtatAccord(int accordID, string value)
        {
            string query = @"
        UPDATE D_Accord
        SET etat_Accord = @Etat
        WHERE Accord_ID = @Accord_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Accord_ID", SqlDbType.Int).Value = accordID;
                    command.Parameters.Add("@Etat", SqlDbType.VarChar).Value = value;

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }
        }

        // =========================
        // DELETE ACCORD
        // =========================
        public static bool DeleteAccord(int accordID)
        {
            string query = @"DELETE FROM D_Accord WHERE Accord_ID = @Accord_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Accord_ID", SqlDbType.Int).Value = accordID;

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }
        }
        public static DataTable GetAllAccordForTaches()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @" SELECT *
                              FROM D_Accord 
                              WHERE etat_Accord = 'Prêt' AND est_Ajouter_Tache = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DateToday", DateTime.Today);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Facture :" + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static bool UpdateTache_etat(int Accord, int etat)
        {
            string query = @"
        UPDATE D_Accord
        SET est_Ajouter_Tache = @Etat
        WHERE Accord_ID = @NumeroAccord";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroAccord", Accord);
                    command.Parameters.AddWithValue("@Etat", etat);
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }
        }
    }
}
