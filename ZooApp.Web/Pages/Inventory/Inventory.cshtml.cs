using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZoo.Services;
using ZooApp.Domain.Models;

namespace ZooApp.Web.Pages.Inventory
{
    public class InventoryModel : PageModel
    {
        private readonly InventoryService _inventoryService;
        public List<InventoryItem> Items { get; set; } = new();

        public InventoryModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnGet()
        {
            Items = _inventoryService.GetAllItems();
        }
    }
}