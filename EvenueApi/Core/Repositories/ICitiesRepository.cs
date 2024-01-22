using EvenueApi.Core.Models;
using System.Collections.Generic;

namespace EvenueApi.Core.Repositories
{
    internal interface ICitiesRepository
    {
        public List<City> GetCities();
        public List<City> GetCities(string countryId);

    }
}
