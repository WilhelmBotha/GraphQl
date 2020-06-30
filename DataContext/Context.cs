using System;
using System.Collections.Generic;
using System.Text;
using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace DataContext
{
    public class Context : DbContext
    {
        public DbSet<Server> Servers { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HealthCheck;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Server>().HasData(new List<Server>
            {
                new Server
                {
                    Id = "1",
                    Status = string.Empty,
                    HealthCheckUri = "http://httpstat.us/200",
                    Name = "Check 1",
                    Body = string.Empty,
                    HttpStatus = string.Empty
                },
                new Server
                {
                    Id = "2",
                    Status = string.Empty,
                    HealthCheckUri = "http://httpstat.us/202",
                    Name = "Check 2",
                    Body = string.Empty,
                    HttpStatus = string.Empty
                },
                new Server
                {
                    Id = "3",
                    Status = string.Empty,
                    HealthCheckUri = "http://httpstat.us/400",
                    Name = "Check 3",
                    Body = string.Empty,
                    HttpStatus = string.Empty
                },
                new Server
                {
                    Id = "4",
                    Status = string.Empty,
                    HealthCheckUri = "http://httpstat.us/500",
                    Name = "Check 4",
                    Body = string.Empty,
                    HttpStatus = string.Empty
                }
            });
        }
    }
}
