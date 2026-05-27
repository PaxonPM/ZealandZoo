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

        [BindProperty(SupportsGet = true)]
        public string? SearchTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "date_asc";

        public void OnGet()
        {
            int? guestId = HttpContext.Session.GetInt32("GuestId");

            var events = _eventService.GetAllEvents();

            // Filtrering
            if (!string.IsNullOrEmpty(SearchTitle))
            {
                events = events.Where(e => e.Title.Contains(SearchTitle,
                    StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sortering
            Events = SortOrder switch
            {
                "date_asc" => events.OrderBy(e => e.StartDateTime).ToList(),
                "date_desc" => events.OrderByDescending(e => e.StartDateTime).ToList(),
                "title_asc" => events.OrderBy(e => e.Title).ToList(),
                _ => events
            };

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