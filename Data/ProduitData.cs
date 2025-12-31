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
        public static bool GetProduitInfoByReference(
            string Reference_Produit,
            ref string Designation,
            ref double Tarif,
            ref int tva,
            ref double TarifTTC,
            ref int Quantity,
            ref int CategroryID,
            ref string Category_Nom,
            ref int delai)
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
               c.Category_Delai
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
                            delai = reader["Category_Delai"] != DBNull.Value ? Convert.ToInt32(reader["Category_Delai"]) : 0;
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
