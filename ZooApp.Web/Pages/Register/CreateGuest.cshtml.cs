using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;
using ZooApp.Domain.Models;

namespace ZooApp.Web.Pages.Guest
{
    /// <summary>
    /// PageModel for creating a new guest user.
    /// Handles user input, validation, password hashing, and feedback.
    /// </summary>
    public class CreateGuestModel : PageModel
    {
        /// <summary>
        /// Person object bound to the form input.
        /// </summary>
        [BindProperty]
        public Person Person { get; set; } = new Person();

        /// <summary>
        /// Confirmation message shown after successful creation.
        /// </summary>
        public string? SuccessMessage { get; set; }

        /// <summary>
        /// Error message shown if something fails.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Handles request for creating a new guest.
        /// </summary>
        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Invalid input. Please check your data.");
                }

                // Hash password before saving
                Person.PwHash = HashPassword(Person.PwHash);
                
                // TODO Person RoleId 3 = guest (Check DEFAULT OR NOT IN DATABASE else set to guest)
                // HIGH_TODO save user to database, use database error handling.
               
                SuccessMessage = "User created successfully!";
                ModelState.Clear();
                
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }

        /// <summary>
        /// Hashes a password using SHA256.
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <returns>Hashed password</returns>
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}