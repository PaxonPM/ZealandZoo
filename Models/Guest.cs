using System.ComponentModel.DataAnnotations;

namespace ZealandZoo.Models
{
    /// <summary>
    /// Represents a guest (user) in the system.
    /// A guest can create an account and sign up for events.
    /// </summary>
    public class Guest
    {
        /// <summary>
        /// Unique ID for the guest.
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Username chosen by the guest.
        /// Must be between 1 and 20 characters.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// Password for the guest account.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Constructor used when creating a new guest with username and password.
        /// </summary>
        /// <param name="userName">The username of the guest</param>
        /// <param name="password">The password of the guest</param>
        public Guest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// Default constructor required for model binding and serialization.
        /// </summary>
        public Guest()
        {
            UserName = "";
            Password = "";
        }
    }
}