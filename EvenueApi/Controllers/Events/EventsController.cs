using EvenueApi.Controllers.Cities;
using EvenueApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvenueApi.Controllers
{
    [ApiController]
    public class EventsController : ControllerBase
    {
        DatabaseContext context = new DatabaseContext();

        [Route("getEvents")]
        [HttpPost]
        public List<Event> GetEvents([FromBody]GetEventsRequestBody body)
        {
            List<DbEvent> dbEvents = context.GetEvents();
            List<Organizer> organizers = context.GetOrganizers();
            List<City> cities = context.GetCities();

            // I think the algorithm for selecting a city can be optimized
            List<DbEvent> dbEventsWithCity = body.CityId != null ? dbEvents.FindAll(dbEvent => dbEvent.City == body.CityId) : dbEvents;

            List<Event> events = new List<Event>();
            foreach (DbEvent dbEvent in dbEventsWithCity)
            {
                Organizer organizer = organizers.Find(organizer => dbEvent.Organizer == organizer.Id);
                City city = cities.Find(city => dbEvent.City == city.Id);
                events.Add(new Event(dbEvent, organizer, city));
            }

            return events;
        }
    }
}
