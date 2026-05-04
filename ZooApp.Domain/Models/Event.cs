using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Domain.Models
{
    /// <summary>
    /// Represents a ZealandZoo event with scheduling, location, and participant information.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the unique identifier for the event.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the event.
        /// Maximum length is 50 characters.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the event.
        /// Maximum length is 255 characters.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start date and time of the event.
        /// </summary>
        [Required]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the end date and time of the event.
        /// </summary>
        [Required]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Gets or sets the physical location where the event will take place.
        /// Maximum length is 100 characters.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of participants allowed for the event.
        /// Must be greater than 0.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Max participants must be greater than 0")]
        public int MaxParticipants { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the event was created in the system.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class with specified parameters.
        /// </summary>
        /// <param name="title">The title of the event.</param>
        /// <param name="description">The description of the event.</param>
        /// <param name="startDateTime">The start date and time of the event.</param>
        /// <param name="endDateTime">The end date and time of the event.</param>
        /// <param name="location">The location where the event will take place.</param>
        /// <param name="maxParticipants">The maximum number of participants allowed.</param>
        public Event(string title, string description, DateTime startDateTime, 
            DateTime endDateTime, string location, int maxParticipants)
        {
            Title = title;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Location = location;
            MaxParticipants = maxParticipants;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// Default constructor for model binding and entity framework.
        /// </summary>
        public Event()
        {
        }

        /// <summary>
        /// Returns a string representation of the event.
        /// </summary>
        /// <returns>A formatted string containing the event's key details.</returns>
        public override string ToString()
        {
            return $"Event: {Title} at {Location} from {StartDateTime} to {EndDateTime}. Max Participants: {MaxParticipants}";
        }
    }
}
