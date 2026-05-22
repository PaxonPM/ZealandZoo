using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZoo.Services;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages.Inventory
{
    public class InventoryModel : PageModel
    {
        private readonly IInventoryService _inventoryService;
        public List<InventoryItem> Items { get; set; } = new();

        public InventoryModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public IActionResult OnGet()
        {
            if ((HttpContext.Session.GetString("IsAdmin") != "true") && (HttpContext.Session.GetString("IsStaff") != "true"))
            {
                TempData["ErrorMessage"] = "Du skal være logget ind som admin/medarbejder for at se lageret.";
                return RedirectToPage("/Admin/AdminLogin");
            }

            Items = _inventoryService.GetAllItems();
            return Page();
        }
    }
}