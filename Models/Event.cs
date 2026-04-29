using ZealandZoo.Models;

namespace ZealandZoo.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int GuestCount { get; set; }

        public List<Guest> Guests { get; set; } = new List<Guest>();

        public Event()
        {
            EventName = "";
        }

        public Event(int eventId, string eventName)
        {
            EventId = eventId;
            EventName = eventName;
            GuestCount = 0;
        }
    }
}