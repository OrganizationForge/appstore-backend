using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shipping.Queries
{
    public class ShippingDTO
    {
        public string? ShippingAddress { get; set; }
        public virtual ShippingMethodDTO? ShippingMethod { get; set; }
    }
}
