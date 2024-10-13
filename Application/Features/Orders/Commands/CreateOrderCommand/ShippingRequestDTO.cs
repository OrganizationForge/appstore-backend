namespace Application.Features.Orders.Commands.CreateOrderCommand
{
    public class ShippingRequestDTO
    {
        public string ShippingAddress { get; set; }
        public Guid shippingMethodId { get; set; }
    }
}
