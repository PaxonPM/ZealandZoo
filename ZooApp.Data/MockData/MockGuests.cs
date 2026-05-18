using ZooApp.Domain.Models;

namespace ZooApp.Data.MockData
{
    /// <summary>
    /// MockGuests acts as a temporary in-memory data source for guest users.
    /// </summary>
    public class MockGuests
    {
        private static List<GuestModel> guests = new List<GuestModel>()
        {
            new GuestModel("Lukas",    "lukas@email.com",    "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=") { UserId = 1 },
            new GuestModel("Frederik", "frederik@email.com", "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=") { UserId = 2 },
            new GuestModel("Paw",      "paw@email.com",      "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=") { UserId = 3 },
            new GuestModel("Nikolai",  "nikolai@email.com",  "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=") { UserId = 4 }
        };

        /// <summary>
        /// Returns all guest users from the mock list.
        /// </summary>
        public static List<GuestModel> GetMockGuests()
        {
            return guests;
        }

        /// <summary>
        /// Retrieves a guest by email address.
        /// </summary>
        public static GuestModel? GetByEmail(string email)
        {
            return guests.FirstOrDefault(g => g.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Adds a new guest to the mock list.
        /// </summary>
        public static void AddGuest(GuestModel guest)
        {
            int latestId = guests.Any() ? guests.Max(g => g.UserId) : 0;
            guest.UserId = latestId + 1;
            guests.Add(guest);
        }
    }
}