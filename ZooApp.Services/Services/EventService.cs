using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Data.MockData;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services.Services
{
    public class EventService : IEventService
    {
        /// <summary>
        /// Dictionary that stores which users are signed up for which events.
        /// Key = eventId, Value = list of userIds.
        /// Used as a temporary solution instead of a database.
        /// </summary>
        private static Dictionary<int, List<int>> eventSignUps = new();

        //private List<Event> _events;
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Event CreateEvent(Event newEvent)
        {
            return _eventRepository.Create(newEvent);
        }

        
        /// <summary>
        /// Returns all available events.
        /// </summary>
        /// <returns>List of events</returns>
        public List<Event> GetAllEvents()
        {
            return MockEvents.GetMockEvents();
        }

        /// <summary>
        /// Finds and returns a specific event by its ID.
        /// </summary>
        /// <param name="id">The ID of the event</param>
        /// <returns>The event if found, otherwise null</returns>
        public Event? GetEventById(int id)
        {
            return MockEvents.GetMockEvents().FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Signs a user up for an event.
        /// Validates that the event exists, is not full,
        /// and that the user is not already signed up.
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        /// <param name="userId">The ID of the user</param>
        public void SignUpForEvent(int eventId, int userId)
        {
            Event? selectedEvent = GetEventById(eventId);

            if (selectedEvent == null)
            {
                throw new Exception("Eventet blev ikke fundet.");
            }

            // Ensure the event has a list of signed-up users
            if (!eventSignUps.ContainsKey(eventId))
            {
                eventSignUps[eventId] = new List<int>();
            }

            // Prevent duplicate sign-up
            if (eventSignUps[eventId].Contains(userId))
            {
                throw new Exception("Du er allerede tilmeldt dette event.");
            }

            // Check if event is full
            if (selectedEvent.CurrentParticipants >= selectedEvent.MaxParticipants)
            {
                throw new Exception("Eventet er fuldt booket.");
            }

            // Add user to event
            eventSignUps[eventId].Add(userId);
            selectedEvent.CurrentParticipants++;
        }
    }
}
