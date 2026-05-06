using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Domain.Models;
namespace ZooApp.Data.MockData
{
    public class MockPersons
    {
        private static List<Person> _personList { get; set; } = new List<Person>()
        {
            new Person{Id = 1, Name = "John Doe", Email = "john.doe@example.com", PwHash = "hashedpassword", PhoneNumber = "1234567890", RoleId = 3, IsNewsletterMember = false},
            new Person{Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", PwHash = "hashedpassword", PhoneNumber = "0987654321", RoleId = 3, IsNewsletterMember = true},
            new Person{Id = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com", PwHash = "hashedpassword", PhoneNumber = "5555555555", RoleId = 3, IsNewsletterMember = false},
            new Person{Id = 4, Name = "Michael Smith", Email = "michael.smith@example.com", PwHash = "hashedpassword", PhoneNumber = "1112223333", RoleId = 2, IsNewsletterMember = true},
            new Person{Id = 5, Name = "Emma Davis", Email = "emma.davis@example.com", PwHash = "hashedpassword", PhoneNumber = "2223334444", RoleId = 3, IsNewsletterMember = false},
            new Person{Id = 6, Name = "Daniel Brown", Email = "daniel.brown@example.com", PwHash = "hashedpassword", PhoneNumber = "3334445555", RoleId = 1, IsNewsletterMember = true},
            new Person{Id = 7, Name = "Sophia Wilson", Email = "sophia.wilson@example.com", PwHash = "hashedpassword", PhoneNumber = "4445556666", RoleId = 3, IsNewsletterMember = true},
            new Person{Id = 8, Name = "James Miller", Email = "james.miller@example.com", PwHash = "hashedpassword", PhoneNumber = "5556667777", RoleId = 2, IsNewsletterMember = false}
        };




        public static List<Person> GetMockPersons()
        {
            return _personList;
        }
    }
}
