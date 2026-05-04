using ZooApp.Data.Repositories;
using ZooApp.Domain.Models;

namespace ZooApp.Services.Services
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
