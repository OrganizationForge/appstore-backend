using Application.Common.Parameters;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class PaginationProductParameters : RequestParameters
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
    }
}
