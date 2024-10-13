using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrderPdfQuery.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
        public PaymentViewModel? Payment { get; set; }
        public ShippingViewModel? Shipping { get; set; }
        public List<OrderItemViewModel>? OrderItems { get; set; }
    }

}
