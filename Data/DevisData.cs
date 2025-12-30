using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DevisData
    {
        public static string GenerateNumeroDevis()
        {
            int lastNumber = 0;
            int lastYear = 0;

            string query = @"
        SELECT TOP 1 Numero_Devis
        FROM D_Devis
        WHERE Numero_Devis IS NOT NULL
        ORDER BY Numero_Devis DESC;";

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
        public static bool CreateDevis(string Numero_Patient, string Reference_Produit, DateTime Date_devis, int quantity,decimal montant_tva, decimal montant_TTC, string Centre_Payeur,int TVA)
        {
            string numero_Devis = GenerateNumeroDevis();
            string query = @"
              INSERT INTO D_Devis (Numero_Devis,Numero_Patient,Reference_Produit,Date_Devis,Quantity_Produit,Montant_TVA,Montant_TTC,Centre_Payeur,TVA)
              VALUES (@Numero_Devis,@Numero_Patient,@Reference_Produit,@Date_Devis,@Quantity,@Montant_TVA,@Montant_TTC,@Centre_Payeur,@tva)";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Numero_Patient", Numero_Patient);
                    command.Parameters.AddWithValue("@Numero_Devis", numero_Devis);
                    command.Parameters.AddWithValue("@Reference_Produit", Reference_Produit);
                    command.Parameters.AddWithValue("@Date_Devis", Date_devis);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Montant_TVA", montant_tva);
                    command.Parameters.AddWithValue("@Montant_TTC", montant_TTC);
                    command.Parameters.AddWithValue("@Centre_Payeur", Centre_Payeur);
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
        public static DataTable GetAllDevis()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT [Numero_Devis]
      ,[Reference_Produit]
	  ,p.Nom_Produit
	  ,p.Prix
	  ,[Quantity_Produit]
	  ,d.TVA
	  ,[Montant_TVA]
	  ,[Montant_TTC]
      ,[Date_Devis]
      ,[Centre_Payeur]
       FROM D_Devis d
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
        public static DataTable GetAllDevisDePatient(string numero_patient)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @" SELECT
CAST('Devis' AS VARCHAR(20)) AS Document_Type,
      [Numero_Devis] AS Numéro,
      [Reference_Produit],
      p.Nom_Produit AS Désignation,
      p.Prix AS PUHT,	
      [Quantity_Produit] AS Quantité,
      d.TVA,
      [Montant_TVA],
      [Montant_TTC],
      [Date_Devis] AS Date_Document,
      [Centre_Payeur]
      
FROM D_Devis d
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
                Console.WriteLine("Error Devis :"+ ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }
    }
}
