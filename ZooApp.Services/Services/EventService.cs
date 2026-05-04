using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services.Services
{
    public class EventService : IEventService
    {
        //private List<Event> _events;
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Event CreateEvent(Event newEvent)
        {
            return _eventRepository.Create(newEvent);
        }
    }
}
