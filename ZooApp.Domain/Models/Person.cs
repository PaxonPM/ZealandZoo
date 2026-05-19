using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PwHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsNewsLetterMember { get; set; }
        public int RoleId { get; set; } = 3; // guests
        public bool IsNewsletterMember { get; set; } = false;
    }
}
