using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZoo.Models;
using ZooApp.Domain.Models;

namespace ZooApp.Data.interfaces
{
    /// <summary>
    /// Interface for the Inventory repository, which defines methods for managing inventory items and categories in the application.
    /// </summary>
    public interface IInventoryRepository
    {
        bool ExistsByName(string name);
        void CreateItem(InventoryItem item);
        List<ItemCategory> GetAllCategories();
        List<InventoryItem> GetAllItems();
        void UpdateItem(InventoryItem item);
        void DeleteItem(int id);
    }
}
