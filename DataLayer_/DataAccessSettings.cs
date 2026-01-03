using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer_
{
    public class DataAccessSettings
    {
        public static string ConnectionString =
            "Server=.;Database=OrthoGesDB;User Id=sa;Password=SA123456;TrustServerCertificate=True;";
        //public static string ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;
        //AttachDbFilename={AppDomain.CurrentDomain.BaseDirectory}SMSDB.mdf;
        //Integrated Security = True;
        //Connect Timeout=30";
    }
}
