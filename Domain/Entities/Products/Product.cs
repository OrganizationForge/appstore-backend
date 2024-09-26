using Domain.Common;

namespace Domain.Entities.Products
{
    public class Product : AuditableBaseEntity
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal PriceBase { get; set; }
        public decimal Price { get; set; } 
        public Guid BrandId { get; set; }
        public Guid AvailabilityId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid QuantityTypeId { get; set; }
        public string? Warranty { get; set; } = "1 año";
        public int Weight { get; set; }
        public int Review { get; set; } = 0;
        public decimal Rating { get; set; } = 0;
        public string? BarCode { get; set; }
        public decimal Stock { get; set; }


        public virtual Category? Category { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Availability? Availability { get; set; } 
        public virtual QuantityType? QuantityType { get; set; }
        public virtual List<ProductFile>? ProductFiles { get; set; }
        public virtual List<Comment>? Comments { get; set; }
    }
}
