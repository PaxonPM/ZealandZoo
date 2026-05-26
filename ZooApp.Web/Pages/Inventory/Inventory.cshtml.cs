using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZoo.Services;
using ZooApp.Domain.Models;
using ZealandZoo.Services;
namespace ZooApp.Web.Pages.Inventory
{
    public class InventoryModel : PageModel
    {
        private readonly InventoryService _inventoryService;
        public List<InventoryItem> Items { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "name_asc";

        public InventoryModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnGet()
        {
            var items = _inventoryService.GetAllItems();

            // Filtrering
            if (!string.IsNullOrEmpty(SearchName))
            {
                items = items.Where(i => i.Name.Contains(SearchName,
                    StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sortering
            Items = SortOrder switch
            {
                "name_asc" => items.OrderBy(i => i.Name).ToList(),
                "name_desc" => items.OrderByDescending(i => i.Name).ToList(),
                "quantity_asc" => items.OrderBy(i => i.Quantity).ToList(),
                "quantity_desc" => items.OrderByDescending(i => i.Quantity).ToList(),
                _ => items
            };
        }
    }
}