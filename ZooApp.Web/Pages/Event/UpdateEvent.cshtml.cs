using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services.Interfaces;
using ZooApp.Web.Pages.Shared;

namespace ZooApp.Web.Pages.Event
{
    /// PageModel for updating an event.
    /// It loads an event, updates it, and shows errors in a modal.
    public class UpdateEventModel : PageModel
    {
        /// Service used to work with events.
        private readonly IEventService _eventService;

        /// Modal used to show error messages.
        public ModalViewErrorModel Modal { get; set; }

        /// Event data from the form.
        [BindProperty]
        public Domain.Models.Event Event { get; set; }

        /// The event after it has been updated.
        public Domain.Models.Event UpdatedEvent { get; set; }

        /// Constructor receives the event service through dependency injection.
        public UpdateEventModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// Runs when the update page is opened.
        public async Task<IActionResult> OnGetAsync(int id)
        {
            /// Creates an empty modal.
            Modal = new ModalViewErrorModel();

            try
            {
                /// Gets the event by id from the service.
                Event = await _eventService.GetEventByIdAsync(id);

                /// If no event is found, return 404.
                if (Event == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                /// Shows error information in the modal.
                Modal = new ModalViewErrorModel
                {
                    Title = ex.Source != null ? ex.Source : "Error",
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    Code = "error"
                };
            }

            /// Shows the update page.
            return Page();
        }

        /// Runs when the update form is submitted.
        public async Task<IActionResult> OnPostAsync()
        {
            /// If the form is not valid, show the page again.
            if (!ModelState.IsValid)
            {
                Modal = new ModalViewErrorModel();
                return Page();
            }

            try
            {
                /// Updates the event through the service.
                UpdatedEvent = await _eventService.UpdateEventAsync(Event);
            }
            catch (Exception ex)
            {
                /// Shows error information in the modal.
                Modal = new ModalViewErrorModel
                {
                    Title = ex.Source != null ? ex.Source : "Error",
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    Code = "error"
                };
            }

            /// Shows the page again after update.
            return Page();
        }
    }
}