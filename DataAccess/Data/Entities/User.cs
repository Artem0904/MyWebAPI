using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Table> Tables { get; set; } = new HashSet<Table>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
