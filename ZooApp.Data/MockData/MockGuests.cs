using ZooApp.Domain.Models;

namespace ZooApp.Data.MockData
{
    /// <summary>
    /// MockGuests acts as a temporary in-memory data source for guest users.
    /// It simulates a database during development and testing.
    /// </summary>
    public class MockGuests
    {
        /// <summary>
        /// Static list of mock guest users.
        /// Passwords are stored as SHA256 hashes instead of plain text.
        /// </summary>
        private static List<Guest> guests = new List<Guest>()
        {
            new Guest("Lukas", "pmWkWSBCL51Bqz3z1ZC7fFZ9lP2M1vUqGkzR6d4W5bA=") { UserId = 1 },
            new Guest("Frederik", "pmWkWSBCL51Bqz3z1ZC7fFZ9lP2M1vUqGkzR6d4W5bA=") { UserId = 2 },
            new Guest("Paw", "pmWkWSBCL51Bqz3z1ZC7fFZ9lP2M1vUqGkzR6d4W5bA=") { UserId = 3 },
            new Guest("Nikolai", "pmWkWSBCL51Bqz3z1ZC7fFZ9lP2M1vUqGkzR6d4W5bA=") { UserId = 4 }
        };

        /// <summary>
        /// Returns all guest users from the mock list.
        /// </summary>
        /// <returns>A list of guests</returns>
        public static List<Guest> GetMockGuests()
        {
            return guests;
        }

        /// <summary>
        /// Adds a new guest to the mock list.
        /// Automatically assigns a unique UserId.
        /// </summary>
        /// <param name="guest">The guest to add</param>
        public static void AddGuest(Guest guest)
        {
            int latestId = guests.Any() ? guests.Max(g => g.UserId) : 0;
            guest.UserId = latestId + 1;

            guests.Add(guest);
        }
    }
}