using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Domain.Models;

namespace ZooApp.Data.MockData
{
    public class MockInventory
    {
        public static List<InventoryItem> GetAll()
        {
            return new List<InventoryItem>
            {
            new InventoryItem(1,1,"Tuborg Grøn",269),
            new InventoryItem(2,1,"Tuborg Classic",87),
            new InventoryItem(3,1,"Carlsberg",63),
            new InventoryItem(4,1,"Heineken ",31),
            new InventoryItem(5,2,"Faxe Kondi",982),
            new InventoryItem(6,1,"Corona",271),
            new InventoryItem(7,2,"Pepsi",92),
            new InventoryItem(8,3,"Sour cream & onion",69),
            new InventoryItem(9,3,"Havssalt",420)
            };

        }
    }
}
