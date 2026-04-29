using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services.Interfaces;
using ZooApp.Domain;

namespace ZooApp.Web.Pages.Event
{
    public class CreateEventModel : PageModel
    {
        private IEventService _eventService;

        public CreateEventModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        [BindProperty]
        public Domain.Models.Event Event { get; set; }
        public Domain.Models.Event CreatedEvent { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CreatedEvent = _eventService.CreateEvent(Event);
            return Page();
        }
    }
}
