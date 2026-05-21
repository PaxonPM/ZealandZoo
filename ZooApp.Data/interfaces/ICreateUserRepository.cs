using ZooApp.Domain.Models;

namespace ZooApp.Data.interfaces;

/// <summary>
/// Interface for the CreateUser repository, which defines the method for creating a new user in the application. 
/// This interface is separate from the IUserRepository to allow for a clear separation of concerns and to ensure 
/// that user creation logic can be handled independently from other user-related operations.
/// </summary>
public interface ICreateUserRepository
{
    UserModel Create(UserModel entity);
}