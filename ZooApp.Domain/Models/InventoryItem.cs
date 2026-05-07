using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Domain.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }

        
        public InventoryItem(int id, int category,string name, int quantity)
        {
            Id = id;
            Category = category;
            Name = name;
            Quantity = quantity;
        }


      
    }
}
