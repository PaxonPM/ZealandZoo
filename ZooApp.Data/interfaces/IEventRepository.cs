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
        public Event Create(Event entity);
        public Event GetById(int id);
        public IEnumerable<Event> GetAll();
        public Event Update(Event entity);
        public Event Delete(int id);
        public void AddParticipant(int eventId, int userId);
        public void RemoveParticipant(int eventId, int userId);
        public bool IsParticipant(int eventId, int userId);
    }
}

