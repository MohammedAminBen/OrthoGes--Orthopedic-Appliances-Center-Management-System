using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_
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
        public static bool GetFactureByNumeroFacture(string numeroFacture, ref string Numeropatient, ref string referenceproduit, ref int etatpayement, ref DateTime date_facture,ref int payement_cheque,ref decimal Montant_tva,ref decimal Montant_ttc,ref int TVA,ref int qte,ref string centrepayeur)
        {
            bool isFound = false;
            string query = @"
            SELECT Numero_Patient, Reference_Produit, etat_Payement, Date_Facture, Payement_cheque, Montant_TVA, Montant_TTC, TVA, Quantity, Centre_Payeur
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
                        if (reader.Read())
                        {
                            isFound = true;
                            Numeropatient = reader["Numero_Patient"].ToString();
                            referenceproduit = reader["Reference_Produit"].ToString();
                            etatpayement = (int)reader["etat_Payement"];
                            date_facture = (DateTime)reader["Date_Facture"];
                            payement_cheque = (int)reader["Payement_cheque"];
                            Montant_tva = (decimal)reader["Montant_TVA"];
                            Montant_ttc = (decimal)reader["Montant_TTC"];
                            TVA = (int)reader["TVA"];
                            qte = (int)reader["Quantity"];
                            centrepayeur = reader["Centre_Payeur"].ToString();
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
        public static bool CreateFacture(DateTime dateFacture, string numeroPatient, string referenceProduit, int etatPayement, int payementCheque, int quantity, decimal montantTVA, decimal montantTTC, int tva, string centrePayeur,DateTime datedelai)
        {
            string numeroFacture = GenerateNumeroFacture();
            string query = @"
        INSERT INTO D_Facture
        (Numero_Facture, Date_Facture, Numero_Patient, Reference_Produit, etat_Payement,
         Payement_cheque, Quantity, Montant_TVA, Montant_TTC, TVA, Centre_Payeur,Date_Delai,est_Ajouter_Tache)
        VALUES
        (@Numero_Facture, @Date_Facture, @Numero_Patient, @Reference_Produit, @etat_Payement,
         @Payement_cheque, @Quantity, @Montant_TVA, @Montant_TTC, @TVA, @Centre_Payeur,@Date_Delai,0)";

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
                    command.Parameters.Add("@Date_Delai", SqlDbType.DateTime).Value = datedelai;

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

            string query = @"SELECT 
      f.Numero_Facture,
      pr.Nom + ' ' + pr.Prenom AS Patient,
      pt.Numero_Patient,
      STRING_AGG(t.Telephone, ' / ') AS Telephone,
      a.Numero_Assurance,
      c.Nom_Caisse,
      f.Centre_Payeur,
      f.Reference_Produit,
      p.Nom_Produit,
      p.Prix,
      f.Quantity,
      f.TVA,
      f.Montant_TVA,
      f.Montant_TTC,
      f.Date_Facture,
      f.etat_Payement,
      f.Payement_cheque
FROM D_Facture f
INNER JOIN R_Produit p ON f.Reference_Produit = p.Reference 
LEFT JOIN D_Patient pt ON f.Numero_Patient = pt.Numero_Patient
LEFT JOIN D_Person pr ON pt.Person_ID = pr.Person_ID
LEFT JOIN D_Assure a ON pt.Assure_ID = a.Assure_ID
LEFT JOIN R_Caisse c ON a.Caisse_ID = c.Caisse_ID
LEFT JOIN D_Telephone t ON t.Person_ID = pr.Person_ID
GROUP BY
      f.Numero_Facture,
      pr.Nom,
      pr.Prenom,
      pt.Numero_Patient,
      a.Numero_Assurance,
      c.Nom_Caisse,
      f.Centre_Payeur,
      f.Reference_Produit,
      p.Nom_Produit,
      p.Prix,
      f.Quantity,
      f.TVA,
      f.Montant_TVA,
      f.Montant_TTC,
      f.Date_Facture,
      f.etat_Payement,
      f.Payement_cheque;";

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
            int rowsAffected = 0;
            string query = @"Delete from D_Facture WHERE Numero_Facture = @NumeroFacture";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroFacture", numeroFacture);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }

            return rowsAffected > 0;
        }
        public static DataTable GetAllFacturesForTaches()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @" SELECT *
                              FROM D_Facture 
                              WHERE ABS(DATEDIFF(DAY, @DateToday, Date_Delai)) < 10 AND est_Ajouter_Tache = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DateToday", DateTime.Today);

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
                Console.WriteLine("Error Facture :" + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static bool UpdateTache_etat(string numero_facture)
        {
            string query = @"
        UPDATE D_Facture
        SET est_Ajouter_Tache = 1
        WHERE Numero_Facture = @NumeroFacture";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroFacture", numero_facture);
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
    }
}
