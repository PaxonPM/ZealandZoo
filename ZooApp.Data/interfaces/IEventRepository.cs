using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Domain.Models;

namespace ZooApp.Data.interfaces
{
    public interface IEventRepository : IBaseRepository<Event>
    {

        public string Create(Event entity);
        public Event GetById(int id);
        public IEnumerable<Event> GetAll();
        public string Update(Event entity);
        public string Delete(int id);
    }
}
