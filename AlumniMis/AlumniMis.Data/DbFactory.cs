using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace AlumniMis.Data
{
    public static class DbFactory
    {
        public static IDbConnection GetNewConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["alumnimis"];
            return new MySqlConnection(connectionString.ConnectionString);
        }
    }
}