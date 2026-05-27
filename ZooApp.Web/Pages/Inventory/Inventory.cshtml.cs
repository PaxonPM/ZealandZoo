using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages.Inventory
{
    public class InventoryModel : PageModel
    {
        private readonly IInventoryService _inventoryService;
        public List<InventoryItem> Items { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "name_asc";

        public InventoryModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public IActionResult OnGet()
        {
            var items = _inventoryService.GetAllItems();

            if ((HttpContext.Session.GetString("IsAdmin") != "true") && (HttpContext.Session.GetString("IsStaff") != "true"))
            {
                TempData["ErrorMessage"] = "Du skal være logget ind som admin/medarbejder for at se lageret.";
                return RedirectToPage("/Admin/AdminLogin");
            }    

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

            return Page();
        }
    }
}