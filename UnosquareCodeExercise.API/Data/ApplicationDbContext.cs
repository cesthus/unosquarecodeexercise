using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnosquareCodeExerciseAPI.Models;

namespace UnosquareCodeExerciseAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Barbie Developer",
                    Description = "",
                    AgeRestriccion = 12,
                    Company = "Mattel",
                    Price = new Decimal(25.99)
                },
                new Product
                {
                    Id = 2,
                    Name = "xyc",
                    Description = "",
                    AgeRestriccion = 4,
                    Company = "Marvel",
                    Price = new Decimal(75.50)
                },
                new Product
                {
                    Id = 3,
                    Name = "abc",
                    Description = "",
                    AgeRestriccion = 18,
                    Company = "Nintendo",
                    Price = new Decimal(99.99)
                }
            );
        }

        public DbSet<Product> Products { get; set; }

    }
}
