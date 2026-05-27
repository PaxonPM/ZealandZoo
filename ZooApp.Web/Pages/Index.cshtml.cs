using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZealandZoo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEventService _eventService;

        public List<OpenHours> ÅbningsTider { get; set; } = new List<OpenHours>();
        public List<ZooApp.Domain.Models.Event> Events { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string View { get; set; } = "List";

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

        // Add this property to your IndexModel class
        public Dictionary<int, bool> UserSignUps { get; set; } = new Dictionary<int, bool>();

        [BindProperty(SupportsGet = true)]
        public string? SearchTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "date_asc";

        public IndexModel(ILogger<IndexModel> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }

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
            

            ÅbningsTider = new List<OpenHours>
            {

                new OpenHours
                {
                    DayOfWeek = DayOfWeek.Friday,
                    OpenTime = new TimeOnly(15, 00),
                    CloseTime = new TimeOnly(23, 59),
                },

            };


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
