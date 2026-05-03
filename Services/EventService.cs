using ZealandZoo.Models;
using ZealandZoo.MockData;
namespace ZealandZoo.Services
   
{
    public class EventService : IEventService
    {
        private List<Event> _events;

        private JsonFileEventService JsonFileEventService { get; set; }

        public EventService(JsonFileEventService jsonFileEventService)
        {
            JsonFileEventService = jsonFileEventService;
            // _items = MockItems.GetMockItems();
            _events = JsonFileEventService.GetJsonEvents().ToList();
        }

        public EventService()
        {
            _events = MockEvent.GetMockEvents();
        }

        public void AddEvent(Event events)
        {
            _events.Add(events);
            JsonFileEventService.SaveJsonEvents(events);
        }

        public Event GetEvent(int id)
        {
            foreach (Event events in _events)
            {
                if (events.Id == id)
                    return events;
            }

            return null;
        }

        public void UpdateEvent(Event events)
        {
            if (events != null)
            {
                foreach (Event e in _events)
                {
                    if (e.Id == events.Id)
                    {
                        e.Title = events.Title;
                        e.Id = events.Id;
                    }
                }
                JsonFileEventService.SaveJsonEvents(_events);
            }
        }

        public Event DeleteItem(int? eventId)
        {
            Event eventToBeDeleted = null;
            foreach (Event events in _events)
            {
                if (events.Id == eventId)
                {
                    eventToBeDeleted = events;
                    break;
                }
            }

            if (eventToBeDeleted != null)
            {
                _events.Remove(eventToBeDeleted);
                JsonFileEventService.SaveJsonEvents(_events);
            }

            return eventToBeDeleted;
        }

        public List<Event> GetEvents() { return _events; }

        public IEnumerable<Event> NameSearch(string str)
        {
            List<Event> nameSearch = new List<Event>();
            foreach (Event events in _events)
            {
                if (string.IsNullOrEmpty(str) || events.Title.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(events);
                }
            }

            return nameSearch;
        }

    }
}
