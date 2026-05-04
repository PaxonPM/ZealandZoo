// Services/AdminService.cs
using ZealandZoo.Repositories;
using ZealandZoo.Models;

namespace ZealandZoo.Services
{
    public class AdminService
    {
        private readonly AdminRepository _adminRepository;

        public AdminService(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public bool ValidateLogin(string username, string password)
        {
            Admin? admin = _adminRepository.GetByUsername(username);

            if (admin == null) return false;

            return admin.Password == password;
        }
    }
}