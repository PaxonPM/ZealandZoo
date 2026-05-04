using System.ComponentModel.DataAnnotations;

namespace ZealandZoo.Models
{
    public class Guest
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();

        public Guest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public Guest()
        {
            UserName = "";
            Password = "";
        }
    }
}