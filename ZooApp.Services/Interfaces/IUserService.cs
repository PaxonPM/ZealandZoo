using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Domain.Models;

namespace ZooApp.Services.Interfaces
{
    public interface IUserService
    {
        User CreateUser(User newUser);
        List<Event> GetAllUsers();
        User GetByNameAndPassword(string name, string password);
    }
}
