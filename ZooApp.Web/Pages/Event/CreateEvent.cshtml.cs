using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services.Interfaces;
using ZooApp.Domain;
using ZooApp.Web.Pages.Shared;

namespace ZooApp.Web.Pages.Event
{
    /// <summary>
    /// Page model for creating new zoo events.
    /// Handles both GET requests to display the form and POST requests to create events.
    /// </summary>
    public class CreateEventModel : PageModel
    {
        /// <summary>
        /// Service for handling event-related business logic and data operations.
        /// </summary>
        private readonly IEventService _eventService;

        /// <summary>
        /// Gets or sets the modal error model for displaying error messages to the user.
        /// </summary>
        public ModalViewErrorModel Modal { get; set; }

        /// <summary>
        /// Gets or sets the event being created. This property is bound to the form inputs.
        /// </summary>
        [BindProperty]
        public Domain.Models.Event Event { get; set; }

        /// <summary>
        /// Gets or sets the successfully created event to display in the success modal.
        /// </summary>
        public Domain.Models.Event CreatedEvent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEventModel"/> class.
        /// </summary>
        /// <param name="eventService">The event service for managing event operations.</param>
        public CreateEventModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Handles GET requests to display the create event form.
        /// Initializes the Modal property to prevent null reference errors.
        /// </summary>
        /// <returns>A page result displaying the event creation form.</returns>
        public IActionResult OnGet()
        {
            // Initialize Modal to prevent null reference when no errors occur
            Modal = new ModalViewErrorModel();
            return Page();
        }

        /// <summary>
        /// Handles POST requests to create a new event.
        /// Validates the model state and attempts to create the event through the service layer.
        /// </summary>
        /// <returns>
        /// A page result displaying validation errors if the model is invalid,
        /// or the same page with either a success modal or error modal based on the operation result.
        /// </returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // Return to the form with validation errors if model state is invalid
            if (!ModelState.IsValid)
            {
                Modal = new ModalViewErrorModel();
                return Page();
            }

            try
            {
                // Attempt to create the event through the service layer
                CreatedEvent = await _eventService.CreateEventAsync(Event);
            }
            catch (Exception ex)
            {
                // Populate the error modal with exception details for user feedback
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
