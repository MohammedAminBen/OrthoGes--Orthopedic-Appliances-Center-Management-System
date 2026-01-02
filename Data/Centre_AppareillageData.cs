using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Centre_AppareillageData
    {
        public static bool GetCentreByID(int centreID, ref string centreNom, ref string adresse, ref string contact, ref string numeroRC, ref string nif, ref string rib, ref string numeroART, ref string pathImage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"
        SELECT Centre_Nom, Adresse, Contact, Numero_RC, NIF, RIB, Numero_ART, Path_Image
        FROM A_Center_Appareillage
        WHERE Centre_ID = @Centre_ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Centre_ID", centreID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                centreNom = reader["Centre_Nom"]?.ToString() ?? "";
                                adresse = reader["Adresse"]?.ToString() ?? "";
                                contact = reader["Contact"]?.ToString() ?? "";
                                numeroRC = reader["Numero_RC"]?.ToString() ?? "";
                                nif = reader["NIF"]?.ToString() ?? "";
                                rib = reader["RIB"]?.ToString() ?? "";
                                numeroART = reader["Numero_ART"]?.ToString() ?? "";
                                pathImage = reader["Path_Image"]?.ToString() ?? "";
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

            return isFound;
        }

        public static int AddNewCentre(string centreNom, string adresse, string contact, string numeroRC, string nif, string rib, string numeroART, string pathImage)
        {
            int centreID = 1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"
        INSERT INTO A_Center_Appareillage
        (Centre_Nom, Adresse, Contact, Numero_RC, NIF, RIB, Numero_ART, Path_Image,Centre_ID)
        VALUES
        (@Centre_Nom, @Adresse, @Contact, @Numero_RC, @NIF, @RIB, @Numero_ART, @Path_Image,@Centre_ID);
        SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Centre_ID", centreID);
                    command.Parameters.AddWithValue("@Centre_Nom", centreNom);
                    command.Parameters.AddWithValue("@Adresse", adresse);
                    command.Parameters.AddWithValue("@Contact", contact);
                    command.Parameters.AddWithValue("@Numero_RC", numeroRC);
                    command.Parameters.AddWithValue("@NIF", nif);
                    command.Parameters.AddWithValue("@RIB", rib);
                    command.Parameters.AddWithValue("@Numero_ART", numeroART);
                    command.Parameters.AddWithValue("@Path_Image", string.IsNullOrWhiteSpace(pathImage) ? DBNull.Value : (object)pathImage);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out centreID))
                            return centreID;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Database error: " + ex.Message);
                    }
                }
            }

            return 1;
        }

        public static bool UpdateCentre(int centreID, string centreNom, string adresse, string contact, string numeroRC, string nif, string rib, string numeroART, string pathImage)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"
        UPDATE A_Center_Appareillage
        SET Centre_Nom = @Centre_Nom,
            Adresse = @Adresse,
            Contact = @Contact,
            Numero_RC = @Numero_RC,
            NIF = @NIF,
            RIB = @RIB,
            Numero_ART = @Numero_ART,
            Path_Image = @Path_Image
        WHERE Centre_ID = @Centre_ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Centre_ID", centreID);
                    command.Parameters.AddWithValue("@Centre_Nom", centreNom);
                    command.Parameters.AddWithValue("@Adresse", adresse);
                    command.Parameters.AddWithValue("@Contact", contact);
                    command.Parameters.AddWithValue("@Numero_RC", numeroRC);
                    command.Parameters.AddWithValue("@NIF", nif);
                    command.Parameters.AddWithValue("@RIB", rib);
                    command.Parameters.AddWithValue("@Numero_ART", numeroART);
                    command.Parameters.AddWithValue("@Path_Image", string.IsNullOrWhiteSpace(pathImage) ? DBNull.Value : (object)pathImage);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Database error: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        

    }
}
