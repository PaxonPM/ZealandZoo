using ZooApp.Domain.Models;

namespace ZooApp.Data.MockData

{

    public class MockEvent
    {
        

        private static List<Event> _eventList { get; set; } = new List<Event>()
        {
            new Event{Id = 1, Title = "Event 1", Description = "Description for Event 1", StartDateTime = new DateTime(2024, 7, 15), EndDateTime = new DateTime(2024, 7, 15), Location = "Location 1", MaxParticipants = 100 },
            new Event{Id = 2, Title = "Event 2", Description = "Description for Event 2", StartDateTime = new DateTime(2024, 8, 20), EndDateTime = new DateTime(2024, 8, 20), Location = "Location 2", MaxParticipants = 150 },
            new Event{Id = 3, Title = "Event 3", Description = "Description for Event 3", StartDateTime = new DateTime(2024, 9, 10), EndDateTime = new DateTime(2024, 9, 10), Location = "Location 3", MaxParticipants = 200 }
        };

        public static List<Event> GetMockEvents()
        {
            return _eventList;
        }
    }
}

