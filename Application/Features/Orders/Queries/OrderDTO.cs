using Application.Features.Payments.Queries;
using Application.Features.Shipping.Queries;

namespace Application.Features.Orders.Queries
{
    public class OrderDTO
    {
        public Guid UserId { get; set; }
        public int Status { get; set; }
        public PaymentDTO? Payment { get; set; }
        public ShippingDTO? Shipping { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }
}
