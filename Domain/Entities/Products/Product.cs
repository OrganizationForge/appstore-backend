using Domain.Common;

namespace Domain.Entities.Products
{
    public class Product : AuditableBaseEntity
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double PriceBase { get; set; }
        public double Price { get; set; } 
        public string? UrlImage { get; set; }
        public int? BrandId { get; set; }
        public int? AvailabilityId { get; set; }
        public int? CategoryId { get; set; }
        public string? Warranty { get; set; } = "1 año";
        public int Weight { get; set; }
        public int Review { get; set; } = 0;
        public double Rating { get; set; } = 0;


        public virtual Category? Category { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Availability? Availability { get; set; } // Propiedad de navegación hacia la disponibilidad
    }
}
