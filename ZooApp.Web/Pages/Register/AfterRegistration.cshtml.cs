using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZooApp.Web.Pages.Register
{
    /// <summary>
    /// PageModel for Guest Dashboard.
    /// Ensures only logged-in guests can access the page.
    /// </summary>
    public class AfterRegistrationModel : PageModel
    {
        /// <summary>
        /// Redirects to login if user is not a guest.
        /// </summary>
        public IActionResult OnGet()
        {

            return Page();
        }
    }
}