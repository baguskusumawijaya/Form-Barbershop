using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bokingbarbershop
{
    internal class DatabaseConnection
    {
        private string connectionString = @"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=FormDataDB;TrustServerCertificate=True;Integrated Security=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
