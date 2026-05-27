using ZooApp.Domain.Models;

namespace ZooApp.Data.interfaces;

/// <summary>
/// Interface for the User repository, which defines methods for retrieving user information from the data source.
/// </summary>
public interface IUserRepository
{
    UserModel? GetById(int id);
    IEnumerable<UserModel> GetAll();
    UserModel? GetByEmail(string email);
}