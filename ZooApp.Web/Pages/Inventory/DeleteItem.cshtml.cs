using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZoo.Services;

namespace ZooApp.Web.Pages.Inventory
{
    public class DeleteItemModel : PageModel
    {
        private readonly InventoryService _inventoryService;

        public DeleteItemModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public IActionResult OnPost(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
                return RedirectToPage("/Admin/AdminLogin");

            _inventoryService.DeleteItem(id);
            return RedirectToPage("/Inventory/Inventory");
        }
    }
}