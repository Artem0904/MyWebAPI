using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Data
{
    public class PizzeriaDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        public PizzeriaDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pizza>().HasData(new[]
            {
                new Pizza() { Id = 1, Name = "Margherita", Price = 10, Description = "Good!"},
                new Pizza() { Id = 2, Name = "Pepperoni", Price = 12, Description = "Good!"},
                new Pizza() { Id = 3, Name = "Hawaiian", Price = 11, Description = "Cool!"},
                new Pizza() { Id = 4, Name = "Meat Lover's", Price = 13, Description = "Very good!"},
                new Pizza() { Id = 5, Name = "Veggie Supreme", Price = 11, Description = "Very good!"},
                new Pizza() { Id = 6, Name = "BBQ Chicken", Price = 12, Description = "Good!"},
                new Pizza() { Id = 7, Name = "Supreme", Price = 10, Description = "Very good!"},
                new Pizza() { Id = 8, Name = "Cheese Lover's", Price = 11, Description = "Good!"},
                new Pizza() { Id = 9, Name = "Buffalo Chicken", Price = 12, Description = "Cool!"},
                new Pizza() { Id = 10, Name = "Mediterranean ", Price = 13, Description = "Cool!"},
            });
        }
    }
}
