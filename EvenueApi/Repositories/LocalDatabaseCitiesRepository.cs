using EvenueApi.Core.Models;
using EvenueApi.Core.Repositories;
using System.Collections.Generic;

namespace EvenueApi.Repositories
{
    internal class LocalDatabaseCitiesRepository : ICitiesRepository
    {
        DatabaseContext context = new DatabaseContext();
        List<City> ICitiesRepository.GetCities()
        {
            return context.GetCities();
        }

        List<City> ICitiesRepository.GetCities(string countryId)
        {
            throw new System.NotImplementedException();
        }
    }
}
