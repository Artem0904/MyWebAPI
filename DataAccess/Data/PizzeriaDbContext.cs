using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Data
{
    public class PizzeriaDbContext : IdentityDbContext<Client>
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzasSize> PizzasSizes { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order> Tables { get; set; }
        public DbSet<Client> Clients { get; set; }

        public PizzeriaDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Beverage>().HasData(new[]
            {
                new Beverage { Id = 1, Name="Cola", Price = 2},
                new Beverage { Id = 2, Name="Sprite",  Price = 1},
            });

            modelBuilder.Entity<PizzasSize>().HasData(new[]
            {
                new PizzasSize { Id = 1, Diametr = 30, PriceModifier = 2},
                new PizzasSize { Id = 2, Diametr = 15,  PriceModifier = 1},
            });

            modelBuilder.Entity<Pizza>().HasData(new[]
            {
                new Pizza() { Id = 1, Name = "Margherita", Price = 10, Description = "Good!", CookingTimeMin = 30, PizzasSizeId = 1},
                new Pizza() { Id = 2, Name = "Pepperoni", Price = 12, Description = "Good!", CookingTimeMin = 30, PizzasSizeId = 1},
                new Pizza() { Id = 3, Name = "Hawaiian", Price = 11, Description = "Cool!", CookingTimeMin = 30, PizzasSizeId = 1},
                new Pizza() { Id = 4, Name = "Meat Lover's", Price = 13, Description = "Very good!", CookingTimeMin = 30, PizzasSizeId = 1},
                new Pizza() { Id = 5, Name = "Veggie Supreme", Price = 11, Description = "Very good!", CookingTimeMin = 30, PizzasSizeId = 1},
                new Pizza() { Id = 6, Name = "BBQ Chicken", Price = 12, Description = "Good!", CookingTimeMin = 30, PizzasSizeId = 1},
                new Pizza() { Id = 7, Name = "Supreme", Price = 10, Description = "Very good!", CookingTimeMin = 30, PizzasSizeId = 1},
                new Pizza() { Id = 8, Name = "Cheese Lover's", Price = 11, Description = "Good!", CookingTimeMin = 30, PizzasSizeId = 1},
                new Pizza() { Id = 9, Name = "Buffalo Chicken", Price = 12, Description = "Cool!", CookingTimeMin = 30, PizzasSizeId = 1},
                new Pizza() { Id = 10, Name = "Mediterranean", Price = 13, Description = "Cool!", CookingTimeMin = 30, PizzasSizeId = 1},
            });


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pizzeria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(str);
        }
    }
}
