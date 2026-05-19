using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Data.MockData;
using ZooApp.Data.Repositories;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;
using ZooApp.Data.interfaces;
using System.Security.Cryptography;

namespace ZooApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
            if (user == null)
            {
                throw new Exception("User cannot be null.");
            }

            if (int.IsNegative(user.Id))
            {
                throw new Exception("Id is required.");
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new Exception("Password is required.");
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new Exception("Email is required.");
            }

            if (string.IsNullOrWhiteSpace(user.PwHash))
            {
                throw new Exception("Password is required.");
            }
            if (string.IsNullOrWhiteSpace(user.Telefon))
            {
                throw new Exception("Phone number is required.");
            }

            if (string.IsNullOrWhiteSpace(user.Role))
            {
                throw new Exception("Role is required.");
            }

            //user.PwHash = HashPassword(user.PwHash);

            //Save to mock Repository
            _userRepository.Create(user);

            return user;
        }

        public List<Event> GetAllUsers()
        {
            throw new NotImplementedException();
        }
        //private static string HashPassword(string pwHash)
        //{

        //}
        public User ValidateLogin(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty.", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty.", nameof(password));
            }

            User user = _userRepository.GetByEmail(email);

            if (user == null)
            {
                return null;
            }

            string hashedInput = HashPassword(password);

            if(user.PwHash != hashedInput)
            {
                return null;
            }

            return user;
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

