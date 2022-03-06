using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NamesAndTypes.Models;
using System;

namespace NamesAndTypes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<WType> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().HasIndex(n => n.NameOfWorker).IsUnique();
            builder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    NameOfWorker = "Ivan",
                    Type = "Programmer",
                    CreatedDate = DateTime.Now
                },
                new Employee
                {
                    Id = 2,
                    NameOfWorker = "Petr",
                    Type = "Builder",
                    CreatedDate = DateTime.Now
                },
                new Employee
                {
                    Id = 3,
                    NameOfWorker = "Vailiy",
                    Type = "Police",
                    CreatedDate = DateTime.Now
                },
                new Employee
                {
                    Id = 4,
                    NameOfWorker = "Kolia",
                    Type = "Officer",
                    CreatedDate = DateTime.Now
                },
                new Employee
                {
                    Id = 5,
                    NameOfWorker = "George",
                    Type = "Medical",
                    CreatedDate = DateTime.Now
                },
                new Employee
                {
                    Id = 6,
                    NameOfWorker = "Olga",
                    Type = "Worker",
                    CreatedDate = DateTime.Now
                },
                new Employee
                {
                    Id = 7,
                    NameOfWorker = "Aria",
                    Type = "Programmer",
                    CreatedDate = DateTime.Now
                }
            );

            builder.Entity<WType>().HasData(
                new WType
                {
                    Id = 1,
                    Type = "Programmer",
                    CreatedDate = DateTime.Now
                },
                new WType
                {
                    Id = 2,
                    Type = "Builder",
                    CreatedDate = DateTime.Now
                },
                new WType
                {
                    Id = 3,
                    Type = "Police",
                    CreatedDate = DateTime.Now
                },
                new WType
                {
                    Id = 4,
                    Type = "Officer",
                    CreatedDate = DateTime.Now
                },
                new WType
                {
                    Id = 5,
                    Type = "Worker",
                    CreatedDate = DateTime.Now
                },
                new WType
                {
                    Id = 6,
                    Type = "Medical",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
