using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Domain.Models;

namespace ZooApp.Services.Interfaces
{
    public interface IEventService
    {
       

        Event CreateEvent(Event newEvent);
    }
}
