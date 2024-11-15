﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductItemDTO
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? PictureUrl { get; set; }
    }

}
