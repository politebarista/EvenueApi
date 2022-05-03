using EvenueApi.Controllers.Organizers;
using EvenueApi.Models;
using Json.Net;
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

        [Route("loginOrganizer")]
        [HttpPost]
        public object LoginOrganizer([FromBody]LoginOrganizerRequestBody body)
        {
            List<Organizer> organizers = context.GetOrganizers();

            Organizer? organizer = organizers.Find(organizer => organizer.ContactPersonEmail == body.ContactPersonEmail);

            object response;
            if (organizer != null)
            {
                if (organizer.Password == body.Password)
                {
                    response = organizer;
                }
                else
                {
                    response = JsonNet.Serialize(EvenueStatusCode.IncorrectPassword);
                }
            } 
            else
            {
                response = JsonNet.Serialize(EvenueStatusCode.OrganizerDontExist);
            }

            return response;
        }
    }
}
