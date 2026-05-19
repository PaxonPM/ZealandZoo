using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services.Interfaces;
using ZooApp.Web.Pages.Shared;

namespace ZooApp.Web.Pages.Event
{
    public class UpdateEventModel : PageModel
    {
        private readonly IEventService _eventService;

        public ModalViewErrorModel Modal { get; set; }

        [BindProperty]
        public Domain.Models.Event Event { get; set; }

        public Domain.Models.Event UpdatedEvent { get; set; }

        public UpdateEventModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Modal = new ModalViewErrorModel();

            try
            {
                Event = await _eventService.GetEventByIdAsync(id);

                if (Event == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Modal = new ModalViewErrorModel
                {
                    Title = ex.Source != null ? ex.Source : "Error",
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    Code = "error"
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Modal = new ModalViewErrorModel();
                return Page();
            }

            try
            {
                UpdatedEvent = await _eventService.UpdateEventAsync(Event);
            }
            catch (Exception ex)
            {
                Modal = new ModalViewErrorModel
                {
                    Title = ex.Source != null ? ex.Source : "Error",
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    Code = "error"
                };
            }

            return Page();
        }
    }
}