using DataLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_
{
    public static class TacheData
    {
        // =========================
        // GET BY ID
        // =========================
        public static bool GetTacheByID(int tacheID, ref string tacheText, ref string tacheType, ref DateTime tacheDate, ref int estFini, ref int estAnnuler)
        {
            bool isFound = false;

            string query = @"
        SELECT Tache_Text, Tache_Type, Tache_Date, est_Fini, est_Annuler
        FROM D_Taches
        WHERE Tache_ID = @Tache_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tache_ID", tacheID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            tacheText = reader["Tache_Text"].ToString();
                            tacheType = reader["Tache_Type"].ToString();
                            tacheDate = Convert.ToDateTime(reader["Tache_Date"]);
                            estFini = Convert.ToInt32(reader["est_Fini"]);
                            estAnnuler = Convert.ToInt32(reader["est_Annuler"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }

            return isFound;
        }

        // =========================
        // CREATE
        // =========================
        public static bool CreateTache(string tacheText, string tacheType, DateTime tacheDate, int estFini, int estAnnuler)
        {
            string query = @"
        INSERT INTO D_Taches
        (Tache_Text, Tache_Type, Tache_Date, est_Fini, est_Annuler)
        VALUES
        (@Tache_Text, @Tache_Type, @Tache_Date, @est_Fini, @est_Annuler)";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Tache_Text", SqlDbType.NVarChar).Value = tacheText;
                    command.Parameters.Add("@Tache_Type", SqlDbType.NVarChar).Value = tacheType;
                    command.Parameters.Add("@Tache_Date", SqlDbType.Date).Value = tacheDate;
                    command.Parameters.Add("@est_Fini", SqlDbType.Int).Value = estFini;
                    command.Parameters.Add("@est_Annuler", SqlDbType.Int).Value = estAnnuler;

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
        // GET ALL
        // =========================
        public static DataTable GetAllTaches()
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT
            Tache_ID,
            Tache_Text,
            Tache_Type,
            Tache_Date,
            est_Fini,
            est_Annuler
        FROM D_Taches
        ORDER BY Tache_Date DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
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
        // UPDATE EST_FINI
        // =========================
        public static bool UpdateEstFini(int tacheID,int value)
        {
            string query = @"
        UPDATE D_Taches
        SET est_Fini = @Value
        WHERE Tache_ID = @Tache_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tache_ID", tacheID);
                    command.Parameters.AddWithValue("@Value", value);

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
        // UPDATE EST_ANNULER
        // =========================
        public static bool UpdateEstAnnuler(int tacheID, int value)
        {
            string query = @"
        UPDATE D_Taches
        SET est_Annuler = @Value
        WHERE Tache_ID = @Tache_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tache_ID", tacheID);
                    command.Parameters.AddWithValue("@Value", value);

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
        // DELETE
        // =========================
        public static bool DeleteTache(int tacheID,string DocID="")
        {
            string query = @"DELETE FROM D_Taches WHERE Tache_ID = @Tache_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                

                 {
                        command.Parameters.AddWithValue("@Tache_ID", tacheID);

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
        public static bool DeleteTacheByAccord(int accordID)
        {
            string query = @"DELETE FROM D_Taches WHERE Tache_Type = @DocID";
            string docType = accordID.ToString();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DocID", docType);
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
    }

}
