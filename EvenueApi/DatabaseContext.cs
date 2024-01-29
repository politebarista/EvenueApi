using EvenueApi.Core.Models;
using EvenueApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// TODO: move to separate directory called something like "Data"
// TODO: is it better to return DbSet and not List? Need to check the execution time
namespace EvenueApi
{
    public class DatabaseContext : DbContext
    {
        private DbSet<Organizer> Organizers { get; set; }
        private DbSet<City> Cities { get; set; }
        private DbSet<LocalDatabaseEventDto> Events { get; set; }
        private DbSet<Customer> Customers { get; set; }
        private DbSet<LocalDatabaseTicketDto> Tickets { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(
                "server=localhost;user=root;password=root;database=evenue;",
                new MySqlServerVersion(new Version(5, 7, 21))
                );

        // ORGANIZERS ORGANIZERS ORGANIZERS ORGANIZERS ORGANIZERS ORGANIZERS

        public List<Organizer> GetOrganizers()
        {
            return Organizers.ToList();
        }

        // CITIES CITIES CITIES CITIES CITIES CITIES

        public List<City> GetCities()
        {
            return Cities.ToList();
        }

        // EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS

        public List<LocalDatabaseEventDto> GetEvents()
        {
            return Events.ToList();
        }

        // CUSTOMERS CUSTOMERS CUSTOMERS CUSTOMERS CUSTOMERS CUSTOMERS

        public List<Customer> GetCustomers()
        {
            return Customers.ToList();
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                Customers.Add(customer);
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // TICKETS TICKETS TICKETS TICKETS TICKETS TICKETS 

        public List<LocalDatabaseTicketDto> GetTickets()
        {
            return Tickets.ToList();
        }

        public bool AddTicket(LocalDatabaseTicketDto ticket)
        {
            try
            {
                Tickets.Add(ticket);
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
