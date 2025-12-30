using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FactureData
    {
        public static string GenerateNumeroFacture()
        {
            int lastNumber = 0;
            int lastYear = 0;

            string query = @"
        SELECT TOP 1 Numero_Facture
        FROM D_Facture
        WHERE Numero_Facture IS NOT NULL
        ORDER BY Numero_Facture DESC;";

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
        public static bool CreateFacture(DateTime dateFacture, string numeroPatient, string referenceProduit, int etatPayement, int payementCheque, int quantity, decimal montantTVA, decimal montantTTC, int tva, string centrePayeur)
        {
            string numeroFacture = GenerateNumeroFacture();
            string query = @"
        INSERT INTO D_Facture
        (Numero_Facture, Date_Facture, Numero_Patient, Reference_Produit, etat_Payement,
         Payement_cheque, Quantity, Montant_TVA, Montant_TTC, TVA, Centre_Payeur)
        VALUES
        (@Numero_Facture, @Date_Facture, @Numero_Patient, @Reference_Produit, @etat_Payement,
         @Payement_cheque, @Quantity, @Montant_TVA, @Montant_TTC, @TVA, @Centre_Payeur)";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Numero_Facture", SqlDbType.VarChar).Value = numeroFacture;
                    command.Parameters.Add("@Date_Facture", SqlDbType.DateTime).Value = dateFacture;
                    command.Parameters.Add("@Numero_Patient", SqlDbType.VarChar).Value = numeroPatient;
                    command.Parameters.Add("@Reference_Produit", SqlDbType.VarChar).Value = referenceProduit;
                    command.Parameters.AddWithValue("@etat_Payement",etatPayement);
                    command.Parameters.Add("@Payement_cheque", SqlDbType.Bit).Value = payementCheque;
                    command.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                    command.Parameters.Add("@Montant_TVA", SqlDbType.Decimal).Value = montantTVA;
                    command.Parameters.Add("@Montant_TTC", SqlDbType.Decimal).Value = montantTTC;
                    command.Parameters.Add("@TVA", SqlDbType.Int).Value = tva;
                    command.Parameters.Add("@Centre_Payeur", SqlDbType.VarChar).Value = centrePayeur;

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

        public static DataTable GetAllFactures()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT [Numero_Facture]
      ,[Reference_Produit]
      ,p.Nom_Produit
      ,p.Prix
      ,[Quantity]
      ,f.TVA
      ,[Montant_TVA]
      ,[Montant_TTC]
      ,[Date_Facture]
      ,[Centre_Payeur]
      ,[etat_Payement]
      ,[Payement_cheque]
    FROM D_Facture f
    INNER JOIN R_Produit p ON f.Reference_Produit = p.Reference";

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

        public static DataTable GetAllFacturesDePatient(string numero_patient)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @" SELECT 
CAST('Facture' AS VARCHAR(20)) AS Document_Type,
      [Numero_Facture] AS Numéro,
      [Reference_Produit],
      p.Nom_Produit AS Désignation,
      p.Prix AS PUHT,	
      [Quantity] AS Quantité,
      d.TVA,
      [Montant_TVA],
      [Montant_TTC],
      [Date_Facture] AS Date_Document,
      [Centre_Payeur]
      
FROM D_Facture d
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
                Console.WriteLine("Error Facture :"+ ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

    }
}
