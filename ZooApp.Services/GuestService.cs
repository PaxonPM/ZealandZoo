using System.Security.Cryptography;
using System.Text;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZooApp.Services
{
    /// <summary>
    /// Service responsible for handling guest-related business logic.
    /// </summary>
    public class GuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        /// <summary>
        /// Creates a new guest. Hashes the password before saving to the database.
        /// </summary>
        public void CreateGuest(GuestModel guest)
        {
            if (guest == null)
                throw new Exception("Guest cannot be null.");

            if (string.IsNullOrWhiteSpace(guest.Email))
                throw new Exception("Email is required.");

            if (string.IsNullOrWhiteSpace(guest.Password))
                throw new Exception("Password is required.");

            if (_guestRepository.GetByEmail(guest.Email) != null)
                throw new Exception("An account with that email already exists.");

            guest.Password = HashPassword(guest.Password);

            _guestRepository.Create(guest);
        }

        /// <summary>
        /// Validates guest login by comparing email and hashed password against the database.
        /// </summary>
        public GuestModel? ValidateLogin(string email, string password)
        {
            GuestModel? guest = _guestRepository.GetByEmail(email);

            if (guest == null)
                return null;

            string hashedInput = HashPassword(password);

            if (guest.Password != hashedInput)
                return null;

            return guest;
        }

        /// <summary>
        /// Hashes a password using SHA256.
        /// </summary>
        private string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}