using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZoo.Models;
using ZealandZoo.Repositories;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZealandZoo.Services
{
    public class InventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
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
