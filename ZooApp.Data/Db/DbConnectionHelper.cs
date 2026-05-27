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
                DataSource = @"PAX-LAPTOP\SQLEXPRESS", 
                InitialCatalog = "dev_ZealandZoo_0_8",
                TrustServerCertificate = true,
                IntegratedSecurity = true // For Windows Auth
            };
            _connectionString = builder.ConnectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
