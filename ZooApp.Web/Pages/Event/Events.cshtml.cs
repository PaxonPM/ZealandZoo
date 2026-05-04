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
            int userId = 1;

            Events = _eventService.GetAllEvents();

            UserSignUps = Events.ToDictionary(
                ev => ev.Id,
                ev => _eventService.IsUserSignedUp(ev.Id, userId)
            );
        }

        public IActionResult OnPostSignUp(int eventId)
        {
            try
            {
                int userId = 1;
                _eventService.SignUpForEvent(eventId, userId);
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
            try
            {
                int userId = 1;
                _eventService.CancelSignUp(eventId, userId);
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