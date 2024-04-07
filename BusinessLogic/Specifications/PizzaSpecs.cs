using Ardalis.Specification;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Specifications
{
    public static class PizzaSpecs
    {
        public class ById : Specification<Pizza>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.PizzaSize);
            }
        }
        public class All : Specification<Pizza>
        {
            public All()
            {
                Query.Include(x => x.PizzaSize);
            }
        }
        public class ByIds : Specification<Pizza>
        {
            public ByIds(IEnumerable<int> ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id))
                    .Include(x => x.PizzaSize);
            }
        }
    }
}