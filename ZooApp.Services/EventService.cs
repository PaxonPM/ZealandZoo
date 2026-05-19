using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Data.MockData;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services
{
    public class EventService : IEventService
    {
        //private List<Event> _events;
        private readonly IEventRepository _eventRepository;
        private readonly IEmailService _emailService;
        private readonly IPersonService _personService;

        public EventService(IEventRepository eventRepository, IEmailService emailService, IPersonService personService)
        {
            _eventRepository = eventRepository;
            _emailService = emailService;
            _personService = personService;
        }

        public async Task<Event> CreateEventAsync(Event newEvent)
        {
            Event created = _eventRepository.Create(newEvent);

            try
            {
                List<Person> newsletterMembers = _personService.GetNewsletterMembers();
                await _emailService.SendEventNotificationAsync(created, newsletterMembers);
            }
            catch (Exception ex)
            {
                // Log the exception (for demonstration, we just write to console)
                Console.WriteLine($"Failed to send event notification emails: {ex.Message}");
            }
            return created;
        }

        
        /// <summary>
        /// Returns all available events.
        /// </summary>
        /// <returns>List of events</returns>
        public List<Event> GetAllEvents()
        {
            return _eventRepository.GetAll().ToList();


        }

        /// <summary>
        /// Finds and returns a specific event by its ID.
        /// </summary>
        /// <param name="id">The ID of the event</param>
        /// <returns>The event if found, otherwise null</returns>
        public Event? GetEventById(int id)
        {
            return _eventRepository.GetById(id);
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
                throw new Exception("Eventet blev ikke fundet.");

            if (_eventRepository.IsParticipant(eventId, userId))
                throw new Exception("Du er allerede tilmeldt dette event.");

            if (selectedEvent.CurrentParticipants >= selectedEvent.MaxParticipants)
                throw new Exception("Eventet er fuldt booket.");

            _eventRepository.AddParticipant(eventId, userId);
        }

        public void CancelSignUp(int eventId, int userId)
        {
            Event? selectedEvent = GetEventById(eventId);

            if (selectedEvent == null)
                throw new Exception("Eventet blev ikke fundet.");

            if (!_eventRepository.IsParticipant(eventId, userId))
                throw new Exception("Du er ikke tilmeldt dette event.");

            _eventRepository.RemoveParticipant(eventId, userId);
        }

        /// <summary>
        /// Checks if a user is already signed up for an event.
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        /// <param name="userId">The ID of the user</param>
        /// <returns>True if the user is signed up, otherwise false</returns>
        public bool IsUserSignedUp(int eventId, int userId)
        {
            return _eventRepository.IsParticipant(eventId, userId);
        }
    }
}