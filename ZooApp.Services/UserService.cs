using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Data.MockData;
using ZooApp.Data.Repositories;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services
{
    internal class UserService 
    {
        private readonly UserRepository _userService;

        public UserService(UserRepository userRepository)
        {
            _userService = userRepository;
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

            // Save to mock Repository
            _userService.Create(user);

            return user;
        }
        //private static string HashPassword(string pwHash)
        //{
           
        //}
    }
}

