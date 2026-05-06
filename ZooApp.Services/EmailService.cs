using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services
{
    /// <summary>
    /// EmailService is responsible for sending email notifications about new events to recipients.
    /// </summary>
    public class EmailService: IEmailService
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration containing email settings.</param>
        public EmailService(IConfiguration configuration)
        {
            _host = configuration["MailTrap:Host"];
            _port = int.Parse(configuration["MailTrap:Port"]);
            _username = configuration["MailTrap:Username"];
            _password = configuration["MailTrap:Password"];
        }
        public void SendEventNotification(Event newEvent, List<Person> recipients)
        {
            using SmtpClient client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = true
            };
            foreach (Person recipient in recipients)
            {
                using MailMessage mail = new MailMessage
                {
                    From = new MailAddress("noreply@zealandzoo.dk", "Zealand Zoo"),
                    Subject = $"New Event: {newEvent.Title}",
                    Body = $"""
                    Hello {recipient.Name},


                    A new event has been created at Zealand Zoo:

                    {newEvent.Title}
                    {newEvent.Description}

                    The Event starts: {newEvent.StartDateTime:MMMM dd, yyyy HH:mm}
                    Ends: {newEvent.EndDateTime:MMMM dd, yyyy HH:mm}

                    Only {newEvent.MaxParticipants} allowed to perticipate!!


                    

                    We hope to see you at the Zealand Zoo {newEvent.Location}!

                    Best regards,
                    Zealand Zoo

                    """,
                    IsBodyHtml = false
                };
                mail.To.Add(new MailAddress(recipient.Email, recipient.Name));
                client.Send(mail);
            }

        }
    }
}
