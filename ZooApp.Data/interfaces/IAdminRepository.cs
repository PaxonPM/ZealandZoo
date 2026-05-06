using ZooApp.Domain.Models;

namespace ZooApp.Data.interfaces
{
    public interface IAdminRepository
    {

        public Admin? GetByUsername(string username);
    }
}