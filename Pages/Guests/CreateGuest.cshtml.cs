using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZoo.Models;
using ZealandZoo.Services;

namespace ZealandZoo.Pages.Guests
{
    public class CreateGuestModel : PageModel
    {
        private readonly GuestService _guestService;

        public CreateGuestModel(GuestService guestService)
        {
            _guestService = guestService;
        }

        [BindProperty]
        public Guest Guest { get; set; } = new Guest();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _guestService.AddGuest(Guest);

            return RedirectToPage("/Index");
        }
    }
}