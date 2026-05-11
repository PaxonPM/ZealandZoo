using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services;

namespace ZooApp.Web.Pages.Guest
{
    /// <summary>
    /// PageModel for guest login.
    /// Handles guest login and stores guest information in session.
    /// </summary>
    public class GuestLoginModel : PageModel
    {
        private readonly GuestService _guestService;

        public GuestLoginModel(GuestService guestService)
        {
            _guestService = guestService;
        }

        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public string ErrorMessage { get; set; } = "";

        public void OnGet() { }

        public IActionResult OnPost()
        {
            ZooApp.Domain.Models.Guest? guest = _guestService.ValidateLogin(Username, Password);

            if (guest == null)
            {
                ErrorMessage = "Forkerte loginoplysninger";
                return Page();
            }

            HttpContext.Session.SetString("IsGuest", "true");
            HttpContext.Session.SetInt32("GuestId", guest.UserId);
            HttpContext.Session.SetString("GuestUsername", guest.UserName);

            return RedirectToPage("/Guest/GuestDashboard");
        }
    }
}