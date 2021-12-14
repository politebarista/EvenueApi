using EvenueApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EvenueApi.Controllers
{
    [ApiController]
    public class EventsController : ControllerBase
    {
        DatabaseContext context = new DatabaseContext();

        [Route("getEvents")]
        [HttpGet]
        public List<Event> GetEvents()
        {
            List<DbEvent> dbEvents = context.GetEvents();
            List<Organizer> organizers = context.GetOrganizers();

            List<Event> events = new List<Event>();
            foreach (DbEvent dbEvent in dbEvents)
            {
                Organizer organizer = organizers.Find(organizer => dbEvent.Organizer == organizer.Id);
                events.Add(new Event(dbEvent, organizer));
            }

            return events;
        }
    }
}
