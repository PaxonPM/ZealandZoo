using ZealandZoo.Models;

namespace ZealandZoo.Services
    
{
    public interface IEventService
    {
        List<Event> GetEvents();
        void AddEvent(Event events);
        void UpdateEvent(Event events);
        Event GetEvent(int id);
        Event DeleteItem(int? eventId);
        IEnumerable<Event> NameSearch(string str);
     
    }
}

