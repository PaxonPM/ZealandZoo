using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionHelper _connection;

        public UserRepository(DbConnectionHelper connection)
        {
            _connection = connection;
        }

        public User CreateUser(User entity)
        {
            string queryStr = $"INSERT INTO Users (name, telefon , email, pw_hash, role_id, is_newsletter_member) " +
                $"OUTPUT INSERTED.id, INSERTED.name " +
                $"VALUES (@name, @telefon, @email, @pw_hash, 2, 0)";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@telefon", entity.Telefon);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@pw_hash", entity.PwHash);

            connection.Open();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                entity.Id = reader.GetInt32(0);

            }

            return entity;
        }
        public User GetByEmail(string email)
        {
            string queryStr = @"SELECT id, name, email, pw_hash 
                                FROM Users 
                                WHERE email = @email AND role_id = 2";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@email", email);

            connection.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Email = reader.GetString(reader.GetOrdinal("email")),
                    PwHash = reader.GetString(reader.GetOrdinal("pw_hash"))
                };
            }

            return null;
        }
        public User GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            }

            string queryStr = @"SELECT id, name, email, telefon, pw_hash, role_id, is_newsletter_member
                       FROM Users
                       WHERE name = @name";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@name", name);

            connection.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return MapReaderToUser(reader);
            }

            return null;
        }
        public User GetById(int id)
        {
            // Validate input parameter
            if (id <= 0)
            {
                throw new ArgumentException("User ID must be greater than 0.", nameof(id));
            }

            string queryStr = @"SELECT id, name, email, email, telefon, pw_hash, role_id, is_newsletter_member
                               FROM Users 
                               WHERE id = @id";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();

            using var reader = cmd.ExecuteReader();

            // If event is found, map the data to an Event object
            if (reader.Read())
            {
                return MapReaderToUser(reader);
            }

            // Return null if no event found with the given ID
            return null;
        }
        public IEnumerable<User> GetAll()
        {
            string queryStr = @"SELECT id, name, email, telefon, pw_hash, role_id, is_newsletter_member
                               FROM Users
                               ORDER BY id DESC";

            var users = new List<User>();

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);

            connection.Open();

            using var reader = cmd.ExecuteReader();

            // Read all events and add them to the list
            while (reader.Read())
            {
                users.Add(MapReaderToUser(reader));
            }

            return users;
        }
        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        private User MapReaderToUser(SqlDataReader reader)
        {
            return new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Email = reader.GetString(reader.GetOrdinal("email")),
                Telefon = reader.GetString(reader.GetOrdinal("telefon")),
                PwHash = reader.GetString(reader.GetOrdinal("pw_hash")),
                Role = reader.GetInt32(reader.GetOrdinal("role_id")).ToString(),
                IsNotificationActive = reader.GetBoolean(reader.GetOrdinal("is_newsletter_member")),

            };



        }

        public User Create(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
