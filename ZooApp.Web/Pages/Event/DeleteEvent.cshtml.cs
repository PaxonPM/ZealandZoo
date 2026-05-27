using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages.Event
{
    public class DeleteEventModel : PageModel
    {
        private readonly IEventService _eventService;
        public Domain.Models.Event DeletedEvent { get; set; }
        public DeleteEventModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        [BindProperty]
        public Domain.Models.Event Event { get; set; }

        public IActionResult OnGet(int id)
        {
            Event = _eventService.GetEventById(id);

            if (Event == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            DeletedEvent = _eventService.DeleteEvent(Event.Id);

            if (DeletedEvent == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}