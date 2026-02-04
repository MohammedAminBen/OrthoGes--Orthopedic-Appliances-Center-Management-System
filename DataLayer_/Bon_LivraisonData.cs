using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_
{
    public class Bon_LivraisonData
    {
        public static string GenerateNumeroBon()
        {
            int lastNumber = 0;
            int currentYear = DateTime.Now.Year % 100; // 26

            string query = @"
                             SELECT ISNULL(MAX(CAST(LEFT(Numero_Bon, CHARINDEX('/', Numero_Bon) - 1) AS INT)), 0)
                             FROM D_Bon_Livraison
                             WHERE RIGHT(Numero_Bon, 2) = @Year;";

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

        public static bool GetBonLivData(string numeroBon, ref string numeroPatient, ref DateTime dateBon, ref string centrePayeur,ref string Piece_Produit,ref decimal Montant_TTC)
        {
            numeroPatient = centrePayeur = string.Empty;
            dateBon = DateTime.MinValue;

            string query = @"
        SELECT Numero_Patient, Date_Bon, Centre_Payeur,Piece_Produit,Montant_TTC
        FROM D_Bon_Livraison
        WHERE Numero_Bon = @Numero_Bon";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Numero_Bon", numeroBon);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read()) return false;

                    numeroPatient = reader["Numero_Patient"].ToString();
                    dateBon = (DateTime)reader["Date_Bon"];
                    centrePayeur = reader["Centre_Payeur"].ToString();
                    Piece_Produit = reader["Piece_Produit"].ToString();
                    Montant_TTC = (decimal)reader["Montant_TTC"];
                    return true;
                }
            }
        }

        public static List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA )> GetBonLivProduits(string numeroBon)
        {
            var produits = new List<(string, int, decimal, decimal, int)>();

            string query = @"
        SELECT Reference_Produit, QuantityProduit, Montant_TVA, Montant_TTC, TVA
        FROM D_Bon_Livraison_Produits
        WHERE Numero_Bon = @Numero_Bon";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Numero_Bon", numeroBon);
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

            return produits;
        }

        public static string CreateBonLiv(string BonNum,DateTime dateBon, string numeroPatient, string centrePayeur, string PieceProduit,decimal Montant_TTC,List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA)> produits)
        {
            if (produits == null || produits.Count == 0)
                throw new Exception("Bon de livraison must contain at least one product");


            string insertBonQuery = @"
        INSERT INTO D_Bon_Livraison
        (Numero_Bon, Date_Bon, Numero_Patient, Centre_Payeur, Piece_Produit,Montant_TTC)
        VALUES
        (@Numero_Bon, @Date_Bon, @Numero_Patient, @Centre_Payeur, @Piece_Produit,@montant)";

            string insertProduitQuery = @"
        INSERT INTO D_Bon_Livraison_Produits
        (Numero_Bon, Reference_Produit, QuantityProduit, Montant_TVA, Montant_TTC, TVA)
        VALUES
        (@Numero_Bon, @Reference_Produit, @Quantity, @Montant_TVA, @Montant_TTC, @TVA)";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(insertBonQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Numero_Bon", BonNum);
                        cmd.Parameters.AddWithValue("@Date_Bon", dateBon);
                        cmd.Parameters.AddWithValue("@Numero_Patient", numeroPatient);
                        cmd.Parameters.AddWithValue("@Centre_Payeur", centrePayeur);
                        cmd.Parameters.AddWithValue("@Piece_Produit",PieceProduit);
                        cmd.Parameters.AddWithValue("@montant",Montant_TTC);

                        cmd.ExecuteNonQuery();
                    }

                    foreach (var p in produits)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertProduitQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Numero_Bon", BonNum);
                            cmd.Parameters.AddWithValue("@Reference_Produit", p.Reference);
                            cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
                            cmd.Parameters.AddWithValue("@Montant_TVA", p.MontantTVA);
                            cmd.Parameters.AddWithValue("@Montant_TTC", p.MontantTTC);
                            cmd.Parameters.AddWithValue("@TVA", p.TVA);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return BonNum;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("CreateBonLiv error: " + ex.Message);
                    return null;
                }
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
        public static DataTable GetAllBonDePatient(string numeroPatient)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            CAST('Bon de livraison' AS VARCHAR(20)) AS Document_Type,
            b.Numero_Bon AS Numéro,
            STRING_AGG(bp.Reference_Produit, ' / ') AS References_Produits,
            b.Montant_TTC,
            b.Centre_Payeur,
            b.Date_Bon AS Date_Document
        FROM D_Bon_Livraison b
        LEFT JOIN D_Bon_Livraison_Produits bp ON b.Numero_Bon = bp.Numero_Bon
        WHERE b.Numero_Patient = @Numero_Patient
        GROUP BY b.Numero_Bon, b.Centre_Payeur, b.Date_Bon,b.Montant_TTC";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Numero_Patient", numeroPatient);
                connection.Open();
                dt.Load(command.ExecuteReader());
            }

            return dt;
        }

        public static bool DeleteBon_Livraison(string numeroBon)
        {
            string queryProduits = @"DELETE FROM D_Bon_Livraison_Produits WHERE Numero_Bon = @NumeroBon";
            string queryBon = @"DELETE FROM D_Bon_Livraison WHERE Numero_Bon = @NumeroBon";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand cmd1 = new SqlCommand(queryProduits, connection, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@NumeroBon", numeroBon);
                        cmd1.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd2 = new SqlCommand(queryBon, connection, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@NumeroBon", numeroBon);
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

            public static int GetBonsCount()
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT count(*) as CNT FROM D_Bon_Livraison";
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
        public static bool UpdateBon(string numero, DateTime dateBon, decimal montant, string centrePayeur, string piece)
        {
            string query = @"
        UPDATE D_Bon_Livraison
        SET 
            Date_Bon = @Date_Bon,
            Montant_TTC = @Montant_TTC,
            Centre_Payeur = @Centre_Payeur,
            Piece_Produit = @Piece_Produit
        WHERE Numero_Bon = @Numero_Bon;";

            try
            {
                using var connection = new SqlConnection(DataAccessSettings.ConnectionString);
                using var command = new SqlCommand(query, connection);

                command.Parameters.Add("@Numero_Bon", SqlDbType.NVarChar, 50).Value = numero;
                command.Parameters.Add("@Date_Bon", SqlDbType.DateTime).Value = dateBon;
                command.Parameters.Add("@Montant_TTC", SqlDbType.Decimal).Value = montant;
                command.Parameters.Add("@Centre_Payeur", SqlDbType.NVarChar, 50).Value = centrePayeur;
                command.Parameters.Add("@Piece_Produit", SqlDbType.NVarChar, 50).Value = piece;

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }


        public static bool UpdateBon_Produits(string bon, string oldReference, string reference, int quantity, decimal montantTva, decimal montantTtc, int tva)
        {
            string query = @"
        IF EXISTS (
            SELECT 1
            FROM D_Bon_Livraison_Produits
            WHERE Numero_Bon = @Numero_Bon
              AND Reference_Produit = @OldReference
        )
        BEGIN
            UPDATE D_Bon_Livraison_Produits
            SET
                Reference_Produit = @Reference,
                QuantityProduit = @Quantity,
                Montant_TVA = @Montant_TVA,
                Montant_TTC = @Montant_TTC,
                TVA = @TVA
            WHERE Numero_Bon = @Numero_Bon
              AND Reference_Produit = @OldReference;
        END
        ELSE
        BEGIN
        INSERT INTO D_Bon_Livraison_Produits
        (Numero_Bon, Reference_Produit, QuantityProduit, Montant_TVA, Montant_TTC, TVA)
        VALUES
        (@Numero_Bon, @Reference, @Quantity, @Montant_TVA, @Montant_TTC, @TVA);
        END";

            try
            {
                using var connection = new SqlConnection(DataAccessSettings.ConnectionString);
                using var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Numero_Bon", bon);
                command.Parameters.AddWithValue("@OldReference",oldReference);
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
