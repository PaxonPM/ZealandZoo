using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZoo.Models;
using ZealandZoo.Services;

namespace ZealandZoo.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly EventService _eventService;

        public IndexModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public List<Event> Events { get; set; } = new List<Event>();

        public void OnGet()
        {
            Events = _eventService.GetEvents();
        }

        public IActionResult OnPostJoinEvent(int eventId)
        {
            Guest guest = new Guest("CurrentGuest", "123");

            _eventService.AddGuestToEvent(eventId, guest);

            return RedirectToPage();
        }
    }
}