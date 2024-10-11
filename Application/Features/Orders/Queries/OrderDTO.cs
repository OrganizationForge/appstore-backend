using Application.Features.Payments.Queries;
using Application.Features.Shipping.Queries;

namespace Application.Features.Orders.Queries
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        //public Guid UserId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }
        public PaymentDTO? Payment { get; set; }
        public ShippingDTO? Shipping { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }
}
