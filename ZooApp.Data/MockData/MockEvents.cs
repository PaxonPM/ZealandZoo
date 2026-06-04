using ZooApp.Domain.Models;

namespace ZooApp.Data.MockData
{
    /// <summary>
    /// MockEvents acts as a temporary data source instead of a database.
    /// It contains a static list of events
    /// </summary>
    public class MockEvents
    {
        /// <summary>
        /// Static list of mock events.
        /// </summary>
        private static List<Event> events = new List<Event>()
        {
            new Event
            {
                Id = 1,
                Title = "Dødsdruk",
                Description = "A social evening at Zealand Zoo.",
                StartDateTime = new DateTime(2026, 5, 10, 18, 00, 00),
                EndDateTime = new DateTime(2026, 5, 10, 22, 00, 00),
                Location = "Zealand Zoo Café",
                MaxParticipants = 30,
                CurrentParticipants = 30, // Event is fully booked
                CreatedAt = DateTime.Now
            },

            new Event
            {
                Id = 2,
                Title = "Hyggefredag",
                Description = "Cozy Friday with snacks and good vibes.",
                StartDateTime = new DateTime(2026, 5, 17, 15, 00, 00),
                EndDateTime = new DateTime(2026, 5, 17, 20, 00, 00),
                Location = "Zealand Zoo Café",
                MaxParticipants = 40,
                CurrentParticipants = 0,
                CreatedAt = DateTime.Now
            },

          
        };

        /// <summary>
        /// Returns all mock events.
        /// </summary>
        /// <returns>A list of events</returns>
        public static List<Event> GetMockEvents()
        {
            return events;
        }

        /// <summary>
        /// Adds a participant to an event based on the event ID.
        /// Ensures that the event is not already fully booked.
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        public static void AddGuestToEvent(int eventId)
        {
            Event? selectedEvent = events.FirstOrDefault(e => e.Id == eventId);

            if (selectedEvent != null && selectedEvent.CurrentParticipants < selectedEvent.MaxParticipants)
            {
                selectedEvent.CurrentParticipants++;
            }
        }
    }
}