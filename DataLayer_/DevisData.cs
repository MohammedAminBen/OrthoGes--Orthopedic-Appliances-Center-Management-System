using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_
{
    public class DevisData
    {
        public static string GenerateNumeroDevis()
        {
            int lastNumber = 0;
            int currentYear = DateTime.Now.Year % 100; // 26

            string query = @"
                             SELECT ISNULL(MAX(CAST(LEFT(Numero_Devis, CHARINDEX('/', Numero_Devis) - 1) AS INT)), 0)
                             FROM D_Devis
                             WHERE RIGHT(Numero_Devis, 2) = @Year;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Year", currentYear.ToString("D2"));

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        lastNumber = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // during dev
                throw;
            }

            lastNumber++; // increment safely

            return $"{lastNumber}/{currentYear:D2}";
        }
        public static bool GetDevisData(string numeroDevis, ref string numeroPatient, ref DateTime dateDevis, ref decimal montantTTC, ref string centrePayeur)
        {
            numeroPatient = centrePayeur = string.Empty;
            dateDevis = DateTime.MinValue;
            montantTTC = 0;

            string query = @"
        SELECT 
            Numero_Patient,
            Date_Devis,
            Montant_TTC,
            Centre_Payeur
        FROM D_Devis
        WHERE Numero_Devis = @NumeroDevis";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroDevis", numeroDevis);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        numeroPatient = reader["Numero_Patient"].ToString();
                        dateDevis = (DateTime)reader["Date_Devis"];
                        montantTTC = (decimal)reader["Montant_TTC"];
                        centrePayeur = reader["Centre_Payeur"].ToString();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDevisData error: " + ex.Message);
                return false;
            }
        }

        public static List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA)>
GetDevisProduits(string numeroDevis)
        {
            var produits = new List<(string, int, decimal, decimal, int)>();

            string query = @"
        SELECT 
            dp.Reference_Produit,
            dp.QuantityProduit,
            dp.Montant_TVA,
            dp.Montant_TTC,
            dp.TVA
        FROM D_Devis_Produits dp
        WHERE dp.Numero_Devis = @NumeroDevis";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroDevis", numeroDevis);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produits.Add((
                                reader["Reference_Produit"].ToString(),
                                (int)reader["QuantityProduit"],
                                (decimal)reader["Montant_TVA"],
                                (decimal)reader["Montant_TTC"],
                                (int)reader["TVA"]
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDevisProduits error: " + ex.Message);
            }

            return produits;
        }
        

        public static string CreateDevis(string numDevis,
     string Numero_Patient,
     DateTime Date_Devis,
     string Centre_Payeur,
     List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA)> produits,
     decimal Montantttc
 )
        {
            

            string insertDevisQuery = @"
        INSERT INTO D_Devis (Numero_Devis, Numero_Patient, Date_Devis, Centre_Payeur,Montant_TTC)
        VALUES (@Numero_Devis, @Numero_Patient, @Date_Devis, @Centre_Payeur,@Montant_ttc);";

            string insertProduitQuery = @"
        INSERT INTO D_Devis_Produits
        (Numero_Devis, Reference_Produit, QuantityProduit, Montant_TVA, Montant_TTC, TVA)
        VALUES
        (@Numero_Devis, @Reference_Produit, @QuantityProduit, @Montant_TVA, @Montant_TTC, @TVA);";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 🔹 Insert devis header
                    using (SqlCommand cmd = new SqlCommand(insertDevisQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Numero_Devis", numDevis);
                        cmd.Parameters.AddWithValue("@Numero_Patient", Numero_Patient);
                        cmd.Parameters.AddWithValue("@Date_Devis", Date_Devis);
                        cmd.Parameters.AddWithValue("@Centre_Payeur", Centre_Payeur);
                        cmd.Parameters.AddWithValue("@Montant_ttc", Montantttc);


                        cmd.ExecuteNonQuery();
                    }

                    // 🔹 Insert devis products
                    foreach (var p in produits)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertProduitQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Numero_Devis", numDevis);
                            cmd.Parameters.AddWithValue("@Reference_Produit", p.Reference);
                            cmd.Parameters.AddWithValue("@QuantityProduit", p.Quantity);
                            cmd.Parameters.AddWithValue("@Montant_TVA", p.MontantTVA);
                            cmd.Parameters.AddWithValue("@Montant_TTC", p.MontantTTC);
                            cmd.Parameters.AddWithValue("@TVA", p.TVA);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return numDevis;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Database Error: " + ex.Message);
                    return null;
                }
            }
        }

        public static DataTable GetAllDevis()
        {
            DataTable dt = new DataTable();

            string query = @"
    SELECT 
        d.Numero_Devis,
        dp.Reference_Produit,
        p.Nom_Produit,
        p.Prix,
        dp.QuantityProduit,
        dp.TVA,
        dp.Montant_TVA,
        dp.Montant_TTC,
        SUM(dp.Montant_TVA) OVER(PARTITION BY d.Numero_Devis) AS Total_TVA,
        SUM(dp.Montant_TTC) OVER(PARTITION BY d.Numero_Devis) AS Total_TTC,
        d.Date_Devis,
        d.Centre_Payeur
    FROM D_Devis d
    INNER JOIN D_Devis_Produits dp ON d.Numero_Devis = dp.Numero_Devis
    INNER JOIN R_Produit p ON dp.Reference_Produit = p.Reference
    ORDER BY d.Numero_Devis;
";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                dt.Load(command.ExecuteReader());
            }

            return dt;
        }

        public static DataTable GetAllDevisDePatient(string numero_patient)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"   SELECT 
CAST('Devis' AS VARCHAR(20)) AS Document_Type,
      d.Numero_Devis AS Numéro,
	  STRING_AGG(dp.Reference_Produit, ' / ') AS References_Produits,
      d.Montant_TTC,
	  d.Centre_Payeur,  
      d.Date_Devis AS Date_Document
FROM D_Devis d
LEFT JOIN D_Devis_Produits dp
ON d.Numero_Devis = dp.Numero_Devis
WHERE d.Numero_Patient = @Numero_Patient
GROUP BY 
    d.Numero_Devis,
    d.Date_Devis,
    d.Montant_TTC,
    d.Centre_Payeur;";


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
        public static bool DeleteDevis(string numeroDevis)
        {
            string queryProduits = @"DELETE FROM D_Devis_Produits WHERE Numero_Devis = @NumeroDevis";
            string queryDevis = @"DELETE FROM D_Devis WHERE Numero_Devis = @NumeroDevis";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand cmd1 = new SqlCommand(queryProduits, connection, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@NumeroDevis", numeroDevis);
                        cmd1.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd2 = new SqlCommand(queryDevis, connection, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@NumeroDevis", numeroDevis);
                        cmd2.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
            public static int GetDevisCount()
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT count(*) as CNT FROM D_Devis";
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
        public static bool UpdateDevis(string numero, DateTime dateDevis, decimal montant, string centrePayeur)
        {
            string query = @"
        UPDATE D_Devis
        SET 
            Date_Devis = @Date_Devis,
            Montant_TTC = @Montant_TTC,
            Centre_Payeur = @Centre_Payeur
            WHERE Numero_Devis = @Numero_Devis;";

            try
            {
                using var connection = new SqlConnection(DataAccessSettings.ConnectionString);
                using var command = new SqlCommand(query, connection);

                command.Parameters.Add("@Numero_Devis", SqlDbType.NVarChar, 50).Value = numero;
                command.Parameters.Add("@Date_Devis", SqlDbType.DateTime).Value = dateDevis;
                command.Parameters.Add("@Montant_TTC", SqlDbType.Decimal).Value = montant;
                command.Parameters.Add("@Centre_Payeur", SqlDbType.NVarChar, 50).Value = centrePayeur;
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }


        public static bool UpdateDevis_Produits(string devis, string oldReference, string reference, int quantity, decimal montantTva, decimal montantTtc, int tva)
        {
            string query = @"
        IF EXISTS (
            SELECT 1
            FROM D_Devis_Produits
            WHERE Numero_Devis = @Numero_Devis
              AND Reference_Produit = @OldReference
        )
        BEGIN
            UPDATE D_Devis_Produits
            SET
                Reference_Produit = @Reference,
                QuantityProduit = @Quantity,
                Montant_TVA = @Montant_TVA,
                Montant_TTC = @Montant_TTC,
                TVA = @TVA
            WHERE Numero_Devis = @Numero_Devis
              AND Reference_Produit = @OldReference;
        END
        ELSE
        BEGIN
        INSERT INTO D_Devis_Produits
        (Numero_Devis, Reference_Produit, QuantityProduit, Montant_TVA, Montant_TTC, TVA)
        VALUES
        (@Numero_Devis, @Reference, @Quantity, @Montant_TVA, @Montant_TTC, @TVA);
        END";

            try
            {
                using var connection = new SqlConnection(DataAccessSettings.ConnectionString);
                using var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Numero_Devis", devis);
                command.Parameters.AddWithValue("@OldReference", oldReference);
                command.Parameters.AddWithValue("@Reference", reference);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Montant_TVA", montantTva);
                command.Parameters.AddWithValue("@Montant_TTC", montantTtc);
                command.Parameters.AddWithValue("@TVA", tva);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
