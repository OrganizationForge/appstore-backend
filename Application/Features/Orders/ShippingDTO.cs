﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders
{
    public class ShippingDTO
    {
        public string? ShippingAddress { get; set; }
        public Guid ShippingMethodId { get; set; }

    }
}
