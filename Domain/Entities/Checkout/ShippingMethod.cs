﻿using Domain.Common;

namespace Domain.Entities.Checkout
{
    public class ShippingMethod : AuditableBaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? DeliveryTime { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Shipping>? Shippings { get; set; }
    }
}
