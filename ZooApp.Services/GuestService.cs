using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services;

/// <summary>
/// Service responsible for handling guest-related business logic.
/// </summary>
public sealed class GuestService : IGuestService
{
    private readonly IGuestRepository _guestRepository;
    private readonly IUserAuthenticator _authenticator;

    public GuestService(IGuestRepository guestRepository, IUserAuthenticator authenticator)
    {
        _guestRepository = guestRepository;
        _authenticator = authenticator;
    }

    public UserModel? ValidateLogin(string identifier, string password)
    {
        return _authenticator.Authenticate(_guestRepository.GetByEmail(identifier), password);
    }

    public void CreateGuest(UserModel guest)
    {
        PasswordHelper.ValidateAndHash(guest);

        if (_guestRepository.GetByEmail(guest.Email) != null)
            throw new InvalidOperationException("An account with that email already exists.");

        _guestRepository.Create(guest);
    }

    public List<UserModel> GetNewsletterMembers()
        => _guestRepository.GetAll().Where(u => u.IsNotificationActive).ToList();
}