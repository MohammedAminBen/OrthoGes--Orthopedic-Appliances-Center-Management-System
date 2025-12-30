using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DataLayer
{
    public class PatientData
    {
        public static string GenerateNumeroPatient()
        {
            int lastNumber = 0;
            int lastYear = 0;

            string query = @"
        SELECT TOP 1 Numero_Patient
        FROM D_Patient
        WHERE Numero_Patient IS NOT NULL
        ORDER BY Numero_Patient DESC;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string numeroPatient = result.ToString();

                        // Expected format: Number/YY
                        string[] parts = numeroPatient.Split('/');

                        if (parts.Length == 2)
                        {
                            int.TryParse(parts[0], out lastNumber);
                            int.TryParse(parts[1], out lastYear);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }

            int currentYear = int.Parse(DateTime.Now.ToString("yy"));

            // 🔁 New year OR no previous records
            if (lastYear != currentYear)
            {
                lastNumber = 1;
            }
            else
            {
                lastNumber++;
            }

            return $"{lastNumber}/{currentYear}";
        }
        public static bool GetPatientByNumeroPatient(string numeroPatient,ref int personID,ref int est_Assure,ref int assureID,ref DateTime date_dinscription)
        {
            bool isFound = false;
            string query = @"
            SELECT Person_ID, Assure_ID,est_Assure,Date_Dinscription
            FROM D_Patient
            WHERE Numero_Patient = @NumeroPatient AND est_Supprimer != 1";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroPatient", numeroPatient);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            personID = (int)reader["Person_ID"];
                            assureID = (int)reader["Assure_ID"];
                            est_Assure = (int)reader["est_Assure"];
                            date_dinscription = reader["Date_Dinscription"] != DBNull.Value
                                        ? (DateTime)reader["Date_Dinscription"]
                                        : DateTime.MinValue;

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

        public static bool GetPatientByPersonID(int personID,ref string numeroPatient,ref int assureID,ref int est_Assure,ref DateTime date_dinscription)
        {
            bool isFound = false;
            string query = @"
        SELECT Numero_Patient, Assure_ID, est_Assure,Date_Dinscription
        FROM D_Patient
        WHERE Person_ID = @PersonID AND est_Supprimer != 1";

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
                            numeroPatient = reader["Numero_Patient"].ToString();
                            assureID = (int)reader["Assure_ID"];
                            est_Assure = (int)reader["est_Assure"];
                            date_dinscription = (DateTime)reader["Date_Dinscription"];

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

        public static int GetPatientsCount()
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT count(*) as CNT FROM D_Patient WHERE est_Supprimer != 1";
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

        public static DataTable GetAllPatients()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query =
                "SELECT " +
                "p.Numero_Patient AS Numero_Patient, " +
                "CONCAT(per.Nom, ' ', per.Prenom) AS Nom_et_Prenom, " +
                "per.Date_Naissance AS Date_De_Naissance, " +
                "STRING_AGG(t.Telephone, ' / ') AS Telephone, " +
                "a.Numero_Assurance AS Numero_Assurance, " +
                "c.Nom_Caisse AS Caisse " +
                "FROM D_Patient p " +
                "JOIN D_Person per ON p.Person_ID = per.Person_ID " +
                "LEFT JOIN D_Telephone t ON per.Person_ID = t.Person_ID " +
                "LEFT JOIN D_Assure a ON p.Assure_ID = a.Assure_ID " +
                "LEFT JOIN R_Caisse c ON a.Caisse_ID = c.Caisse_ID " +
                "WHERE p.est_Supprimer != 1 " +
                "GROUP BY " +
                "p.Numero_Patient, " +
                "per.Nom, " +
                "per.Prenom, " +
                "per.Date_Naissance, " +
                "a.Numero_Assurance, " +
                "c.Nom_Caisse " +
                "ORDER BY p.Numero_Patient;";


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
                Console.WriteLine("Error "+ ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }
        public static bool AddNewPatient(int personID,int est_Assure,int? assureID = null)
        {
            string numeroPatient = GenerateNumeroPatient();
            string query = @"
        INSERT INTO D_Patient (Numero_Patient, Person_ID, Assure_ID,est_Assure,Date_Dinscription)
        VALUES (@NumeroPatient, @PersonID, @AssureID,@est_Assure,@Date_Dinscription)";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroPatient", numeroPatient);
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@est_Assure", est_Assure);
                    command.Parameters.AddWithValue("@AssureID", assureID.HasValue ? (object)assureID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@Date_Dinscription", DateTime.Now.Date);

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


        public static bool UpdatePatient(string numeroPatient, int personID,int est_Assure, int? assureID = null)
        {
            string query = @"
        UPDATE D_Patient
        SET Person_ID = @PersonID,
            Assure_ID = @AssureID,
            est_Assure = @est_Assure
        WHERE Numero_Patient = @NumeroPatient";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroPatient", numeroPatient);
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@AssureID", assureID.HasValue ? (object)assureID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@est_Assure", est_Assure);


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


        public static bool DeletePatient(string numeroPatient)
        {
            int rowsAffected = 0;
            string query = @"UPDATE D_Patient SET est_Supprimer = 1 WHERE Numero_Patient = @NumeroPatient";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroPatient", numeroPatient);

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
