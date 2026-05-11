using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Domain.Models;

namespace ZooApp.Data.MockData
{
    public class MockUser
    {
        private static List<User> users = new List<User>
        {

            new User(1, "Lucas", "Lucas@email.com", "1813", "hashedpassword1", "Staff", true)
            {
                PwHash = "hashedpassword1"
            },
            new User(2, "Frederik", "Frederik@email.com", "911",  "hashedpassword2", "Student", false)
            {
                PwHash = "hashedpassword2"
            },
            new User(3, "Paw", "Paw@email.com", "112", "hashedpassword3", "Admin", true)
            {
                PwHash = "hashedpassword2"
            },
            new User(4, "Nikolai", "Nikolai@email.com", "114","hashedpassword4", "Staff", true)
            {
                PwHash = "hashedpassword4"
            }

        };
    }
}
