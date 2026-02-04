using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_
{
    public class RecouvrementData
    {
        // =========================
        // CREATE RECOUVREMENT
        // =========================
        public static int CreateRecouvrement(string numeroFacture, DateTime dateFacture, string numeroPatient, string etatPayement, string payementCheque, string centrePayeur,decimal montantttc)
        {
            string query = @"
INSERT INTO D_Recouvrement
(Date_Facture, Numero_Facture, Numero_Patient, etat_Payement, Payement_cheque, Centre_Payeur,Montant_TTC)
OUTPUT INSERTED.Recouvrement_ID
VALUES
(@Date_Facture, @Numero_Facture, @Numero_Patient, @etat_Payement, @Payement_cheque, @Centre_Payeur,@Montant);";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date_Facture", dateFacture);
                    command.Parameters.AddWithValue("@Numero_Facture", numeroFacture);
                    command.Parameters.AddWithValue("@Numero_Patient", numeroPatient);
                    command.Parameters.AddWithValue("@etat_Payement", etatPayement);
                    command.Parameters.AddWithValue("@Payement_cheque", payementCheque);
                    command.Parameters.AddWithValue("@Centre_Payeur", centrePayeur);
                    command.Parameters.AddWithValue("@Montant", montantttc);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateRecouvrement error: " + ex.Message);
                return -1;
            }
        }

        // =========================
        // GET RECOUVREMENT BY ID
        // =========================
        public static bool GetRecouvrementByID(int recouvrementID, ref DateTime dateFacture, ref string numeroFacture, ref string numeroPatient, ref string etatPayement, ref string payementCheque, ref string centrePayeur,ref decimal montantttc)
        {
            dateFacture = DateTime.MinValue;
            numeroFacture = numeroPatient = etatPayement = payementCheque = centrePayeur = string.Empty;

            string query = @"
SELECT 
    Date_Facture,
    Numero_Facture,
    Numero_Patient,
    etat_Payement,
    Payement_cheque,
    Centre_Payeur,
    Montant_TTC
FROM D_Recouvrement
WHERE Recouvrement_ID = @ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", recouvrementID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        dateFacture = (DateTime)reader["Date_Facture"];
                        numeroFacture = reader["Numero_Facture"].ToString();
                        numeroPatient = reader["Numero_Patient"].ToString();
                        etatPayement = reader["etat_Payement"].ToString();
                        payementCheque = reader["Payement_cheque"].ToString();
                        centrePayeur = reader["Centre_Payeur"].ToString();
                        montantttc = (decimal)reader["Montant_TTC"];

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetRecouvrementByID error: " + ex.Message);
                return false;
            }
        }

        // =========================
        // GET ALL RECOUVREMENTS
        // =========================
        public static DataTable GetAllRecouvrements()
        {
            DataTable dt = new DataTable();

            string query = @"
SELECT
    r.Numero_Facture,
    r.Date_Facture,
    pr.Nom + ' ' + pr.Prenom AS Patient,
    r.Numero_Patient,
    tel.Telephone,
    a.Numero_Assurance,
    c.Nom_Caisse,
    r.Centre_Payeur,
    prod.References_Produits,
    r.Montant_TTC,
    r.etat_Payement,
    r.Payement_cheque
FROM D_Recouvrement r
LEFT JOIN D_Patient pt ON r.Numero_Patient = pt.Numero_Patient
LEFT JOIN D_Person pr ON pt.Person_ID = pr.Person_ID
LEFT JOIN D_Assure a ON pt.Assure_ID = a.Assure_ID
LEFT JOIN R_Caisse c ON a.Caisse_ID = c.Caisse_ID
LEFT JOIN D_Facture f ON r.Numero_Facture = f.Numero_Facture

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
) prod ON prod.Numero_Facture = f.Numero_Facture;
";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    dt.Load(command.ExecuteReader());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAllRecouvrements error: " + ex.Message);
            }

            return dt;
        }

        // =========================
        // UPDATE PAYMENT STATE
        // =========================
        public static bool UpdateEtatPayement(string NumeroFacture, string value)
        {
            string query = @"
            UPDATE D_Recouvrement
            SET etat_Payement = @Etat
            WHERE Numero_Facture = @ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Etat", value);
                    command.Parameters.AddWithValue("@ID", NumeroFacture);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateEtatPayement error: " + ex.Message);
                return false;
            }
        }

        public static bool UpdatePayementCheque(string NumeroFacture, string value)
        {
            string query = @"
            UPDATE D_Recouvrement
            SET Payement_cheque = @Cheque
            WHERE Numero_Facture = @ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cheque", value);
                    command.Parameters.AddWithValue("@ID", NumeroFacture);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateEtatPayement error: " + ex.Message);
                return false;
            }
        }

        // =========================
        // DELETE RECOUVREMENT
        // =========================
        public static bool DeleteRecouvrement(int recouvrementID)
        {
            string query = @"DELETE FROM D_Recouvrement WHERE Recouvrement_ID = @ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", recouvrementID);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteRecouvrement error: " + ex.Message);
                return false;
            }
        }
    }

}
