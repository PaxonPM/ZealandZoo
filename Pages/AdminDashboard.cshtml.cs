using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandZoo.Pages
{
    public class AdminDashboardModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Kun admins må komme ind
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToPage("/AdminLogin");
            }
            return Page();
        }
    }
}