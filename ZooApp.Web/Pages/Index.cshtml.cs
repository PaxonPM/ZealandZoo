using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IndexModel(ILogger<IndexModel> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }

        public void OnGet()
        {
            Events = _eventService.GetAllEvents();

            ÅbningsTider = new List<OpenHours>
            {

                new OpenHours
                {
                    DayOfWeek = DayOfWeek.Friday,
                    OpenTime = new TimeOnly(15,00),
                    CloseTime = new TimeOnly(23,59),
                },

            };


        }
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
