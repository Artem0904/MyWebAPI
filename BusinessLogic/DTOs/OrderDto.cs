namespace BusinessLogic.DTOs
{
    public class OrderDto 
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int ClientId { get; set; }
    }
}
