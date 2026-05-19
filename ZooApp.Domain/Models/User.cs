using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZooApp.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string PwHash { get; set; }
        public string Role { get; set; }
        public bool IsNotificationActive { get; set; }

        public User() { }

        public User(string name, string email, string telefon, string pwHash, string role)
        {
            
            Name = name;
            Email = email;
            Telefon = telefon;
            PwHash = pwHash;
            Role = role;
            
        }
    }
}
