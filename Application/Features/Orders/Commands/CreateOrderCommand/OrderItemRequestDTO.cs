namespace Application.Features.Orders.Commands.CreateOrderCommand
{
    public class OrderItemRequestDTO
    {
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public Guid ProductId { get; set; }
    }
}
