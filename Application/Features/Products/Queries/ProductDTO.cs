using Application.Features.Brands.Queries;
using Application.Features.Categories.Queries;
using Domain.Entities;

namespace Application.Features.Products.Queries
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double PriceBase { get; set; }
        public double Price { get; set; }
        public string? Warranty { get; set; }
        public virtual CategoryDTO? Category { get; set; }
        public virtual BrandDTO? Brand { get; set; }
        public virtual Availability? Availability { get; set; }
        public virtual List<ProductFileDTO>? ProductFiles { get; set; }
        public int Weight { get; set; }
        public int Review { get; set; }
        public double Rating { get; set; }
    }

    public class ProductFileDTO
    {
        public string? NameImage { get; set; }
        public string? UrlImage { get; set; }
    }
}
