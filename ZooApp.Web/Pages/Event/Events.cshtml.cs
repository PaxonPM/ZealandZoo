using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;
using ZooApp.Services.Services;

namespace ZooApp.Web.Pages.Event
{
    /// <summary>
    /// PageModel for the Events page.
    /// </summary>
    public class EventsModel : PageModel
    {
        /// <summary>
        /// Service used for event logic and data.
        /// </summary>
        private readonly IEventService _eventService;

        /// <summary>
        /// Constructor with dependency injection of EventService.
        /// </summary>
        /// <param name="eventService">Service for handling events</param>
        public EventsModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// List of events displayed on the page.
        /// </summary>
        public List<ZooApp.Domain.Models.Event> Events { get; set; } = new();

        /// <summary>
        /// Success message shown after a successful action.
        /// </summary>
        [TempData]
        public string? SuccessMessage { get; set; }

        /// <summary>
        /// Error message shown if an action fails.
        /// </summary>
        [TempData]
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Handles GET requests.
        /// Loads all events from the service.
        /// </summary>
        public void OnGet()
        {
            Events = _eventService.GetAllEvents();
        }

        /// <summary>
        /// Handles POST request for signing up to an event.
        /// Calls the EventService and handles possible exceptions.
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        /// <returns>Redirects back to the same page</returns>
        public IActionResult OnPostSignUp(int eventId)
        {
            try
            {
                // Temporary mock user ID
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
    }
}