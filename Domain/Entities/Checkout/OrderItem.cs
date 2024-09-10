﻿using Domain.Common;
using Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Checkout
{
    public class OrderItem : AuditableBaseEntity
    {
        public Guid OrderId { get; set; }        
        public Guid ProductId { get; set; }        
        public int Quantity { get; set; }
        public decimal Price { get; set; }


        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
