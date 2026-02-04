using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace DataLayer_
{
    public class FactureData
    {
        public static string GenerateNumeroFacture()
        {
            int lastNumber = 0;
            int currentYear = DateTime.Now.Year % 100; // 26

            string query = @"
                             SELECT ISNULL(MAX(CAST(LEFT(Numero_Facture, CHARINDEX('/', Numero_Facture) - 1) AS INT)), 0)
                             FROM D_Facture
                             WHERE RIGHT(Numero_Facture, 2) = @Year;";

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
        public static bool GetFactureData(
         string numeroFacture,
         ref string numeroPatient,
         ref DateTime dateFacture,
         ref int etatPayement,
         ref int payementCheque,
         ref decimal montantTTC,
         ref string centrePayeur)
        {
            numeroPatient = centrePayeur = string.Empty;
            dateFacture = DateTime.MinValue;
            etatPayement = payementCheque = 0;
            montantTTC = 0;

            string query = @"
                SELECT 
                    Numero_Patient,
                     Date_Facture,
                    etat_Payement,
                    Payement_cheque,
                    Montant_TTC,
                    Centre_Payeur
                FROM D_Facture
                WHERE Numero_Facture = @NumeroFacture";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroFacture", numeroFacture);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        numeroPatient = reader["Numero_Patient"].ToString();
                        dateFacture = (DateTime)reader["Date_Facture"];
                        etatPayement = (int)reader["etat_Payement"];
                        payementCheque = Convert.ToInt32(reader["Payement_cheque"]);
                        montantTTC = (decimal)reader["Montant_TTC"];
                        centrePayeur = reader["Centre_Payeur"].ToString();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetFactureData error: " + ex.Message);
                return false;
            }
        }

        public static List<(string Reference,
                    int Quantity,
                    decimal MontantTVA,
                    decimal MontantTTC,
                    int TVA,
                    DateTime DateDelai)> GetFactureProduits(string numeroFacture)
        {
            var produits = new List<(string, int, decimal, decimal, int, DateTime)>();

            string query = @"
SELECT 
    fp.Reference_Produit,
    fp.QuantityProduit,
    fp.Montant_TVA,
    fp.Montant_TTC,
    fp.TVA,
    fp.Date_Delai
FROM D_Facture_Produits fp
WHERE fp.Numero_Facture = @NumeroFacture";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroFacture", numeroFacture);
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
                                (int)reader["TVA"],
                                (DateTime)reader["Date_Delai"]
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetFactureProduits error: " + ex.Message);
            }

            return produits;
        }

        public static string CreateFacture(string NumFacture,DateTime dateFacture, string numeroPatient, int etatPayement, int payementCheque,decimal montantTTC, string centrePayeur, List<(string Reference, int Quantity, decimal MontantTVA, decimal MontantTTC, int TVA, DateTime datedelai)> produits)
        {
            string insertfacturequery = @"
        INSERT INTO D_Facture
        (Numero_Facture, Date_Facture, Numero_Patient, etat_Payement,
         Payement_cheque, Montant_TTC, Centre_Payeur)
        VALUES
        (@Numero_Facture, @Date_Facture, @Numero_Patient, @etat_Payement,
         @Payement_cheque, @Montant_TTC, @Centre_Payeur)";

            string insertProduitQuery = @"
        INSERT INTO D_Facture_Produits
        (Numero_Facture, Reference_Produit, QuantityProduit, Montant_TVA, Montant_TTC, TVA,Date_Delai,est_Ajouter_Tache)
        VALUES
        (@Numero_Facture, @Reference_Produit, @QuantityProduit, @Montant_TVA, @Montant_TTC, @TVA,@date,0);";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (SqlCommand command = new SqlCommand(insertfacturequery, connection,transaction))
                    {
                        command.Parameters.Add("@Numero_Facture", SqlDbType.VarChar).Value = NumFacture;
                        command.Parameters.Add("@Date_Facture", SqlDbType.DateTime).Value = dateFacture;
                        command.Parameters.Add("@Numero_Patient", SqlDbType.VarChar).Value = numeroPatient;
                        command.Parameters.AddWithValue("@etat_Payement", etatPayement);
                        command.Parameters.Add("@Payement_cheque", SqlDbType.Bit).Value = payementCheque;
                        command.Parameters.Add("@Montant_TTC", SqlDbType.Decimal).Value = montantTTC;
                        command.Parameters.Add("@Centre_Payeur", SqlDbType.VarChar).Value = centrePayeur;

                         command.ExecuteNonQuery();
                    }
                    foreach (var p in produits)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertProduitQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Numero_Facture", NumFacture);
                            cmd.Parameters.AddWithValue("@Reference_Produit", p.Reference);
                            cmd.Parameters.AddWithValue("@QuantityProduit", p.Quantity);
                            cmd.Parameters.AddWithValue("@Montant_TVA", p.MontantTVA);
                            cmd.Parameters.AddWithValue("@Montant_TTC", p.MontantTTC);
                            cmd.Parameters.AddWithValue("@TVA", p.TVA);
                            cmd.Parameters.AddWithValue("@date", p.datedelai);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    return NumFacture;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database error: " + ex.Message);
                    return null;
                }
            }
        }

        public static DataTable GetAllFactures()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"
SELECT
    f.Numero_Facture,
    pr.Nom + ' ' + pr.Prenom AS Patient,
    pt.Numero_Patient,
    tel.Telephone,
    a.Numero_Assurance,
    c.Nom_Caisse,
    f.Centre_Payeur,
    prod.References_Produits,
    f.Montant_TTC,
    f.Date_Facture,
    f.etat_Payement,
    f.Payement_cheque
FROM D_Facture f
LEFT JOIN D_Patient pt ON f.Numero_Patient = pt.Numero_Patient
LEFT JOIN D_Person pr ON pt.Person_ID = pr.Person_ID
LEFT JOIN D_Assure a ON pt.Assure_ID = a.Assure_ID
LEFT JOIN R_Caisse c ON a.Caisse_ID = c.Caisse_ID

-- Aggregate telephones FIRST
LEFT JOIN (
    SELECT
        Person_ID,
        STRING_AGG(Telephone, ' / ') AS Telephone
    FROM D_Telephone
    GROUP BY Person_ID
) tel ON tel.Person_ID = pr.Person_ID

-- Aggregate products FIRST
LEFT JOIN (
    SELECT
        Numero_Facture,
        STRING_AGG(Reference_Produit, ' / ') AS References_Produits
    FROM D_Facture_Produits
    GROUP BY Numero_Facture
) prod ON prod.Numero_Facture = f.Numero_Facture; ";

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

            string query = @"    SELECT 
CAST('Facture' AS VARCHAR(20)) AS Document_Type,
      f.Numero_Facture AS Numéro,
	  STRING_AGG(fp.Reference_Produit, ' / ') AS References_Produits,
      f.Montant_TTC,
	  f.Centre_Payeur,  
      [Date_Facture] AS Date_Document
FROM D_Facture f
LEFT JOIN D_Facture_Produits fp 
ON f.Numero_Facture = fp.Numero_Facture
WHERE f.Numero_Patient = @Numero_Patient
GROUP BY 
    f.Numero_Facture,
    f.Date_Facture,
    f.Montant_TTC,
    f.Centre_Payeur;";

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

     
        public static bool UpdatePayement(string numero_facture, int value)
        {
            string query = @"
        UPDATE D_Facture
        SET etat_Payement = @Payement
        WHERE Numero_Facture = @NumeroFacture";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroFacture", numero_facture);
                    command.Parameters.AddWithValue("@Payement", value);

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

        public static bool UpdateChèque(string numero_facture, int value)
        {
            string query = @"
        UPDATE D_Facture
        SET Payement_cheque = @Payement
        WHERE Numero_Facture = @NumeroFacture";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroFacture", numero_facture);
                    command.Parameters.AddWithValue("@Payement", value);

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
        public static bool DeleteFacture(string numeroFacture)
        {
            string queryProduits = @"DELETE FROM D_Facture_Produits WHERE Numero_Facture = @NumeroFacture";
            string queryFacture = @"DELETE FROM D_Facture WHERE Numero_Facture = @NumeroFacture";
            string queryRecouvrement = @"DELETE FROM D_Recouvrement WHERE Numero_Facture = @NumeroFacture";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand cmd1 = new SqlCommand(queryProduits, connection, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@NumeroFacture", numeroFacture);
                        cmd1.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd3 = new SqlCommand(queryRecouvrement, connection, transaction))
                    {
                        cmd3.Parameters.AddWithValue("@NumeroFacture", numeroFacture);
                        cmd3.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd2 = new SqlCommand(queryFacture, connection, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@NumeroFacture", numeroFacture);
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

        public static DataTable GetAllFacturesForTaches()
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT *
                FROM D_Facture_Produits
                    WHERE ABS(DATEDIFF(DAY, @DateToday, Date_Delai)) < 10
                    AND est_Ajouter_Tache = 0;";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DateToday", DateTime.Today);
                connection.Open();
                dt.Load(command.ExecuteReader());
            }

            return dt;
        }

        public static bool UpdateTache_etat(string numero_facture ,string Referenceproduit)
        {
            string query = @"
                UPDATE D_Facture_Produits
                SET est_Ajouter_Tache = 1
                WHERE Numero_Facture = @NumeroFacture AND Reference_Produit = @ref";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NumeroFacture", numero_facture);
                command.Parameters.AddWithValue("@ref", Referenceproduit);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public static int GetFacturesCount()
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT count(*) as CNT FROM D_Facture";
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

        public static bool UpdateFacture(string numero, DateTime dateDevis, decimal montant, string centrePayeur,int etat,int check)
        {
            string query = @"
        UPDATE D_Facture
        SET 
            Date_Facture = @Date_Facture,
            Montant_TTC = @Montant_TTC,
            Centre_Payeur = @Centre_Payeur,
            etat_Payement = @etat,
            Payement_cheque = @check
            WHERE Numero_Facture = @Numero_Facture;";

            try
            {
                using var connection = new SqlConnection(DataAccessSettings.ConnectionString);
                using var command = new SqlCommand(query, connection);

                command.Parameters.Add("@Numero_Facture", SqlDbType.NVarChar, 50).Value = numero;
                command.Parameters.Add("@Date_Facture", SqlDbType.DateTime).Value = dateDevis;
                command.Parameters.Add("@Montant_TTC", SqlDbType.Decimal).Value = montant;
                command.Parameters.Add("@Centre_Payeur", SqlDbType.NVarChar, 50).Value = centrePayeur;
                command.Parameters.Add("@etat", SqlDbType.Int).Value = etat;
                command.Parameters.Add("@check", SqlDbType.Int).Value = check;
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }


        public static bool UpdateFacture_Produits(string facture, string oldReference, string reference, int quantity, decimal montantTva, decimal montantTtc, int tva)
        {
            string query = @"
        IF EXISTS (
            SELECT 1
            FROM D_Facture_Produits
            WHERE Numero_Facture = @Numero_Facture
              AND Reference_Produit = @OldReference
        )
        BEGIN
            UPDATE D_Facture_Produits
            SET
                Reference_Produit = @Reference,
                QuantityProduit = @Quantity,
                Montant_TVA = @Montant_TVA,
                Montant_TTC = @Montant_TTC,
                TVA = @TVA
            WHERE Numero_Facture = @Numero_Facture
              AND Reference_Produit = @OldReference;
        END
        ELSE
        BEGIN
        INSERT INTO D_Facture_Produits
        (Numero_Facture, Reference_Produit, QuantityProduit, Montant_TVA, Montant_TTC, TVA)
        VALUES
        (@Numero_Facture, @Reference, @Quantity, @Montant_TVA, @Montant_TTC, @TVA);
        END";

            try
            {
                using var connection = new SqlConnection(DataAccessSettings.ConnectionString);
                using var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Numero_Facture", facture);
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
