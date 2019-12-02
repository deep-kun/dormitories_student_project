using System.Data;
using System.Data.SqlClient;

namespace Dormitories.Authentication
{
    public class DBAccess
    {
        private static string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Dormitory;Integrated Security=True";

        public static IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}