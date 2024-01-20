﻿using Domain.Entities;

namespace Application.Features.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double PriceBase { get; set; }
        public double Price { get; set; }
        public string? UrlImage { get; set; }
        public string? Warranty { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Availability? Availability { get; set; }
        public int Weight { get; set; }
        public int Review { get; set; }
        public double Rating { get; set; }
    }
}
