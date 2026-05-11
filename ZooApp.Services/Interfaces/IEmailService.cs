using ZooApp.Domain.Models;

namespace ZooApp.Services.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email notification to the specified recipients about a new event.
        /// </summary>
        /// <param name="newEvent">The event information to include in the email.</param>
        /// <param name="recipients">The list of recipients to send the email to.</param>
        Task SendEventNotificationAsync(Event newEvent, List<Person> recipients);
    }
}
