using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ZooApp.Data.Db
{
    /// <summary>
    /// Helper class for creating and managing database connections.
    /// </summary>
    public class DbConnectionHelper : IDbConnectionHelper
    {
        private readonly string _connectionString;

        public DbConnectionHelper()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost,1433",
                InitialCatalog = "dev_ZealandZoo_0_8",
                TrustServerCertificate = true,
                IntegratedSecurity = false,  // Windows Auth virker ikke med Docker
                UserID = "sa",
                Password = "Frederik123!"
            };
            _connectionString = builder.ConnectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
