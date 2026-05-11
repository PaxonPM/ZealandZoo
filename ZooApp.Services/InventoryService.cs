using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZoo.Models;
using ZealandZoo.Repositories;

namespace ZealandZoo.Services
{
    public class InventoryService
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryService(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public bool CreateItem(InventoryItem item)
        {
            if (_inventoryRepository.ExistsByName(item.Name))
                return false;

            _inventoryRepository.CreateItem(item);
            return true;
        }

        public List<ItemCategory> GetAllCategories()
        {
            return _inventoryRepository.GetAllCategories();
        }
    }
}
