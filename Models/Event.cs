using System;
using System.ComponentModel.DataAnnotations;

namespace ZealandZoo.Models
{
    /// <summary>
    /// Represents an event in the system.
    /// An event contains information such as title, time, location,
    /// and participant limits.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Unique ID for the event.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the event.
        /// </summary>
        [Required(ErrorMessage = "Titel er påkrævet")]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Optional description of the event.
        /// </summary>
        [StringLength(255)]
        public string? Description { get; set; }

        /// <summary>
        /// The start date and time of the event.
        /// </summary>
        [Required(ErrorMessage = "Starttidspunkt er påkrævet")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The end date and time of the event.
        /// Must be later than StartTime.
        /// </summary>
        [Required(ErrorMessage = "Sluttidspunkt er påkrævet")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// The location where the event takes place.
        /// </summary>
        [StringLength(100)]
        public string? Location { get; set; }

        /// <summary>
        /// Maximum number of participants allowed for the event.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Maks antal deltagere skal være mindst 1")]
        public int MaxParticipants { get; set; }

        /// <summary>
        /// Current number of participants signed up for the event.
        /// </summary>
        public int CurrentParticipants { get; set; }

        /// <summary>
        /// Timestamp for when the event was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}