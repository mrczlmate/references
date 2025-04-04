using System;
using Microsoft.EntityFrameworkCore;
using LegitarsasagT1.Entity;

namespace LegitarsasagT1.Repository.FlightDbContext
{
    public class FlightDbContext : DbContext
    {
        public DbSet<Airline> Airline { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Flight> Flight { get; set; }

        public FlightDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
