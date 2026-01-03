using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataLayer_
{
    public class PersonData
    {
        public static bool GetPersonInfoByID(
            int personID,
            ref string nom,
            ref string prenom,
            ref string nomArabe,
            ref string prenomArabe,
            ref string[] telephones,
            ref string email,
            ref string wilaya,
            ref string commune,
            ref string adresse,
            ref DateTime dateNaissance,
            ref int genre)
        {
            bool isFound = false;
            List<string> phoneList = new List<string>();

            using (SqlConnection connection =
                new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 
                p.Nom,
                p.Prenom,
                p.Nom_Arabe,
                p.Prenom_Arabe,
                p.Email,
                p.Date_Naissance,
                p.Genre,
                a.Wilaya,
                a.Commune,
                a.Adresse,
                t.Telephone
            FROM D_Person p
            LEFT JOIN D_Adresse a ON p.Person_ID = a.Person_ID
            LEFT JOIN D_Telephone t ON p.Person_ID = t.Person_ID
            WHERE p.Person_ID = @Person_ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Person_ID", SqlDbType.Int).Value = personID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!isFound)
                                {
                                    isFound = true;

                                    nom = reader["Nom"]?.ToString() ?? "---";
                                    prenom = reader["Prenom"]?.ToString() ?? "---";
                                    nomArabe = reader["Nom_Arabe"]?.ToString() ?? string.Empty;
                                    prenomArabe = reader["Prenom_Arabe"]?.ToString() ?? string.Empty;
                                    email = reader["Email"]?.ToString() ?? string.Empty;

                                    wilaya = reader["Wilaya"]?.ToString() ?? "---";
                                    commune = reader["Commune"]?.ToString() ?? "---";
                                    adresse = reader["Adresse"]?.ToString() ?? "---";
                                    genre = (int)reader["Genre"];

                                    dateNaissance = reader["Date_Naissance"] != DBNull.Value
                                        ? (DateTime)reader["Date_Naissance"]
                                        : DateTime.MinValue;
                                }

                                if (reader["Telephone"] != DBNull.Value)
                                {
                                    phoneList.Add(reader["Telephone"].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Database error: " + ex.Message);
                        return false;
                    }
                }
            }

            telephones = phoneList.Count > 0
                ? phoneList.ToArray()
                : new string[] { "---" };

            return isFound;
        }


        public static int AddNewPerson(
            string nom,
            string prenom,
            string nomArabe,
            string prenomArabe,
            string[] telephones,
            string email,
            string wilaya,
            string commune,
            string adresse,
            DateTime dateNaissance,
            int genre)
        {
            int personID = -1;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string insertPersonQuery = @"
            INSERT INTO D_Person
                (Nom, Prenom, Nom_Arabe, Prenom_Arabe, Email, Date_Naissance,Genre)
            VALUES
                (@Nom, @Prenom, @Nom_Arabe, @Prenom_Arabe, @Email, @DateNaissance,@genre);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(insertPersonQuery, connection))
                {
                    command.Parameters.AddWithValue("@Nom", nom);
                    command.Parameters.AddWithValue("@Prenom", prenom);
                    command.Parameters.AddWithValue("@genre", genre);
                    // Nom_Arabe
                    if (string.IsNullOrWhiteSpace(nomArabe))
                        command.Parameters.Add("@Nom_Arabe", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@Nom_Arabe", SqlDbType.NVarChar, 100).Value = nomArabe;

                    // Prenom_Arabe
                    if (string.IsNullOrWhiteSpace(prenomArabe))
                        command.Parameters.Add("@Prenom_Arabe", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@Prenom_Arabe", SqlDbType.NVarChar, 100).Value = prenomArabe;

                    // Email
                    if (string.IsNullOrWhiteSpace(email))
                        command.Parameters.Add("@Email", SqlDbType.NVarChar, 200).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@Email", SqlDbType.NVarChar, 200).Value = email;

                    // DateNaissance
                    if (dateNaissance == DateTime.MinValue)
                        command.Parameters.Add("@DateNaissance", SqlDbType.DateTime).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@DateNaissance", SqlDbType.DateTime).Value = dateNaissance;


                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result == null || !int.TryParse(result.ToString(), out personID))
                            return -1;

                        /* ================= TELEPHONES ================= */
                        if (telephones != null)
                        {
                            foreach (string phone in telephones)
                            {
                                if (!string.IsNullOrWhiteSpace(phone))
                                {
                                    SqlCommand phoneCmd = new SqlCommand(
                                        "INSERT INTO D_Telephone (Person_ID, Telephone) VALUES (@PID, @Tel)",
                                        connection);

                                    phoneCmd.Parameters.AddWithValue("@PID", personID);
                                    phoneCmd.Parameters.AddWithValue("@Tel", phone);
                                    phoneCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        /* ================= ADRESSE ================= */
                        if (!string.IsNullOrWhiteSpace(adresse))
                        {
                            SqlCommand addressCmd = new SqlCommand(
                                @"INSERT INTO D_Adresse (Person_ID, Wilaya, Commune, Adresse)
                          VALUES (@PID, @Wilaya, @Commune, @Adresse)", connection);

                            addressCmd.Parameters.AddWithValue("@PID", personID);
                            addressCmd.Parameters.AddWithValue("@Wilaya", wilaya);
                            addressCmd.Parameters.AddWithValue("@Commune", commune);
                            addressCmd.Parameters.AddWithValue("@Adresse", adresse);
                            addressCmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Database error: " + ex.Message);
                        return -1;
                    }
                }
            }

            return personID;
        }


        public static bool UpdatePerson(
            int personID,
            string nom,
            string prenom,
            string nomArabe,
            string prenomArabe,
            string[] telephones,
            string email,
            string wilaya,
            string commune,
            string adresse,
            DateTime dateNaissance,
            int genre)
        {
            using (SqlConnection connection =
                new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string updatePersonQuery = @"
            UPDATE D_Person
            SET Nom = @Nom,
                Prenom = @Prenom,
                Nom_Arabe = @Nom_Arabe,
                Prenom_Arabe = @Prenom_Arabe,
                Email = @Email,
                Date_Naissance = @DateNaissance,
                Genre = @genre
            WHERE Person_ID = @PersonID";

                using (SqlCommand command = new SqlCommand(updatePersonQuery, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@Nom", nom);
                    command.Parameters.AddWithValue("@Prenom", prenom);
                    command.Parameters.AddWithValue("@genre", genre);
                    // Nom_Arabe
                    if (string.IsNullOrWhiteSpace(nomArabe))
                        command.Parameters.Add("@Nom_Arabe", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@Nom_Arabe", SqlDbType.NVarChar, 100).Value = nomArabe;

                    // Prenom_Arabe
                    if (string.IsNullOrWhiteSpace(prenomArabe))
                        command.Parameters.Add("@Prenom_Arabe", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@Prenom_Arabe", SqlDbType.NVarChar, 100).Value = prenomArabe;

                    // Email
                    if (string.IsNullOrWhiteSpace(email))
                        command.Parameters.Add("@Email", SqlDbType.NVarChar, 200).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@Email", SqlDbType.NVarChar, 200).Value = email;

                    // DateNaissance
                    if (dateNaissance == DateTime.MinValue)
                        command.Parameters.Add("@DateNaissance", SqlDbType.DateTime).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@DateNaissance", SqlDbType.DateTime).Value = dateNaissance;


                    try
                    {
                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            return false; // Person not found

                        /* ================= TELEPHONES ================= */
                        if (telephones != null)
                        {
                            // Delete existing phones
                            SqlCommand deletePhones = new SqlCommand(
                                "DELETE FROM D_Telephone WHERE Person_ID = @PID", connection);
                            deletePhones.Parameters.AddWithValue("@PID", personID);
                            deletePhones.ExecuteNonQuery();

                            // Insert new phones
                            foreach (string phone in telephones)
                            {
                                if (!string.IsNullOrWhiteSpace(phone))
                                {
                                    SqlCommand phoneCmd = new SqlCommand(
                                        "INSERT INTO D_Telephone (Person_ID, Telephone) VALUES (@PID, @Tel)",
                                        connection);
                                    phoneCmd.Parameters.AddWithValue("@PID", personID);
                                    phoneCmd.Parameters.AddWithValue("@Tel", phone);
                                    phoneCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        /* ================= ADRESSE ================= */
                        // Delete existing address
                        SqlCommand deleteAddress = new SqlCommand(
                            "DELETE FROM D_Adresse WHERE Person_ID = @PID", connection);
                        deleteAddress.Parameters.AddWithValue("@PID", personID);
                        deleteAddress.ExecuteNonQuery();

                        // Insert new address if provided
                        if (!string.IsNullOrWhiteSpace(adresse))
                        {
                            SqlCommand addressCmd = new SqlCommand(
                                @"INSERT INTO D_Adresse (Person_ID, Wilaya, Commune, Adresse)
                          VALUES (@PID, @Wilaya, @Commune, @Adresse)", connection);

                            addressCmd.Parameters.AddWithValue("@PID", personID);
                            addressCmd.Parameters.AddWithValue("@Wilaya", wilaya);
                            addressCmd.Parameters.AddWithValue("@Commune", commune);
                            addressCmd.Parameters.AddWithValue("@Adresse", adresse);
                            addressCmd.ExecuteNonQuery();
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Database error: " + ex.Message);
                        return false;
                    }
                }
            }
        }


        public static DataTable GetAllPersons()
        {
            DataTable table = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * From D_Person ORDER BY Nom";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
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
            return table;
        }
        public static bool DeletePerson(int personID)
        {
            int rowsAffected = 0;

            string deletePersonQuery = @"DELETE FROM D_Person WHERE Person_ID = @PersonID";
            string deletePhonesQuery = @"DELETE FROM D_Telephone WHERE Person_ID = @PersonID";
            string deleteAddressQuery = @"DELETE FROM D_Adresse WHERE Person_ID = @PersonID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    // Delete related phones
                    using (SqlCommand cmdPhones = new SqlCommand(deletePhonesQuery, connection))
                    {
                        cmdPhones.Parameters.AddWithValue("@PersonID", personID);
                        cmdPhones.ExecuteNonQuery();
                    }

                    // Delete related address
                    using (SqlCommand cmdAddress = new SqlCommand(deleteAddressQuery, connection))
                    {
                        cmdAddress.Parameters.AddWithValue("@PersonID", personID);
                        cmdAddress.ExecuteNonQuery();
                    }

                    // Delete person
                    using (SqlCommand cmdPerson = new SqlCommand(deletePersonQuery, connection))
                    {
                        cmdPerson.Parameters.AddWithValue("@PersonID", personID);
                        rowsAffected = cmdPerson.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }

            return rowsAffected > 0;
        }

        public static bool IsPersonExist(int PersonId)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "Select Found = 1 from D_Person where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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
            return isFound;
        }
    }
}
