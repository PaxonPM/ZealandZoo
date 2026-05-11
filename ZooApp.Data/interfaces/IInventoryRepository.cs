using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZoo.Models;
using ZooApp.Domain.Models;

namespace ZooApp.Data.interfaces
{
    public interface IInventoryRepository
    {
        bool ExistsByName(string name);
        void CreateItem(InventoryItem item);
        List<ItemCategory> GetAllCategories();
    }
}
