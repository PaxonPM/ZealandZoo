using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages.Guest
{
    /// <summary>
    /// PageModel for creating a new guest user.
    /// Handles user input, validation, password hashing, and feedback.
    /// </summary>
    public class CreateGuestModel : PageModel
    {
        private readonly IGuestService _guestService;

        public CreateGuestModel(IGuestService guestService)
        {
            _guestService = guestService;
        }

        /// <summary>
        /// Person object bound to the form input.
        /// </summary>
        [BindProperty]
        public UserModel user { get; set; } = new UserModel();

        /// <summary>
        /// Confirmation message shown after successful creation.
        /// </summary>
        public string? SuccessMessage { get; set; }

        /// <summary>
        /// Error message shown if something fails.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Handles request for creating a new guest.
        /// </summary>
        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Ugyldigt input. Kontroller dine oplysninger.");

                UserModel guest = new UserModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    Telefon = user.Telefon,
                    PwHash = user.PwHash,
                    IsNotificationActive = user.IsNotificationActive
                };

                _guestService.CreateGuest(guest);

                SuccessMessage = "Bruger oprettet!";
                ModelState.Clear();
                user = new UserModel();

                return RedirectToPage("/index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
}