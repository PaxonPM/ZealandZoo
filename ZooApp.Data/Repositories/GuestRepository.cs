using Microsoft.Data.SqlClient;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DbConnectionHelper _connection;

        public GuestRepository(DbConnectionHelper connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Retrieves a guest from the database by email address.
        /// Only users with role_id = 3 (Guest) are considered.
        /// </summary>
        public GuestModel? GetByEmail(string email)
        {
            string queryStr = @"SELECT id, name, email, pw_hash 
                                FROM Users 
                                WHERE email = @email AND role_id = 3";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@email", email);

            connection.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new GuestModel
                {
                    UserId   = reader.GetInt32(reader.GetOrdinal("id")),
                    UserName = reader.GetString(reader.GetOrdinal("name")),
                    Email    = reader.GetString(reader.GetOrdinal("email")),
                    Password = reader.GetString(reader.GetOrdinal("pw_hash"))
                };
            }

            return null;
        }

        /// <summary>
        /// Inserts a new guest into the Users table with role_id = 3.
        /// </summary>
        public GuestModel Create(GuestModel guest)
        {
            string queryStr = @"INSERT INTO Users (name, email, telefon, pw_hash, role_id, is_newsletter_member) 
                                OUTPUT INSERTED.id 
                                VALUES (@name, @email, @telefon, @pw_hash, 3, @is_newsletter_member)";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@name",    guest.UserName);
            cmd.Parameters.AddWithValue("@email",   guest.Email);
            cmd.Parameters.AddWithValue("@telefon", guest.PhoneNumber);
            cmd.Parameters.AddWithValue("@pw_hash", guest.Password);
            cmd.Parameters.AddWithValue("@is_newsletter_member", guest.IsNewsletterMember);


            connection.Open();

            guest.UserId = (int)cmd.ExecuteScalar();
            return guest;
        }
    }
}