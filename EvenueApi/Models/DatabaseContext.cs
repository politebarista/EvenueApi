using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvenueApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<DbEvent> Events { get; set; }
        public DbSet<Customer> Customers { get; set; }

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

        public List<DbEvent> GetEvents()
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
    }
}
