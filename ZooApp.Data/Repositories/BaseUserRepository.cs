using Microsoft.Data.SqlClient;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Repositories
{
    public abstract class BaseUserRepository : IUserRepository
    {
        protected readonly IDbConnectionHelper _connection;

        protected abstract int RoleId { get; }

        protected BaseUserRepository(IDbConnectionHelper connection)
        {
            _connection = connection;
        }
        /// <summary>
        /// Method to retrieve a user by their ID, ensuring that the user belongs to the specific role defined by RoleId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public UserModel? GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("User ID must be greater than 0.", nameof(id));

            const string queryStr = @"SELECT id, name, email, telefon, pw_hash, role_id, is_newsletter_member
                                      FROM Users 
                                      WHERE id = @id AND role_id = @roleId";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@roleId", RoleId);
            connection.Open();

            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapReaderToUser(reader) : null;
        }
        /// <summary>
        /// Method to retrieve all users that belong to the specific role defined by RoleId, ordered by their ID in descending order.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserModel> GetAll()
        {
            const string queryStr = @"SELECT id, name, email, telefon, pw_hash, role_id, is_newsletter_member
                                      FROM Users
                                      WHERE role_id = @roleId
                                      ORDER BY id DESC";

            var users = new List<UserModel>();

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@roleId", RoleId);
            connection.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                users.Add(MapReaderToUser(reader));

            return users;
        }
        /// <summary>
        /// Method to retrieve a user by their email, ensuring that the user belongs to the specific role defined by RoleId. This is particularly useful for authentication purposes, where users are often identified by their email addresses. 
        /// The method checks for a matching email and role ID in the database and returns the corresponding user if found. 
        /// If no matching user is found, it returns null.
        /// </summary>
        /// <param name="email">The email of the user to retrieve.</param>
        /// <returns>The UserModel object if found; otherwise, null.</returns>
        public UserModel? GetByEmail(string email)
        {
            const string queryStr = @"SELECT id, name, email, telefon, pw_hash, role_id, is_newsletter_member
                                      FROM Users 
                                      WHERE email = @email AND role_id = @roleId";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@roleId", RoleId);
            connection.Open();

            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapReaderToUser(reader) : null;
        }
        /// <summary>
        /// Gets a user by their name, ensuring that the user belongs to the specific role defined by RoleId. 
        /// This method is useful for scenarios where users may be identified by their names, such as in administrative interfaces or when displaying user information.
        /// </summary>
        /// <param name="name">The name of the user to retrieve.</param>
        /// <returns>The UserModel object if found; otherwise, null.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided name is null, empty, or consists only of white-space characters.</exception>
        protected UserModel? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            const string queryStr = @"SELECT id, name, email, telefon, pw_hash, role_id, is_newsletter_member
                                      FROM Users
                                      WHERE name = @name AND role_id = @roleId";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@roleId", RoleId);
            connection.Open();

            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapReaderToUser(reader) : null;
        }
        /// <summary>
        /// Method to create a new user in the database. 
        /// It takes a UserModel object as input
        /// </summary>
        /// <param name="entity">The UserModel object containing the user's details.</param>
        /// <returns>The created UserModel object with the assigned ID.</returns>
        public virtual UserModel Create(UserModel entity)
        {
            const string queryStr = @"INSERT INTO Users (name, email, telefon, pw_hash, role_id, is_newsletter_member)
                                  OUTPUT INSERTED.id
                                  VALUES (@name, @email, @telefon, @pw_hash, @roleId, @is_newsletter_member)";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@telefon", entity.Telefon);
            cmd.Parameters.AddWithValue("@pw_hash", entity.PwHash);
            cmd.Parameters.AddWithValue("@roleId", RoleId);
            cmd.Parameters.AddWithValue("@is_newsletter_member", entity.IsNotificationActive);
            connection.Open();

            entity.Id = (int)cmd.ExecuteScalar();
            return entity;
        }

        public virtual UserModel Update(UserModel entity) => throw new NotImplementedException();
        public virtual UserModel Delete(int id) => throw new NotImplementedException();

        protected UserModel MapReaderToUser(SqlDataReader reader)
        {
            return new UserModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString(reader.GetOrdinal("email")),
                Telefon = reader.IsDBNull(reader.GetOrdinal("telefon")) ? "" : reader.GetString(reader.GetOrdinal("telefon")),
                PwHash = reader.GetString(reader.GetOrdinal("pw_hash")),
                RoleId = reader.GetInt32(reader.GetOrdinal("role_id")),
                IsNotificationActive = reader.GetBoolean(reader.GetOrdinal("is_newsletter_member"))
            };
        }
    }
}