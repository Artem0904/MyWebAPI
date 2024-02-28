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
        public DateTime CookingTime { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PizzasSizeId { get; set; }
        public PizzasSize PizzasSize { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();

        //Піци
        //ід
        //назва
        //ціна
        //час приготування
        //опис
        //+категорія
    }
}
