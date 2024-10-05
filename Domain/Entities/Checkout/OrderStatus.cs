﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Checkout
{
    public enum OrderStatus
    {
        New = 1,
        Pending = 2, 
        Completed = 3, 
        Cancelled = 4
    }
}
 