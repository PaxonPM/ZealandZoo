using ZealandZoo.MockData;
using ZealandZoo.Models;

namespace ZealandZoo.Services
{
    public class EventService
    {
        public List<Event> GetEvents()
        {
            return MockEvents.GetMockEvents();
        }

        public void AddGuestToEvent(int eventId, Guest guest)
        {
            MockEvents.AddGuestToEvent(eventId, guest);
        }
    }
}