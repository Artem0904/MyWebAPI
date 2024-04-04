using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int CountChairs { get; set; }
        public bool IsReserved { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
