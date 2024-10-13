using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrderPdfQuery.ViewModels
{
    public class ShippingViewModel
    {
        public string? ShippingMethod { get; set; }
        public string? ShippingAddress { get; set; }
    }

}
