using EvenueApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvenueApi.Controllers
{
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        ApplicationContext context = new ApplicationContext();

        [Route("[controller]")]
        [HttpGet]
        public List<Organizer> Get()
        {
            var some = context.GetOrganizers();
            return some;
        }

        [Route("stop")]
        [HttpGet]
        public string Stop()
        {
            return "stop";
        }
    }
}
