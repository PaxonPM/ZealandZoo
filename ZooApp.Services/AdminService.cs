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

            if (admin == null) return false;

            return admin.Password == password;
        }
    }
}
