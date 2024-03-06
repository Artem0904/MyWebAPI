using DataAccess.Data.Entities;

namespace BusinessLogic.DTOs
{
    public class PizzasSizeDto
    {
        public int Id { get; set; }
        public int Diametr { get; set; }
        public decimal PriceModifier { get; set; }
    }
}
