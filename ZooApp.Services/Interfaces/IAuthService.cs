using ZooApp.Domain.Models;

namespace ZooApp.Services.Interfaces;


public interface IAuthService
{
    UserModel? ValidateLogin(string identifier, string password);
}