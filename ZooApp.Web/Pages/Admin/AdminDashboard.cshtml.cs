using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZooApp.Web.Pages.Admin
{
    public class AdminDashboardModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Kun admins må komme ind
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToPage("/Admin/AdminLogin");
            }
            return Page();
        }
    }
}
