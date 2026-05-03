using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using ZealandZoo.Models;
using ZealandZoo.Services;

namespace ZealandZoo.Pages
{
    public class KalenderModel : PageModel
    {
        //public List<Models.OpenHours> ÅbningsTider { get; set; } = new List<Models.OpenHours>();

        //public List<Models.Event> Events { get; set; } = new List<Models.Event>();

        //public List<OpenHours> SortByDate()
        //{
        //    var sortedEvents = Events
        //    .OrderBy(e => e.StartDateTime)
        //  .ToList();
        //}

       
        
            private IEventService _eventService;

            public KalenderModel(IEventService eventService)
            {
                _eventService = eventService;
            }

            [BindProperty]
            public Models.Event Event { get; set; }

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
                _eventService.AddEvent(Event);
                return RedirectToPage("GetAllEvent");
            }
        }



    }

    
    

