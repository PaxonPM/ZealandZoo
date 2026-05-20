using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Domain.Models;
using ZooApp.Services;

namespace ZooApp.Web.Pages.Guest
{
    /// <summary>
    /// PageModel for creating a new guest user.
    /// Handles user input, validation, password hashing, and feedback.
    /// </summary>
    public class CreateGuestModel : PageModel
    {
        private readonly GuestService _guestService;

        public CreateGuestModel(GuestService guestService)
        {
            _guestService = guestService;
        }

        /// <summary>
        /// Person object bound to the form input.
        /// </summary>
        [BindProperty]
        public Person Person { get; set; } = new Person();

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

                GuestModel guest = new GuestModel
                {
                    UserName = Person.Name,
                    Email = Person.Email,
                    PhoneNumber = Person.PhoneNumber,
                    Password = Person.PwHash,  // GuestService hashes this
                    IsNewsletterMember = Person.IsNewsLetterMember
                };

                _guestService.CreateGuest(guest);

                SuccessMessage = "Bruger oprettet!";
                ModelState.Clear();
                Person = new Person();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return RedirectToPage("/index"); ;
        }
    }
}