using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int CookingTimeMin { get; set; }
        public int PizzaSizeId { get; set; }
        public string? ImageUrl { get; set; } 
        public PizzaSize PizzaSize { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
