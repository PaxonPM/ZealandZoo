using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services;


public sealed class UserAuthenticator : IUserAuthenticator
{
    public UserModel? Authenticate(UserModel? candidate, string password)
    {
        if (candidate == null)
            return null;

        if (candidate.PwHash != PasswordHelper.Hash(password))
            return null;

        return candidate;
    }
}