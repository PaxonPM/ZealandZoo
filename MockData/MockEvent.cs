using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using ZealandZoo.Models;

namespace ZealandZoo.MockData

{

    public class MockEvent
    {
        private static List<OpenHours> _openHoursList { get; set; } = new List<OpenHours>()
        {
            new OpenHours{DayOfWeek = DayOfWeek.Monday, OpenTime = new TimeOnly(14,30), CloseTime = new TimeOnly(18), IsClosed = false, Note = null},
            new OpenHours{DayOfWeek = DayOfWeek.Tuesday, OpenTime = new TimeOnly(14,30), CloseTime = new TimeOnly(18), IsClosed = false, Note = null},
            new OpenHours{DayOfWeek = DayOfWeek.Wednesday, OpenTime = new TimeOnly(14,30), CloseTime = new TimeOnly(18), IsClosed = false, Note = null},
            new OpenHours{DayOfWeek = DayOfWeek.Thursday, OpenTime = new TimeOnly(14,30), CloseTime = new TimeOnly(18), IsClosed = false, Note = null},
            new OpenHours{DayOfWeek = DayOfWeek.Friday, OpenTime = new TimeOnly(14,30), CloseTime = new TimeOnly(18), IsClosed = false, Note = null},
            new OpenHours{DayOfWeek = DayOfWeek.Saturday, OpenTime = new TimeOnly(), CloseTime = new TimeOnly(), IsClosed = true, Note = null},
            new OpenHours{DayOfWeek = DayOfWeek.Sunday, OpenTime = new TimeOnly(), CloseTime = new TimeOnly(), IsClosed = true, Note = null}
        };

        private static List<Event> _eventList { get; set; } = new List<Event>()
        {
            new Event{Id = 1, Title = "Event 1", Description = "Description for Event 1", StartDateTime = new DateTime(2024, 7, 15), EndDateTime = new DateTime(2024, 7, 15), Location = "Location 1", MaxParticipants = 100 },
            new Event{Id = 2, Title = "Event 2", Description = "Description for Event 2", StartDateTime = new DateTime(2024, 8, 20), EndDateTime = new DateTime(2024, 8, 20), Location = "Location 2", MaxParticipants = 150 },
            new Event{Id = 3, Title = "Event 3", Description = "Description for Event 3", StartDateTime = new DateTime(2024, 9, 10), EndDateTime = new DateTime(2024, 9, 10), Location = "Location 3", MaxParticipants = 200 }
        };




        public static List<OpenHours> GetMockOpenHours()
        {
            return _openHoursList;
        }

        public static List<Event> GetMockEvents()
        {
            return _eventList;
        }
    }
}

