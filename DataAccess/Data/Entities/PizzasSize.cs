using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class PizzasSize
    {
        public int Id {  get; set; }
        public int Diametr {  get; set; }
        public decimal PriceModifier { get; set; }
        public ICollection<Pizza>? Pizzas { get; set; } = new HashSet<Pizza>();

    }
}
