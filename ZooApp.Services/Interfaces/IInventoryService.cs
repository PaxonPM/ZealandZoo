using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZoo.Models;
using ZooApp.Domain.Models;

namespace ZooApp.Services.Interfaces
{
    public interface IInventoryService
    {
        bool CreateItem(InventoryItem item);
        List<ItemCategory> GetAllCategories();
        public List<InventoryItem> GetAllItems();
        public void UpdateItem(InventoryItem item);
    }
}
