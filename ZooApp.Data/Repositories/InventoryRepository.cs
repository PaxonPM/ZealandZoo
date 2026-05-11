using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZoo.Models;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;
namespace ZealandZoo.Repositories

{
    public class InventoryRepository : IInventoryRepository
    {
        //private readonly string _connectionString;
        private readonly DbConnectionHelper _connection;

        public InventoryRepository(DbConnectionHelper connection) //IConfiguration configuration)
        {
            _connection = connection; //_connectionString = configuration.GetConnectionString("ZealandZoo");
        }

        public bool ExistsByName(string name)
        {
            //using SqlConnection connection = new SqlConnection(_connectionString);
            using var connection = _connection.CreateConnection();
            connection.Open();

            string sql = "SELECT COUNT(*) FROM InventoryItems WHERE Name = @Name";
            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", name);

            return (int)command.ExecuteScalar() > 0;
        }

        public void CreateItem(InventoryItem item)
        {
            //using SqlConnection connection = new SqlConnection(_connectionString);
            using var connection = _connection.CreateConnection();
            connection.Open();

            string sql = "INSERT INTO InventoryItems (category_id, Name, quantity) " +
                         "VALUES (@CategoryId, @Name, @Quantity)";

            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CategoryId", item.CategoryId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Quantity", item.Quantity);

            command.ExecuteNonQuery();
        }

        public List<ItemCategory> GetAllCategories()
        {
            List<ItemCategory> categories = new List<ItemCategory>();

            //using SqlConnection connection = new SqlConnection(_connectionString);
            using var connection = _connection.CreateConnection();
            connection.Open();

            string sql = "SELECT id, Name FROM ItemCategories";
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                categories.Add(new ItemCategory
                {
                    Id = (int)reader["id"],
                    Name = (string)reader["Name"]
                });
            }

            return categories;
        }
    }
}