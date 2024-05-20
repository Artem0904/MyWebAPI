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
    public class PizzeriaDbContext : IdentityDbContext<User>
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaSize> PizzaSizes { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order> Tables { get; set; }
        public DbSet<User> Users { get; set; }

        public PizzeriaDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Beverage>().HasData(new[]
            {
                new Beverage { Id = 1, Name="Cola", Price = 2, ImageUrl="https://cooker.net.ua/upload/iblock/74b/bezalkogolniy-napiy-coca-cola-0-5l-720.jpg"},
                new Beverage { Id = 2, Name="Sprite",  Price = 1, ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSARjshJFLu9f9_xccsPoCJ3zJirTZUpkpbmq09lyHSKQ&s"},
            });

            modelBuilder.Entity<PizzaSize>().HasData(new[]
            {
                new PizzaSize { Id = 1, Diametr = 10, PriceModifier = 1},
                new PizzaSize { Id = 2, Diametr = 30,  PriceModifier = 3},
                new PizzaSize { Id = 3, Diametr = 50,  PriceModifier = 5},
            });

            modelBuilder.Entity<Pizza>().HasData(new[]
            {
                new Pizza() { Id = 1, Name = "Margherita", Price = 10, Description = "Good!", CookingTimeMin = 30, PizzaSizeId = 1, ImageUrl = "https://cdn-media.choiceqr.com/prod-eat-daniel/menu/WBVaHGW-ZebYFtz-ElCGTTn.jpeg.webp"},
                new Pizza() { Id = 2, Name = "Pepperoni", Price = 12, Description = "Good!", CookingTimeMin = 30, PizzaSizeId = 1, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTC62Kv77j7QsJKmILnpQdH3-CQIOv5t5IBo76J92wlMw&s"},
                new Pizza() { Id = 3, Name = "Hawaiian", Price = 11, Description = "Cool!", CookingTimeMin = 30, PizzaSizeId = 1, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1jL7WrrC5pn9jvj6Dy8pHk5atBIgbruTcpSjp5Z_ZBg&s"},
                new Pizza() { Id = 4, Name = "Meat Lover's", Price = 13, Description = "Very good!", CookingTimeMin = 30, PizzaSizeId = 1, ImageUrl = "https://www.vincenzosplate.com/wp-content/uploads/2021/08/610x350-Photo-5_863-How-to-Make-MEATLOVERS-PIZZA-Like-an-Italian-V1.jpg"},
                new Pizza() { Id = 5, Name = "Veggie Supreme", Price = 11, Description = "Very good!", CookingTimeMin = 30, PizzaSizeId = 1, ImageUrl = "https://www.nordicware.com/wp-content/uploads/2021/05/46400_traditional_pizza_pan_02_e.jpg"},
                new Pizza() { Id = 6, Name = "BBQ Chicken", Price = 12, Description = "Good!", CookingTimeMin = 30, PizzaSizeId = 1, ImageUrl = "https://breadboozebacon.com/wp-content/uploads/2023/05/BBQ-Chicken-Pizza-SQUARE.jpg"},
                new Pizza() { Id = 7, Name = "Supreme", Price = 10, Description = "Very good!", CookingTimeMin = 30, PizzaSizeId = 1, ImageUrl = "https://napolipizzalv.com/wp-content/uploads/2019/10/DSC_0905-min.png"},
                new Pizza() { Id = 8, Name = "Cheese Lover's", Price = 11, Description = "Good!", CookingTimeMin = 30, PizzaSizeId = 1, ImageUrl = "https://www.shutterstock.com/image-photo/cheese-pizza-lovers-600nw-1101316754.jpg"},
                new Pizza() { Id = 9, Name = "Buffalo Chicken", Price = 12, Description = "Cool!", CookingTimeMin = 30, PizzaSizeId = 1, ImageUrl = "https://embed.widencdn.net/img/mccormick/7kdrro9xb6/840x840px/Frank's%20RedHot%20Buffalo%20Chicken%20Pizza_2019-05-24_TSUCALAS_%209544.jpg?crop=true&q=80&u=1zsthd"},
                new Pizza() { Id = 10, Name = "Mediterranean", Price = 13, Description = "Cool!", CookingTimeMin = 30, PizzaSizeId = 1, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrWMdEcEua1Z2_aOnTZEJ3IC2uHqnvm7JjOywmFHr9LQ&s"},
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
