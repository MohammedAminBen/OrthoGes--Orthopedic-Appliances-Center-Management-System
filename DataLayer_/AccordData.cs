using DataLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_
{
    public class AccordData
    {
        public static int CreateAccord(
      string numeroPatient,
      DateTime dateAccord,
      string etatAccord,
      int delaiAccord,
      List<(string Reference, string Description, int Quantity)> produits)
        {
            string insertAccordQuery = @"
        INSERT INTO D_Accord
        (Numero_Patient, Date_Accord, etat_Accord, Delai_Accord, est_Ajouter_Tache)
        OUTPUT INSERTED.Accord_ID
        VALUES
        (@Numero_Patient, @Date_Accord, @etat_Accord, @Delai_Accord, 0);";

            string insertProduitQuery = @"
        INSERT INTO D_Accord_Produits
        (Accord_ID, Reference_Produit, Description_Produit, Quantity)
        VALUES
        (@Accord_ID, @Reference_Produit, @Description_Produit, @Quantity);";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    int accordID;

                    // 🔹 Insert Accord header
                    using (SqlCommand cmd = new SqlCommand(insertAccordQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Numero_Patient", numeroPatient);
                        cmd.Parameters.AddWithValue("@Date_Accord", dateAccord);
                        cmd.Parameters.AddWithValue("@etat_Accord", etatAccord);
                        cmd.Parameters.AddWithValue("@Delai_Accord", delaiAccord);

                        accordID = (int)cmd.ExecuteScalar();
                    }

                    // 🔹 Insert Accord products
                    foreach (var p in produits)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertProduitQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Accord_ID", accordID);
                            cmd.Parameters.AddWithValue("@Reference_Produit", p.Reference);
                            cmd.Parameters.AddWithValue("@Description_Produit", p.Description);
                            cmd.Parameters.AddWithValue("@Quantity", p.Quantity);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return accordID;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("CreateAccord error: " + ex.Message);
                    return -1;
                }
            }
        }

        // =========================
        // GET ACCORD BY ID
        // =========================
        public static bool GetAccordData(int accordID, ref string numeroPatient, ref DateTime dateAccord, ref string etatAccord, ref int delaiAccord)
        {
            dateAccord = DateTime.MinValue;
            delaiAccord = 0;

            string query = @"
        SELECT 
            Numero_Patient,
            Date_Accord,
            etat_Accord,
            Delai_Accord
        FROM D_Accord
        WHERE Accord_ID = @Accord_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Accord_ID", accordID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        numeroPatient = reader["Numero_Patient"].ToString();
                        dateAccord = (DateTime)reader["Date_Accord"];
                        etatAccord = reader["etat_Accord"].ToString();
                        delaiAccord = (int)reader["Delai_Accord"];

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAccordData error: " + ex.Message);
                return false;
            }
        }

        public static List<(string Reference, string Description, int Quantity)>
        GetAccordProduits(int accordID)
        {
            var produits = new List<(string, string, int)>();

            string query = @"
        SELECT 
            Reference_Produit,
            Description_Produit,
            Quantity
        FROM D_Accord_Produits
        WHERE Accord_ID = @Accord_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Accord_ID", accordID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produits.Add((
                                reader["Reference_Produit"].ToString(),
                                reader["Description_Produit"]?.ToString(),
                                (int)reader["Quantity"]
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAccordProduits error: " + ex.Message);
            }

            return produits;
        }


        // =========================
        // GET ALL ACCORDS
        // =========================
        public static DataTable GetAllAccords()
        {
            DataTable dt = new DataTable();

            string query = @"
SELECT 
    a.Accord_ID,
    pt.Numero_Patient,
    pr.Nom + ' ' + pr.Prenom AS Patient,
    tel.Telephone,
    ass.Numero_Assurance,
    c.Nom_Caisse,
    prod.References_Produits,
    prod.Description_Produit,
    prod.Quantity,
    a.Date_Accord,
    a.etat_Accord
FROM D_Accord a
INNER JOIN D_Patient pt ON a.Numero_Patient = pt.Numero_Patient
LEFT JOIN D_Person pr ON pt.Person_ID = pr.Person_ID
LEFT JOIN D_Assure ass ON pt.Assure_ID = ass.Assure_ID
LEFT JOIN R_Caisse c ON ass.Caisse_ID = c.Caisse_ID

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
        Accord_ID,
        STRING_AGG(Reference_Produit, ' / ') AS References_Produits,
        STRING_AGG(Description_Produit, ' / ') AS Description_Produit,
        STRING_AGG(CAST(Quantity AS NVARCHAR(10)), ' / ') AS Quantity
    FROM D_Accord_Produits
    GROUP BY Accord_ID
) prod ON prod.Accord_ID = a.Accord_ID;

";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dt;
        }

        // =========================
        // GET ACCORDS BY PATIENT
        // =========================
        public static DataTable GetAccordsByPatient(string numeroPatient)
        {
            DataTable dt = new DataTable();

            string query = @"
       SELECT 
    a.Accord_ID,
    STRING_AGG(ap.Reference_Produit, ' / ') AS References_Produits,
	STRING_AGG(ap.Description_Produit,' / ') AS Description_Produit,
	STRING_AGG(ap.Quantity,' / ') AS Quantity,
    a.Date_Accord,
    a.etat_Accord
FROM D_Accord a
LEFT JOIN D_Accord_Produits ap ON a.Accord_ID = ap.Accord_ID WHERE a.Numero_Patient = @Numero_Patient
GROUP BY a.Accord_ID, a.Numero_Patient, a.Date_Accord, a.etat_Accord;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Numero_Patient", SqlDbType.VarChar).Value = numeroPatient;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dt;
        }

        // =========================
        // UPDATE ETAT ACCORD
        // =========================
        public static bool UpdateEtatAccord(int accordID, string value)
        {
            string query = @"
        UPDATE D_Accord
        SET etat_Accord = @Etat
        WHERE Accord_ID = @Accord_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Accord_ID", SqlDbType.Int).Value = accordID;
                    command.Parameters.Add("@Etat", SqlDbType.VarChar).Value = value;

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

        // =========================
        // DELETE ACCORD
        // =========================
        public static bool DeleteAccord(int accordID)
        {
            string queryProduits = @"DELETE FROM D_Accord_Produits WHERE Accord_ID = @Accord_ID";
            string queryDevis = @"DELETE FROM D_Accord WHERE Accord_ID = @Accord_ID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand cmd1 = new SqlCommand(queryProduits, connection, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@Accord_ID", accordID);
                        cmd1.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd2 = new SqlCommand(queryDevis, connection, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@Accord_ID", accordID);
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
        public static DataTable GetAllAccordForTaches()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @" SELECT *
                              FROM D_Accord 
                              WHERE etat_Accord = 'Prêt' AND est_Ajouter_Tache = 0;";

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
        public static bool UpdateTache_etat(int Accord, int etat)
        {
            string query = @"
        UPDATE D_Accord
        SET est_Ajouter_Tache = @Etat
        WHERE Accord_ID = @NumeroAccord";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroAccord", Accord);
                    command.Parameters.AddWithValue("@Etat", etat);
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
        public static int GetAccordsCount()
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT count(*) as CNT FROM D_Accord";
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
        public static bool UpdateAccord(int accord, DateTime dateAccord, string etatAccord, int delaiAccord)
        {
            string query = @"
        UPDATE D_Accord
        SET
            Date_Accord = @Date_Accord,
            etat_Accord = @Etat_Accord,
            Delai_Accord = @Delai_Accord
        WHERE Accord_ID = @Accord_ID;";

            try
            {
                using var connection = new SqlConnection(DataAccessSettings.ConnectionString);
                using var command = new SqlCommand(query, connection);

                command.Parameters.Add("@Accord_ID", SqlDbType.Int).Value = accord;
                command.Parameters.Add("@Date_Accord", SqlDbType.DateTime).Value = dateAccord;
                command.Parameters.Add("@Etat_Accord", SqlDbType.NVarChar, 50).Value = etatAccord;
                command.Parameters.Add("@Delai_Accord", SqlDbType.Int).Value = delaiAccord;

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public static bool UpdateAccord_Produits(int accord, string oldReference, string reference, string description, int quantity)
        {
            string query = @"
        IF EXISTS (
            SELECT 1
            FROM D_Accord_Produits
            WHERE Accord_ID = @Accord_ID
              AND Reference_Produit = @OldReference
        )
        BEGIN
            UPDATE D_Accord_Produits
            SET
                Reference_Produit = @Reference,
                Description_Produit = @Description,
                Quantity = @Quantity
            WHERE Accord_ID = @Accord_ID
              AND Reference_Produit = @OldReference;
        END
        ELSE
        BEGIN
            INSERT INTO D_Accord_Produits
            (
                Accord_ID,
                Reference_Produit,
                Description_Produit,
                Quantity
            )
            VALUES
            (
                @Accord_ID,
                @Reference,
                @Description,
                @Quantity
            );
        END";

            try
            {
                using var connection = new SqlConnection(DataAccessSettings.ConnectionString);
                using var command = new SqlCommand(query, connection);

                command.Parameters.Add("@Accord_ID", SqlDbType.Int).Value = accord;
                command.Parameters.Add("@OldReference", SqlDbType.NVarChar, 50).Value = oldReference;
                command.Parameters.Add("@Reference", SqlDbType.NVarChar, 50).Value = reference;
                command.Parameters.Add("@Description", SqlDbType.NVarChar, 255).Value = description;
                command.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

    }
}
