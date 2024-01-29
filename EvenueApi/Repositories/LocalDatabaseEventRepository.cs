using EvenueApi.Core.Models;
using EvenueApi.Core.Repositories;
using EvenueApi.Models;
using System;
using System.Collections.Generic;

namespace EvenueApi.Repositories
{
    public class LocalDatabaseEventRepository : IEventsRepository
    {
        DatabaseContext context = new DatabaseContext();

        void IEventsRepository.CreateEvent(Event Event)
        {
            throw new NotImplementedException();
        }

        Event IEventsRepository.GetEvent(string eventId)
        {
            if (eventId == null) 
            { 
                return null; 
            }

            LocalDatabaseEventDto eventDto = context.GetEvents().Find((LocalDatabaseEventDto eventDto) => eventDto.Id == eventId);

            if (eventDto == null)
            {
                return null;
            }

            Organizer organizer = context.GetOrganizers().Find(city => eventDto.City == city.Id);
            City city = context.GetCities().Find(city => eventDto.City == city.Id);
            Event Event = new(eventDto.Id, eventDto.Name, eventDto.Description, eventDto.ImageUrl, eventDto.OldPrice, eventDto.Price, eventDto.StartDate, eventDto.EndDate, organizer, city, eventDto.ParticipantsMaxNumber);

            return Event;
        }

        List<Event> IEventsRepository.GetEvents(string cityId)
        {
            List<LocalDatabaseEventDto> dbEvents = context.GetEvents();
            List<Organizer> organizers = context.GetOrganizers();
            List<City> cities = context.GetCities();
            
            // I think the algorithm for selecting a city can be optimized
            List<LocalDatabaseEventDto> dbEventsWithCity = cityId != null ? dbEvents.FindAll(dbEvent => dbEvent.City == cityId) : dbEvents;

            List<Event> events = new();
            foreach (LocalDatabaseEventDto dbEvent in dbEventsWithCity)
            {
                Organizer organizer = organizers.Find(organizer => dbEvent.Organizer == organizer.Id);
                City city = cities.Find(city => dbEvent.City == city.Id);
                events.Add(new Event(dbEvent.Id, dbEvent.Name, dbEvent.Description, dbEvent.ImageUrl, dbEvent.OldPrice, dbEvent.Price, dbEvent.StartDate, dbEvent.EndDate, organizer, city, dbEvent.ParticipantsMaxNumber));
            }

            return events;
        }

        void IEventsRepository.UpdateEvent(Event Event)
        {
            throw new NotImplementedException();
        }
    }
}
