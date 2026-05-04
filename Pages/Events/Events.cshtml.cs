using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZoo.Models;
using ZealandZoo.Services;

namespace ZealandZoo.Pages
{
    /// <summary>
    /// PageModel for the Events page.
    /// </summary>
    public class EventsModel : PageModel
    {
        /// <summary>
        /// Service used for event logic and data.
        /// </summary>
        private readonly EventService _eventService;

        /// <summary>
        /// Constructor with dependency injection of EventService.
        /// </summary>
        /// <param name="eventService">Service for handling events</param>
        public EventsModel(EventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// List of events displayed on the page.
        /// </summary>
        public List<Event> Events { get; set; } = new List<Event>();

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