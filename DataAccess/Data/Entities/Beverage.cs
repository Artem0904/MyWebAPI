using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Beverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price {  get; set; }
        public int BeveragesSizeId { get; set; }
        public BeveragesSize BeveragesSize { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}
