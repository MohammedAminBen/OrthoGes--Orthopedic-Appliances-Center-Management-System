using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_
{
    public class FinancementData
    {
        public static decimal GetRevenuTotalMensuelle()
        {
            decimal somme = 0;

            DateTime dateDebut = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime dateFin = dateDebut.AddMonths(1).AddDays(-1);

            string query = @"
        SELECT ISNULL(SUM(Montant_TTC), 0)
        FROM D_Recouvrement
        WHERE Date_Facture BETWEEN @DateDebut AND @DateFin";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DateDebut", dateDebut);
                command.Parameters.AddWithValue("@DateFin", dateFin);

                try
                {
                    connection.Open();
                    somme = Convert.ToDecimal(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GetRevenuTotalMensuelle error: " + ex.Message);
                }
            }

            return somme;
        }
        public static decimal GetRevouvrementReelMensuelle()
        {
            decimal somme = 0;

            DateTime dateDebut = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime dateFin = dateDebut.AddMonths(1).AddDays(-1);

            string query = @"
        SELECT ISNULL(SUM(Montant_TTC), 0)
        FROM D_Recouvrement
        WHERE etat_Payement = 'OUI' AND Date_Facture BETWEEN @DateDebut AND @DateFin";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DateDebut", dateDebut);
                command.Parameters.AddWithValue("@DateFin", dateFin);

                try
                {
                    connection.Open();
                    somme = Convert.ToDecimal(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GetRevenuTotalMensuelle error: " + ex.Message);
                }
            }

            return somme;
        }
        public static decimal GetResterImpayeeMensuelle()
        {
            decimal somme = 0;

            DateTime dateDebut = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime dateFin = dateDebut.AddMonths(1).AddDays(-1);

            string query = @"
        SELECT ISNULL(SUM(Montant_TTC), 0)
        FROM D_Recouvrement
        WHERE etat_Payement = 'NON' AND Date_Facture BETWEEN @DateDebut AND @DateFin";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DateDebut", dateDebut);
                command.Parameters.AddWithValue("@DateFin", dateFin);

                try
                {
                    connection.Open();
                    somme = Convert.ToDecimal(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GetRevenuTotalMensuelle error: " + ex.Message);
                }
            }

            return somme;
        }

        public static DataTable GetRecouvrementHistorique()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            DateTime dateDebut = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime dateFin = dateDebut.AddMonths(1).AddDays(-1);
            string query = @"SET LANGUAGE French
                SELECT 
                  DATENAME(MONTH, Date_Facture) AS Mois,
                  ISNULL(SUM(Montant_TTC), 0) AS Somme
				  From D_Recouvrement 
				  GROUP BY 
    YEAR(Date_Facture),
    MONTH(Date_Facture),
    DATENAME(MONTH, Date_Facture)
ORDER BY 
    YEAR(Date_Facture),
    MONTH(Date_Facture);";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@DateDebut", dateDebut);
                command.Parameters.AddWithValue("@DateFin", dateFin);
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
                Console.WriteLine("Error " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }

        public static DataTable GetRecouvrementReelHistorique()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            DateTime dateDebut = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime dateFin = dateDebut.AddMonths(1).AddDays(-1);
            string query = @"SET LANGUAGE French
                SELECT 
                  DATENAME(MONTH, Date_Facture) AS Mois,
                  ISNULL(SUM(Montant_TTC), 0) AS Somme
				  From D_Recouvrement  WHERE etat_Payement = 'OUI'
				  GROUP BY 
    YEAR(Date_Facture),
    MONTH(Date_Facture),
    DATENAME(MONTH, Date_Facture)
ORDER BY 
    YEAR(Date_Facture),
    MONTH(Date_Facture);";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@DateDebut", dateDebut);
                command.Parameters.AddWithValue("@DateFin", dateFin);
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
                Console.WriteLine("Error " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }
        public static DataTable GetResterImpayerHistorique()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            DateTime dateDebut = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime dateFin = dateDebut.AddMonths(1).AddDays(-1);
            string query = @"SET LANGUAGE French
                SELECT 
                  ISNULL(DATENAME(MONTH, Date_Facture), '') AS Mois,
                  ISNULL(SUM(Montant_TTC), 0) AS Somme
				  From D_Recouvrement WHERE etat_Payement = 'NON'
				 GROUP BY 
    YEAR(Date_Facture),
    MONTH(Date_Facture),
    DATENAME(MONTH, Date_Facture)
ORDER BY 
    YEAR(Date_Facture),
    MONTH(Date_Facture);";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@DateDebut", dateDebut);
                command.Parameters.AddWithValue("@DateFin", dateFin);
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
                Console.WriteLine("Error " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }
        public static decimal GetRevenuMensuel(int year, int month)
        {
            DateTime dateDebut = new DateTime(year, month, 1);
            DateTime dateFin = dateDebut.AddMonths(1).AddDays(-1);

            string query = @"
        SELECT ISNULL(SUM(Montant_TTC), 0)
        FROM D_Recouvrement
        WHERE Date_Facture BETWEEN @DateDebut AND @DateFin";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DateDebut", dateDebut);
                command.Parameters.AddWithValue("@DateFin", dateFin);

                connection.Open();
                return Convert.ToDecimal(command.ExecuteScalar());
            }
        }


    }
}
