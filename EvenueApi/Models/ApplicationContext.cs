using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvenueApi.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(
                "server=localhost;user=root;password=root;database=evenue;",
                new MySqlServerVersion(new Version(5, 7, 21))
                );

        public List<Organizer> GetOrganizers()
        {
            return Organizers.ToList();
        }
    }
}
