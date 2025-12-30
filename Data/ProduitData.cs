using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProduitData
    {
        public static bool GetProduitInfoByReference(string Reference_Produit, ref string Designation, ref Double Tarif, ref int tva, ref Double TarifTTC,ref int Quantity,ref int CategroryID,ref string Category_Nom,ref int delai)
        {
            bool isFound = false;

            string query = @"        SELECT [Reference]
      ,[Nom_Produit]
      ,p.[Category_ID]
	  ,c.Category_Nom
      ,[Prix]
      ,[TVA]
      ,[Prix_TVA]
      ,[Quantite]
	  ,c.Category_Delai
        FROM R_Produit p
        INNER JOIN R_Category_Produit c ON p.Category_ID = c.Category_ID
        WHERE p.Reference = @Reference";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Reference", Reference_Produit);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            Designation = reader["Nom_Produit"].ToString();
                            Tarif = (Double)reader["Prix"];
                            tva = (int)reader["TVA"];
                            CategroryID = (int)reader["Category_ID"];
                            TarifTTC = (Double)reader["Prix_TVA"];
                            Category_Nom = reader["Category_Nom"].ToString();
                            delai = (int)reader["Category_Delai"];
                            Quantity = (int)reader["Quantite"];
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
	  ,c.Category_Delai
        FROM R_Produit p
        INNER JOIN R_Category_Produit c ON p.Category_ID = c.Category_ID";


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

    }
}
