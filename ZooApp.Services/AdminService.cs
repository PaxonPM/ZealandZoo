using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services;


public sealed class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IUserAuthenticator _authenticator;

    public AdminService(IAdminRepository repository, IUserAuthenticator authenticator)
    {
        _adminRepository = repository;
        _authenticator = authenticator;
    }

    public UserModel? ValidateLogin(string identifier, string password)
        => _authenticator.Authenticate(_adminRepository.GetByName(identifier), password);
}
