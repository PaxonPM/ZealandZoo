using ZooApp.Domain.Models;

namespace ZooApp.Data.interfaces
{
    public interface IGuestRepository
    {
        GuestModel? GetByEmail(string email);
        GuestModel Create(GuestModel guest);
    }
}