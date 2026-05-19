using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Domain.Models;

namespace ZooApp.Data.interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User CreateUser(User entity);
        public User GetById(int id);
        public IEnumerable<User> GetAll();
        public User GetByName(string name);
        public User GetByEmail(string email);
        public User Update(User entity);
        public User Delete(int id);
    }
}

