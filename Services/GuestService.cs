using Microsoft.AspNetCore.Identity;
using ZealandZoo.MockData;
using ZealandZoo.Models;

namespace ZealandZoo.Services
{
    public class GuestService
    {
        private PasswordHasher<string> _passwordHasher = new PasswordHasher<string>();

        public List<Guest> GetGuests()
        {
            return MockGuests.GetMockGuests();
        }

        public void AddGuest(Guest guest)
        {

            guest.Password = _passwordHasher.HashPassword(null, guest.Password);

            MockGuests.AddGuest(guest);
        }
    }
}