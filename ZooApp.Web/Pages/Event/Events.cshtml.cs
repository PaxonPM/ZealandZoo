using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages.Event
{
    public class EventsModel : PageModel
    {
        private readonly IEventService _eventService;

        public EventsModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        public List<ZooApp.Domain.Models.Event> Events { get; set; } = new();
        public Dictionary<int, bool> UserSignUps { get; set; } = new();

        [TempData]
        public string? SuccessMessage { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            int? guestId = HttpContext.Session.GetInt32("GuestId");

            Events = _eventService.GetAllEvents();

            UserSignUps = Events.ToDictionary(
                ev => ev.Id,
                ev => guestId.HasValue && _eventService.IsUserSignedUp(ev.Id, guestId.Value)
            );
        }

        public IActionResult OnPostSignUp(int eventId)
        {
            int? guestId = HttpContext.Session.GetInt32("GuestId");
            if (guestId == null) return RedirectToPage("/Guest/GuestLogin");

            try
            {
                _eventService.SignUpForEvent(eventId, guestId.Value);
                SuccessMessage = "Du er nu tilmeldt eventet.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return RedirectToPage();
        }

        public IActionResult OnPostCancelSignUp(int eventId)
        {
            int? guestId = HttpContext.Session.GetInt32("GuestId");
            if (guestId == null) return RedirectToPage("/Guest/GuestLogin");

            try
            {
                _eventService.CancelSignUp(eventId, guestId.Value);
                SuccessMessage = "Du er nu afmeldt eventet.";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return RedirectToPage();
        }
    }
}