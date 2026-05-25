using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services;


public sealed class StaffService : IStaffService
{
    private readonly IStaffRepository _staffRepository;
    private readonly IUserAuthenticator _authenticator;

    public StaffService(IStaffRepository staffRepository, IUserAuthenticator authenticator)
    {
        _staffRepository = staffRepository;
        _authenticator = authenticator;
    }

    public UserModel? ValidateLogin(string identifier, string password)
        => _authenticator.Authenticate(_staffRepository.GetByEmail(identifier), password);

    public UserModel CreateStaff(UserModel user)
    {
        PasswordHelper.ValidateAndHash(user);
        return _staffRepository.Create(user);
    }
}