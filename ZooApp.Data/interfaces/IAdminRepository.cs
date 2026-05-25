using ZooApp.Domain.Models;

namespace ZooApp.Data.interfaces;

/// <summary>
/// Interface for the Admin repository, which extends the IUserRepository interface and provides additional methods specific to admin users. 
/// </summary>
public interface IAdminRepository : IUserRepository
{
    UserModel? GetByName(string name);
}