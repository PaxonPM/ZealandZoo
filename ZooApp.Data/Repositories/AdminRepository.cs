using ZooApp.Data.MockData;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Repositories
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
