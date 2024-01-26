using EvenueApi.Core.Models;
using EvenueApi.Core.Repositories;
using EvenueApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenueApi.Repositories
{
    public class LocalDatabaseEventRepository : IEventsRepository
    {
        DatabaseContext context = new DatabaseContext();

        void IEventsRepository.CreateEvent(Event Event)
        {
            throw new NotImplementedException();
        }

        void IEventsRepository.DeleteEvent(Event Event)
        {
            throw new NotImplementedException();
        }

        Event IEventsRepository.GetEvent(string id)
        {
            throw new NotImplementedException();
        }

        List<Event> IEventsRepository.GetEvents(string cityId)
        {
            List<LocalDatabaseEventDto> dbEvents = context.GetEvents();
            List<Organizer> organizers = context.GetOrganizers();
            List<City> cities = context.GetCities();
            
            // I think the algorithm for selecting a city can be optimized
            List<LocalDatabaseEventDto> dbEventsWithCity = cityId != null ? dbEvents.FindAll(dbEvent => dbEvent.City == cityId) : dbEvents;

            List<Event> events = new List<Event>();
            foreach (LocalDatabaseEventDto dbEvent in dbEventsWithCity)
            {
                Organizer organizer = organizers.Find(organizer => dbEvent.Organizer == organizer.Id);
                City city = cities.Find(city => dbEvent.City == city.Id);
                events.Add(new Event(dbEvent.Id, dbEvent.Name, dbEvent.Description, dbEvent.ImageUrl, dbEvent.OldPrice, dbEvent.Price, dbEvent.StartDate, dbEvent.EndDate, organizer, city));
            }

            return events;
        }

        void IEventsRepository.UpdateEvent(Event Event)
        {
            throw new NotImplementedException();
        }
    }
}
