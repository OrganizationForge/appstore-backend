﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shippings.Queries
{
    public class ShippingMethodDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? DeliveryTime { get; set; }
        public decimal Price { get; set; }
    }
}