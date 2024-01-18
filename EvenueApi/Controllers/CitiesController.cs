using EvenueApi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvenueApi.Controllers
{
    [ApiController]
    public class CitiesController
    {
        private DatabaseContext context = new DatabaseContext();
        
        [Route("getCities")]
        [HttpGet]
        public List<City> GetCities()
        {
            return context.GetCities();
        }
    }
}
