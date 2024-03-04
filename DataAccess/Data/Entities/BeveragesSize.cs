using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class BeveragesSize
    {
        public int Id { get; set; }
        public int Volume { get; set; }
        public decimal PriceModifier { get; set; }
        public ICollection<Beverage> Beverages { get; set; } = new HashSet<Beverage>();
    }
}
