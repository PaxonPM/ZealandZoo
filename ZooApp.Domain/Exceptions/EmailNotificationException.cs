using ZooApp.Domain.Models;

namespace ZooApp.Domain.Exceptions;

public class EmailNotificationException : Exception
{
    public Event CreatedEvent { get; }

    public EmailNotificationException(string message, Event createdEvent, Exception innerException)
        : base(message, innerException)
    {
        CreatedEvent = createdEvent;
    }
}