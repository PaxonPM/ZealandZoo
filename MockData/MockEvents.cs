using ZealandZoo.Models;

namespace ZealandZoo.MockData
{
    public class MockEvents
    {
        private static List<Event> events = new List<Event>()
        {
            new Event(1, "Dødsdruk"),
            new Event(2, "Hyggefredag"),
            new Event(3, "Wests frække aften")
        };

        public static List<Event> GetMockEvents()
        {
            return events;
        }

        public static void AddGuestToEvent(int eventId, Guest guest)
        {
            Event? selectedEvent = events.FirstOrDefault(e => e.EventId == eventId);

            if (selectedEvent != null)
            {
                selectedEvent.Guests.Add(guest);
                selectedEvent.GuestCount++;
            }
        }
    }
}