using ZealandZoo.Models;

namespace ZealandZoo.MockData
{
    public class MockGuests
    {

        private static List<Guest> guests = new List<Guest>()
        {
        new Guest("Lukas", "123") { UserId = 1 },
        new Guest("Frederik", "123") { UserId = 2 },
        new Guest("Paw", "123") { UserId = 3 },
        new Guest("Nikolai", "123") { UserId = 4 }
        };


        public static List<Guest> GetMockGuests()
        {
            return guests;
        }

        public static void AddGuest(Guest guest)
        {
            int latestId = guests.Any() ? guests.Max(g => g.UserId) : 0;
            guest.UserId = latestId + 1;

            guests.Add(guest);
        }
    }
}