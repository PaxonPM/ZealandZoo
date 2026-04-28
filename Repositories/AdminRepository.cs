// Repositories/AdminRepository.cs
using ZealandZoo.MockData;
using ZealandZoo.Models;

namespace ZealandZoo.Repositories
{
    public class AdminRepository
    {
        public Admin? GetByCredentials(string username, string password)
        {
            return AdminMock.Admins
                .FirstOrDefault(a => a.Username == username && a.Password == password);
        }
    }
}