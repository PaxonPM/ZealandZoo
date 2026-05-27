using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Domain.Models;
using ZooApp.Data.MockData;

namespace ZooApp.Data.MockData
{
    public class MockUser
    {
        private static List<UserModel> users = new List<UserModel>
        {
            new UserModel("Lucas", "Lucas@email.com", "1813", "hashedpassword1", 3, true),
            new UserModel("Frederik", "Frederik@email.com", "911",  "hashedpassword2", 3, false),
            new UserModel("Paw", "Paw@email.com", "112", "hashedpassword3", 1, true),
            new UserModel("Nikolai", "Nikolai@email.com", "114","hashedpassword4", 2, false)

        };
        public static List<UserModel> GetMockUsers()
        {
            return users;
        }
    }
}
