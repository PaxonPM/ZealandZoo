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
            string queryStr = $"INSERT INTO Users (id, name, telefon , email, role_id, is_newsletter_member) " +
                $"OUTPUT INSERTED.id, INSERTED.name " +
                $"VALUES (@id, @name, @telefon, @email, @role_id, @is_newsletter_member)";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@telefon", entity.Telefon);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("role_id", entity.Role);
            cmd.Parameters.AddWithValue("@is_newsletter_member", entity.IsNotificationActive);

            connection.Open();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                entity.Id = reader.GetInt32(0);

            }

            return entity;
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
                Role = reader.GetString(reader.GetOrdinal("role_id")),
                IsNotificationActive = reader.GetBoolean(reader.GetOrdinal("is_newsletter_active")),

            };



        }

        public User Create(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
