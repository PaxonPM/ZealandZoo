using ZealandZoo.Models;
using ZealandZoo.Services;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;
using ZooApp.Domain.Models;
namespace ZooApp.Tests
{
    public class FakeInventoryRepository : IInventoryRepository
    {
        private List<InventoryItem> _items = new();

        public bool ExistsByName(string name) =>
            _items.Any(i => i.Name == name);

        public void CreateItem(InventoryItem item) =>
            _items.Add(item);

        public List<InventoryItem> GetAllItems() =>
            _items;

        public void UpdateItem(InventoryItem item)
        {
            var existing = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Quantity = item.Quantity;
            }
        }

        public void DeleteItem(int id) =>
            _items.RemoveAll(i => i.Id == id);

        public List<ItemCategory> GetAllCategories() => new List<ItemCategory>();
    }

    public class InventoryServiceTests
    {
        private readonly InventoryService _service;

        public InventoryServiceTests()
        {
            _service = new InventoryService(new FakeInventoryRepository());
        }

        [Fact]
        public void CreateItem_WithNewName_ReturnsTrue()
        {
            // Arrange
            var item = new InventoryItem { Name = "Pepsi Max", CategoryId = 1, Quantity = 10 };

            // Act
            bool result = _service.CreateItem(item);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CreateItem_WithDuplicateName_ReturnsFalse()
        {
            // Arrange
            var item = new InventoryItem { Name = "Pepsi Max", CategoryId = 1, Quantity = 10 };
            _service.CreateItem(item); // Opret første gang

            // Act
            bool result = _service.CreateItem(item); // Forsøg at oprette igen

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAllItems_ReturnsAllCreatedItems()
        {
            // Arrange
            _service.CreateItem(new InventoryItem { Name = "Pepsi Max", CategoryId = 1, Quantity = 5 });
            _service.CreateItem(new InventoryItem { Name = "Carlsberg", CategoryId = 2, Quantity = 10 });

            // Act
            var result = _service.GetAllItems();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void CreateItem_ItemIsActuallyStoredInList()
        {
            // Arrange
            var item = new InventoryItem { Name = "Pepsi Max", CategoryId = 1, Quantity = 5 };

            // Act
            _service.CreateItem(item);
            var result = _service.GetAllItems();

            // Assert
            Assert.Contains(result, i => i.Name == "Pepsi Max");
        }
    }
}