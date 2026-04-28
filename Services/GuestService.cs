using ZealandZoo.MockData;
using ZealandZoo.Models;

namespace ZealandZoo.Services
{
    public class GuestService
        {
            public List<Guest> GetGuests()
            {
                return MockGuests.GetMockGuests();
            }

            public void AddGuest(Guest guest)
            {
                MockGuests.AddGuest(guest);
            }
        }
}


