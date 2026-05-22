using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZealandZoo.Services;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages.Inventory
{
    public class EditItemModel : PageModel
    {
        private readonly IInventoryService _inventoryService;

        [BindProperty]
        public InventoryItem Item { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public EditItemModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public IActionResult OnGet(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true" && HttpContext.Session.GetString("IsStaff") != "true")
                return RedirectToPage("/Admin/AdminLogin");

            Item = _inventoryService.GetAllItems().FirstOrDefault(i => i.Id == id);
            if (Item == null) return NotFound();

            LoadCategories();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true" && HttpContext.Session.GetString("IsStaff") != "true")
                return RedirectToPage("/Admin/AdminLogin");

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return Page();
            }

            _inventoryService.UpdateItem(Item);
            return RedirectToPage("/Inventory/Inventory");
        }

        private void LoadCategories()
        {
            Categories = _inventoryService.GetAllCategories()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
        }
    }
}