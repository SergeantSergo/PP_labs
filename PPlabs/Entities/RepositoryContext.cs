using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        //    modelBuilder.ApplyConfiguration(new PartWorldConfiguration());
        //    modelBuilder.ApplyConfiguration(new CountryConfiguration());
        //    modelBuilder.ApplyConfiguration(new CityConfiguration());
        //    modelBuilder.ApplyConfiguration(new HotelConfiguration());
        //    modelBuilder.ApplyConfiguration(new TicketConfiguration());
        }
        //public DbSet<Company> Companies { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<PartWorld> PartWorlds { get; set; }
        //public DbSet<Country> Countries { get; set; }
        //public DbSet<City> Cities { get; set; }
        //public DbSet<Hotel> Hotels { get; set; }
        //public DbSet<Ticket> Ticket { get; set; }

    }
}
