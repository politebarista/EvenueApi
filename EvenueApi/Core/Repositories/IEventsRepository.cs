using EvenueApi.Core.Models;
using System.Collections.Generic;

namespace EvenueApi.Core.Repositories
{
    internal interface IEventsRepository
    {
        public void CreateEvent(Event Event);
        public void UpdateEvent(Event Event);
        public void DeleteEvent(Event Event);
        public List<Event> GetEvents(string cityId);
        public Event GetEvent(string id);
    }
}
