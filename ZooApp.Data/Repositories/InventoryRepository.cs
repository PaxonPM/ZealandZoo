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
        private readonly IDbConnectionHelper _connection;

        public InventoryRepository(IDbConnectionHelper connection) //IConfiguration configuration)
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

        public List<InventoryItem> GetAllItems()
        {
            var items = new List<InventoryItem>();

            using var connection = _connection.CreateConnection();
            connection.Open();

            string sql = "SELECT id, category_id, Name, quantity FROM InventoryItems";
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(new InventoryItem(
                    (int)reader["id"],
                    (int)reader["category_id"],
                    (string)reader["Name"],
                    (int)reader["quantity"]
                ));
            }

            return items;
        }

        public void UpdateItem(InventoryItem item)
        {
            using var connection = _connection.CreateConnection();
            connection.Open();

            string sql = "UPDATE InventoryItems SET category_id = @CategoryId, Name = @Name, quantity = @Quantity WHERE id = @Id";
            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CategoryId", item.CategoryId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Quantity", item.Quantity);
            command.Parameters.AddWithValue("@Id", item.Id);

            command.ExecuteNonQuery();
        }

        public void DeleteItem(int id)
        {
            using var connection = _connection.CreateConnection();
            connection.Open();

            string sql = "DELETE FROM InventoryItems WHERE id = @Id";
            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }
}