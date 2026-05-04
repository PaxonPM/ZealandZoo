using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZooApp.Web.Pages.Shared
{
    /// <summary>
    /// Page model for displaying error messages in a modal dialog.
    /// This is used as a partial view model to show errors throughout the application.
    /// </summary>
    public class ModalViewErrorModel : PageModel
    {
        /// <summary>
        /// Gets or sets the title displayed in the modal header.
        /// Defaults to an empty string.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the error message displayed in the modal body.
        /// This typically contains the exception message or user-friendly error description.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the stack trace of the exception.
        /// Used for debugging purposes and typically not shown to end users in production.
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Gets or sets the error code used to determine the modal styling or behavior.
        /// Common values include "error", "warning", or "info".
        /// </summary>
        public string Code { get; set; }
    }
}
