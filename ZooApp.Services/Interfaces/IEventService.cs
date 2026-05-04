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
        Event CreateEvent(Event newEvent);
        List<Event> GetAllEvents();
        Event? GetEventById(int id);

        void SignUpForEvent(int eventId, int userId);
        void CancelSignUp(int eventId, int userId);

        bool IsUserSignedUp(int eventId, int userId);
    }
}