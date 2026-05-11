using System.Security.Cryptography;
using System.Text;
using ZooApp.Data.MockData;
using ZooApp.Domain.Models;

namespace ZooApp.Services
{
    /// <summary>
    /// Service responsible for handling guest-related business logic.
    /// </summary>
    public class GuestService
    {
        /// <summary>
        /// Returns all guests from mock data.
        /// </summary>
        public List<Guest> GetAllGuests()
        {
            return MockGuests.GetMockGuests();
        }

        /// <summary>
        /// Creates a new guest.
        /// hashes the password before saving.
        /// </summary>
        /// <param name="guest">Guest to create</param>
        public void CreateGuest(Guest guest)
        {
            if (guest == null)
            {
                throw new Exception("Guest cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(guest.UserName))
            {
                throw new Exception("Username is required.");
            }

            if (string.IsNullOrWhiteSpace(guest.Password))
            {
                throw new Exception("Password is required.");
            }

            // Check for duplicate username
            if (MockGuests.GetMockGuests().Any(g => g.UserName == guest.UserName))
            {
                throw new Exception("Username already exists.");
            }

            // Hash password
            guest.Password = HashPassword(guest.Password);

            // Save to mock database
            MockGuests.AddGuest(guest);
        }

        /// <summary>
        /// Hashes a password using SHA256.
        /// </summary>
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
        /// <summary>
        /// Validates guest login by comparing username and hashed password.
        /// </summary>
        /// <param name="username">Guest username</param>
        /// <param name="password">Plain text password</param>
        /// <returns>The guest if login is valid, otherwise null</returns>
        public Guest? ValidateLogin(string username, string password)
        {
            Guest? guest = MockGuests.GetMockGuests()
                .FirstOrDefault(g => g.UserName == username);

            if (guest == null)
            {
                return null;
            }

            string hashedInput = HashPassword(password);

            if (guest.Password != hashedInput)
            {
                return null;
            }

            return guest;
        }

    }
}