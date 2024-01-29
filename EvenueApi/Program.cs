using EvenueApi.Core.Repositories;
using EvenueApi.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvenueApi
{
    public class Program
    {
        internal static IEventsRepository EventsRepository;
        internal static ICustomerRepository CustomersRepository;
        internal static ICitiesRepository CitiesRepository;
        internal static IOrganizerRepository OrganizerRepository;
        internal static ITicketsRepository TicketsRepository;

        public static void Main(string[] args)
        {
            EventsRepository = new LocalDatabaseEventRepository();
            CustomersRepository = new LocalDatabaseCustomerRepository();
            CitiesRepository = new LocalDatabaseCitiesRepository();
            OrganizerRepository = new LocalDatabaseOrganizerRepository();
            TicketsRepository = new LocalDatabaseTicketsRepository(EventsRepository, CustomersRepository);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
