using Microsoft.Data.SqlClient;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DbConnectionHelper _connection;

        public AdminRepository(DbConnectionHelper connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Retrieves an admin user from the database by username.
        /// Only users with role_id = 1 (Admin) are considered.
        /// </summary>
        public Admin? GetByUsername(string username)
        {
            string queryStr = @"SELECT id, name, pw_hash 
                                FROM Users 
                                WHERE name = @username AND role_id = 1";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@username", username);

            connection.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Admin
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Username = reader.GetString(reader.GetOrdinal("name")),
                    Password = reader.GetString(reader.GetOrdinal("pw_hash"))
                };
            }

            return null;
        }
    }
}
