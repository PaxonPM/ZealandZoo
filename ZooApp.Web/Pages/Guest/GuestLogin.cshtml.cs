using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ZooApp.Services;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages.Guest
{
    /// <summary>
    /// PageModel for guest login.
    /// Handles guest login by email and stores guest information in session.
    /// </summary>
    public class GuestLoginModel : PageModel
    {
        private readonly IGuestService _guestService;

        public GuestLoginModel(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [BindProperty]
        [Required(ErrorMessage = "Email er påkrævet")]
        public string Email { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Password er påkrævet")]
        public string Password { get; set; } = "";

        public string ErrorMessage { get; set; } = "";

        public void OnGet() { }

        public IActionResult OnPost()
        {
            ZooApp.Domain.Models.UserModel? guest = _guestService.ValidateLogin(Email, Password);

            if (guest == null)
            {
                ErrorMessage = "Forkerte loginoplysninger";
                return Page();
            }

            HttpContext.Session.SetString("IsGuest", "true");
            HttpContext.Session.SetInt32("GuestId", guest.Id);
            HttpContext.Session.SetString("GuestUsername", guest.Name);

            return RedirectToPage("/Guest/GuestDashboard");
        }
    }
}