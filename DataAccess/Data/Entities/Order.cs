using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Pizza> Pizzas { get; set; } = new HashSet<Pizza>();
        public ICollection<Beverage> Beverages { get; set; } = new HashSet<Beverage>();

    }
}
