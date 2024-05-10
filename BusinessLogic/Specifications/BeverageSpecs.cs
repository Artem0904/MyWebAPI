using Ardalis.Specification;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLogic.Specifications
{
    public class BeverageSpecs
    {
        public class ById : Specification<Beverage>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id);
            }
        }
        public class All : Specification<Beverage>
        {
            public All()
            {
                //Query.Include(x => x.PizzaSize);
               
            }
        }
        public class ByIds : Specification<Beverage>
        {
            public ByIds(IEnumerable<int> ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id));
            }
        }
    }
}
