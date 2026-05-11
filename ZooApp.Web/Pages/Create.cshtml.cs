using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZealandZoo.Models;
using ZealandZoo.Services;

namespace ZealandZoo.Pages.Inventory
{
    public class CreateModel : PageModel
    {
        private readonly InventoryService _inventoryService;
        public string ErrorMessage { get; set; }
        public CreateModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [BindProperty]
        public InventoryItem NewItem { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public IActionResult OnGet()
        {
            // Adgangsbeskyttelse
            if (HttpContext.Session.GetString("IsAdmin") != "true")
                return RedirectToPage("Admin/AdminLogin");

            LoadCategories();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
                return RedirectToPage("/Admin/AdminLogin");

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return Page();
            }

            bool created = _inventoryService.CreateItem(NewItem);

            if (!created)
            {
                ErrorMessage = "En vare med dette navn eksisterer allerede.";
                LoadCategories();
                return Page();
            }

            return RedirectToPage("/Create");
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