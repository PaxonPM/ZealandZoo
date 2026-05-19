using Microsoft.AspNetCore.Mvc;
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

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                TempData["ErrorMessage"] = "Du skal være logget ind som admin for at se lageret.";
                return RedirectToPage("/Admin/AdminLogin");
            }

            Items = _inventoryService.GetAllItems();
            return Page();
        }
    }
}