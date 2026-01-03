using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
namespace DataLayer_
{
    public class AssuréeData
    {
        public static bool GetAssureInfoByID(int AssureID, ref int PersonID, ref string NumeroAssurance, ref int CaisseID, ref string CaisseNom, ref string RelationPatient)
        {
            bool isFound = false;

            string query = @"
        SELECT a.Person_ID, a.Numero_Assurance, a.Caisse_ID, a.Relation_Patient, c.Nom_Caisse
        FROM D_Assure a
        INNER JOIN R_Caisse c ON a.Caisse_ID = c.Caisse_ID
        WHERE a.Assure_ID = @AssureID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssureID", AssureID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            PersonID = (int)reader["Person_ID"];
                            NumeroAssurance = reader["Numero_Assurance"].ToString();
                            CaisseID = (int)reader["Caisse_ID"];
                            CaisseNom = reader["Nom_Caisse"].ToString();
                            RelationPatient = reader["Relation_Patient"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                Console.WriteLine("Database error: " + ex.Message);
            }

            return isFound;
        }



        public static bool GetAssureInfoByPersonID(
     int personID,
     ref int assureID,
     ref string numeroAssurance,
     ref int caisseID,
     ref string caisseNom,
     ref string relationPatient)
        {
            bool isFound = false;

            string query = @"
        SELECT a.Assure_ID, a.Numero_Assurance, a.Caisse_ID, a.Relation_Patient, c.Nom_Caisse
        FROM D_Assure a
        INNER JOIN R_Caisse c ON a.Caisse_ID = c.Caisse_ID
        WHERE a.Person_ID = @PersonID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            assureID = (int)reader["Assure_ID"];
                            numeroAssurance = reader["Numero_Assurance"].ToString();
                            caisseID = (int)reader["Caisse_ID"];
                            caisseNom = reader["Nom_Caisse"].ToString();
                            relationPatient = reader["Relation_Patient"] != DBNull.Value? reader["Relation_Patient"].ToString(): null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                Console.WriteLine("Database error: " + ex.Message);
            }

            return isFound;
        }

        public static int GetAssuresCount()
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT count(*) as CNT FROM D_Assure ";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    count = (int)reader["CNT"];
                }

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

            return count;
        }

        public static DataTable GetAllAssures()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "Select * From D_Assure ";

            SqlCommand command = new SqlCommand(query, connection);

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
                Console.WriteLine("Error ", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }
        public static int AddNewAssure(
        int personID,
        string numeroAssurance,
        int caisseID,
        string relationPatient = null)
        {
            int assureID = -1;

            string query = @"
        INSERT INTO D_Assure (Person_ID, Numero_Assurance, Caisse_ID, Relation_Patient)
        VALUES (@PersonID, @NumeroAssurance, @CaisseID, @RelationPatient);
        SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@NumeroAssurance", numeroAssurance);
                    command.Parameters.AddWithValue("@CaisseID", caisseID);
                    if (string.IsNullOrWhiteSpace(relationPatient))
                    {
                        command.Parameters.Add("@RelationPatient", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@RelationPatient", SqlDbType.NVarChar).Value = relationPatient;
                    }


                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        assureID = id;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }

            return assureID;
        }

        public static bool UpdateAssure(
        int assureID,
        string numeroAssurance,
        int caisseID,
        string relationPatient = null)
        {
            int rowsAffected = 0;

            string query = @"
        UPDATE D_Assure
        SET Numero_Assurance = @NumeroAssurance,
            Caisse_ID = @CaisseID,
            Relation_Patient = @RelationPatient
        WHERE Assure_ID = @AssureID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssureID", assureID);
                    command.Parameters.AddWithValue("@NumeroAssurance", numeroAssurance);
                    command.Parameters.AddWithValue("@CaisseID", caisseID);
                    if (string.IsNullOrWhiteSpace(relationPatient))
                    {
                        command.Parameters.Add("@RelationPatient", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@RelationPatient", SqlDbType.NVarChar).Value = relationPatient;
                    }


                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }

            return rowsAffected > 0;
        }

        public static bool DeleteAssure(int assureID)
        {
            int rowsAffected = 0;

            string query = @"DELETE FROM D_Assure WHERE Assure_ID = @AssureID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssureID", assureID);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }

            return rowsAffected > 0;
        }
    }
}
