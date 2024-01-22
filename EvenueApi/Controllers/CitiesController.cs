using EvenueApi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvenueApi.Controllers
{
    [ApiController]
    public class CitiesController
    {
        
        [Route("getCities")]
        [HttpGet]
        public List<City> GetCities()
        {
            return Program.CitiesRepository.GetCities();
        }
    }
}
