using EvenueApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvenueApi.Controllers
{
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        DatabaseContext context = new DatabaseContext();

        [Route("getOrganizers")]
        [HttpGet]
        public List<Organizer> GetOrganizers()
        {
            return context.GetOrganizers();
        }
    }
}
