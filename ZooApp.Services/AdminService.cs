using System.Security.Cryptography;
using System.Text;
using ZooApp.Data.interfaces;
using ZooApp.Data.Repositories;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public bool ValidateLogin(string username, string password)
        {
            Admin? admin = _adminRepository.GetByUsername(username);

            

            //return admin.Password == password;

            if (admin == null)
                return false;

            string hashedInput = HashPassword(password);

            if (admin.Password != hashedInput)
                return false;

            return true;
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
