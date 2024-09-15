using Application.Common.Parameters;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class PaginationProductParameters : RequestParameters
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? Rating { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
