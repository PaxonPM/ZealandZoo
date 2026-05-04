using ZooApp.Domain.Models;

namespace ZooApp.Data.MockData
{
    public static class AdminMock
    {
        public static List<Admin> Admins = new List<Admin>
        {
            new Admin { Id = 1, Username = "admin", Password = "1234" }
        };
    }
}
