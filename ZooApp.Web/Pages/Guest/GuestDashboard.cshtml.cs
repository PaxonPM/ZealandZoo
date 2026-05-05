using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZooApp.Web.Pages.Guest
{
    /// <summary>
    /// PageModel for Guest Dashboard.
    /// Ensures only logged-in guests can access the page.
    /// </summary>
    public class GuestDashboardModel : PageModel
    {
        /// <summary>
        /// Redirects to login if user is not a guest.
        /// </summary>
        public IActionResult OnGet()
        {
            // Only guests are allowed access
            if (HttpContext.Session.GetString("IsGuest") != "true")
            {
                return RedirectToPage("/Guest/GuestLogin");
            }

            return Page();
        }
    }
}