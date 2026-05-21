using ZooApp.Domain.Models;

namespace ZooApp.Services.Interfaces;


public interface IUserAuthenticator
{
    UserModel? Authenticate(UserModel? candidate, string password);
}