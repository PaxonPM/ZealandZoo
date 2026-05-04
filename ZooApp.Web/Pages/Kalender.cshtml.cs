using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages
{
    public class KalenderModel : PageModel
    {
        private IEventService _eventService;

        public KalenderModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        [BindProperty]
        public Event Event { get; set; }

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
            _eventService.CreateEvent(Event);
            return RedirectToPage("Index");
        }
    }
}

