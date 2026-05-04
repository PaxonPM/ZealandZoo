// Repositories/AdminRepository.cs
using ZealandZoo.MockData;
using ZealandZoo.Models;

namespace ZealandZoo.Repositories
{
    public class AdminRepository
    {
        public Admin? GetByUsername(string username)
        {
            return AdminMock.Admins
                .FirstOrDefault(a => a.Username == username);
        }
    }
}