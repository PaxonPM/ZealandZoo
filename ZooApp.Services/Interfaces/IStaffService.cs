using ZooApp.Domain.Models;

namespace ZooApp.Services.Interfaces;

public interface IStaffService : IAuthService
{
    UserModel CreateStaff(UserModel user);
}