using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Domain.Models;
using ZooApp.Data.MockData;

namespace ZooApp.Web.Pages.Inventory
{
    public class InventoryModel : PageModel
    {
        public List<InventoryItem> Items { get; set; } = new();
        public void OnGetAsync()
        {
            Items = MockInventory.GetAll();
        }
    }
}
