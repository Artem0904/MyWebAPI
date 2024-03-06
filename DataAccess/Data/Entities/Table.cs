using Microsoft.Identity.Client;
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
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
