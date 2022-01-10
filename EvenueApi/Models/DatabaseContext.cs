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
        public DbSet<DbEvent> Events { get; set; }
        public DbSet<User> Users { get; set; }

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

        // EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS

        public List<DbEvent> GetEvents()
        {
            return Events.ToList();
        }

        // USERS USERS USERS USERS USERS USERS USERS

        public List<User> GetUsers()
        {
            return Users.ToList();
        }
    }
}
