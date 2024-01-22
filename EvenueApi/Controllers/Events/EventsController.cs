using EvenueApi.Controllers.Cities;
using EvenueApi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvenueApi.Controllers
{
    [ApiController]
    public class EventsController : ControllerBase
    {
        [Route("getEvents")]
        [HttpPost]
        public List<Event> GetEvents([FromBody]GetEventsRequestBody body)
        {
            return Program.EventsRepository.GetEvents(body.CityId);
        }
    }
}
