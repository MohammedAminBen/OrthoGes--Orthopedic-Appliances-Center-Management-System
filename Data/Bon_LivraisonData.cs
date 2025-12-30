using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Bon_LivraisonData
    {
        public static string GenerateNumeroBon()
        {
            int lastNumber = 0;
            int lastYear = 0;

            string query = @"
        SELECT TOP 1 Numero_Bon
        FROM D_Bon_Livraison
        WHERE Numero_Bon IS NOT NULL
        ORDER BY Numero_Bon DESC;";

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
        public static bool CreateBonLiv(string Numero_Patient, string Reference_Produit, DateTime Date_devis, int quantity, decimal montant_tva, decimal montant_TTC, string Centre_Payeur, int TVA, string Piece_Produit)
        {
            string numero_Devis = GenerateNumeroBon();
            string query = @"
              INSERT INTO D_Bon_Livraison (Numero_Bon,Numero_Patient,Reference_Produit,Date_Bon,Quantity_Produit,Montant_TVA,Montant_TTC,Centre_Payeur,TVA,Piece_Produit)
              VALUES (@Numero_Bon,@Numero_Patient,@Reference_Produit,@Date_Bon,@Quantity,@Montant_TVA,@Montant_TTC,@Centre_Payeur,@tva,@piece)";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Numero_Patient", Numero_Patient);
                    command.Parameters.AddWithValue("@Numero_Bon", numero_Devis);
                    command.Parameters.AddWithValue("@Reference_Produit", Reference_Produit);
                    command.Parameters.AddWithValue("@Date_Bon", Date_devis);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Montant_TVA", montant_tva);
                    command.Parameters.AddWithValue("@Montant_TTC", montant_TTC);
                    command.Parameters.AddWithValue("@Centre_Payeur", Centre_Payeur);
                    command.Parameters.AddWithValue("@piece", Piece_Produit);
                    command.Parameters.AddWithValue("@tva", TVA);

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
        public static DataTable GetAllBon()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT [Numero_Bon]
      ,[Reference_Produit]
	  ,p.Nom_Produit
	  ,p.Prix
	  ,[Quantity_Produit]
	  ,d.TVA
	  ,[Montant_TVA]
	  ,[Montant_TTC]
      ,[Date_Devis]
      ,[Centre_Payeur]
      ,d.Piece_Prouit
       FROM D_Bon_Livraison d
       INNER JOIN R_Produit p on d.Reference_Produit = p.Reference";


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
        public static DataTable GetAllBonDePatient(string numero_patient)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @" SELECT 
CAST('Bon livraison' AS VARCHAR(20)) AS Document_Type,
      [Numero_Bon] AS Numéro,
      [Reference_Produit],
      p.Nom_Produit AS Désignation,
      p.Prix AS PUHT,	
      [Quantity_Produit] AS Quantité,
      d.TVA,
      [Montant_TVA],
      [Montant_TTC],
      [Date_Bon]AS Date_Document,
      [Centre_Payeur]
      
FROM D_Bon_Livraison d
INNER JOIN R_Produit p ON d.Reference_Produit = p.Reference
       WHERE d.Numero_Patient = @Numero_Patient";


            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Numero_Patient", numero_patient);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Bon_Livraison : "+ ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }
    }
}
