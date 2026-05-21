using ZooApp.Domain.Models;

namespace ZooApp.Services.Interfaces;

public interface IGuestService : IAuthService
{
    void CreateGuest(UserModel guest);
    List<UserModel> GetNewsletterMembers();

}