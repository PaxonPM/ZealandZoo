using System.ComponentModel.DataAnnotations;

namespace ZooApp.Domain.Models
{
    /// <summary>
    /// Represents a guest (user) in the system.
    /// A guest can create an account and sign up for events.
    /// </summary>
    public class GuestModel
    {
        /// <summary>
        /// Unique ID for the guest.
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Username chosen by the guest.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// Email address used for login.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Password for the guest account.
        /// </summary>
        [Required]
        public string Password { get; set; }

        public bool IsNewsletterMember { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();

        /// <summary>
        /// Constructor used when creating a new guest.
        /// </summary>
        public GuestModel(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Default constructor required for model binding and serialization.
        /// </summary>
        public GuestModel()
        {
            UserName = "";
            Email = "";
            Password = "";
        }
    }
}