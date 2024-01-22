using EvenueApi.Controllers.Organizers;
using EvenueApi.Core.Models;
using Json.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

#nullable enable
namespace EvenueApi.Controllers
{
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        [Route("getOrganizers")]
        [HttpGet]
        public List<Organizer> GetOrganizers()
        {
            return Program.OrganizerRepository.GetOrganizers();
        }

        [Route("loginOrganizer")]
        [HttpPost]
        public object LoginOrganizer([FromBody]LoginOrganizerRequestBody body)
        {
            Organizer? organizer = Program.OrganizerRepository.GetOrganizer(body.ContactPersonEmail);

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
