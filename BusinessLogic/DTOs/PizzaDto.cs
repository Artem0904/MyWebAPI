using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int CookingTimeMin { get; set; }
        public int? PizzaSizeId { get; set; }
        public int? PizzaSizeDiametr { get; set; }
    }
}
