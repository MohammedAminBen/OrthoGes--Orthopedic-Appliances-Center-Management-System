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
    public class ProduitData
    {

        public static bool AddNewProduit(string reference, string nomProduit, int categoryID, decimal prix, int tva, int quantite,decimal prixTVA)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"
        INSERT INTO R_Produit
        (Reference, Nom_Produit, Category_ID, Prix, TVA, Prix_TVA, Quantite)
        VALUES
        (@Reference, @Nom_Produit, @Category_ID, @Prix, @TVA, @Prix_TVA, @Quantite);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Reference", reference);
                    command.Parameters.AddWithValue("@Nom_Produit", nomProduit);
                    command.Parameters.AddWithValue("@Category_ID", categoryID);
                    command.Parameters.AddWithValue("@Prix", prix);
                    command.Parameters.AddWithValue("@TVA", tva);
                    command.Parameters.AddWithValue("@Prix_TVA", prixTVA);
                    command.Parameters.AddWithValue("@Quantite", quantite);

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
        public static bool UpdateProduit(string reference, string nomProduit, int categoryID, decimal prix, int tva, int quantite, decimal prixTVA)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"
		UPDATE R_Produit SET 
		Nom_Produit = @Nom_Produit,
		Category_ID = @Category_ID,
		Prix = @Prix,
		TVA = @TVA,
		Prix_TVA = @Prix_TVA,
		Quantite = @Quantite
		WHERE Reference = @Reference;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Reference", reference);
                    command.Parameters.AddWithValue("@Nom_Produit", nomProduit);
                    command.Parameters.AddWithValue("@Category_ID", categoryID);
                    command.Parameters.AddWithValue("@Prix", prix);
                    command.Parameters.AddWithValue("@TVA", tva);
                    command.Parameters.AddWithValue("@Prix_TVA", prixTVA);
                    command.Parameters.AddWithValue("@Quantite", quantite);

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
        public static bool GetProduitInfoByReference(
            string Reference_Produit,
            ref string Designation,
            ref double Tarif,
            ref int tva,
            ref double TarifTTC,
            ref int Quantity,
            ref int CategroryID,
            ref string Category_Nom,
            ref int Category_Delai_Année,
            ref int Category_Delai_Mois
            )
        {
            bool isFound = false;

            string query = @"
        SELECT p.Reference,
               p.Nom_Produit,
               p.Category_ID,
               c.Category_Nom,
               p.Prix,
               p.TVA,
               p.Prix_TVA,
               p.Quantite,
               c.Category_Delai_Année,
                c.Category_Delai_Mois
        FROM R_Produit p
        INNER JOIN R_Category_Produit c ON p.Category_ID = c.Category_ID
        WHERE p.Reference = @Reference";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = Reference_Produit;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            Designation = reader["Nom_Produit"]?.ToString();
                            Category_Nom = reader["Category_Nom"]?.ToString();

                            Tarif = reader["Prix"] != DBNull.Value ? Convert.ToDouble(reader["Prix"]) : 0;
                            TarifTTC = reader["Prix_TVA"] != DBNull.Value ? Convert.ToDouble(reader["Prix_TVA"]) : 0;
                            tva = reader["TVA"] != DBNull.Value ? Convert.ToInt32(reader["TVA"]) : 0;
                            Quantity = reader["Quantite"] != DBNull.Value ? Convert.ToInt32(reader["Quantite"]) : 0;
                            CategroryID = reader["Category_ID"] != DBNull.Value ? Convert.ToInt32(reader["Category_ID"]) : 0;
                            Category_Delai_Année = reader["Category_Delai_Année"] != DBNull.Value ? Convert.ToInt32(reader["Category_Delai_Année"]) : 0;
                            Category_Delai_Mois = reader["Category_Delai_Mois"] != DBNull.Value ? Convert.ToInt32(reader["Category_Delai_Mois"]) : 0;
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


        public static DataTable GetAllProduits()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"        SELECT [Reference]
      ,[Nom_Produit]
      ,p.[Category_ID]
	  ,c.Category_Nom
      ,[Prix]
      ,[TVA]
      ,[Prix_TVA]
      ,[Quantite]
        FROM R_Produit p
        INNER JOIN R_Category_Produit c ON p.Category_ID = c.Category_ID
        ORDER BY c.Category_Nom";


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
                Console.WriteLine("Error Produit :"+ ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;

      
        }
        public static DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"select  
        Category_ID,
	  Category_Nom
        FROM R_Category_Produit
        ORDER BY Category_Nom";


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
                Console.WriteLine("Error Category : "+ ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

    }
}
