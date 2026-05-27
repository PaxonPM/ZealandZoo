using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Domain.Models;
using System.ComponentModel.DataAnnotations;


namespace ZooApp.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for event-related business operations.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Creates a new event in the system.
        /// </summary>
        /// <param name="newEvent">The event object containing the details to be created.</param>
        /// <returns>The created event with system-generated properties (Id, CreatedAt) populated.</returns>
        /// <exception cref="ArgumentNullException">Thrown when newEvent is null.</exception>
        /// <exception cref="ValidationException">Thrown when the event data is invalid.</exception>
        Task<Event> CreateEventAsync(Event newEvent);
        Task<Event> UpdateEventAsync(Event updatedEvent);
        Task<Event?> GetEventByIdAsync(int id);
        List<Event> GetAllEvents();

        Event? GetEventById(int id);
        Event? DeleteEvent(int id);

        void SignUpForEvent(int eventId, int userId);
        void CancelSignUp(int eventId, int userId);

        bool IsUserSignedUp(int eventId, int userId);
    }
}