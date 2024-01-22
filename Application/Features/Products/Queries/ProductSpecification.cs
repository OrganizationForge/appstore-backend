using Ardalis.Specification;
using Domain.Entities.Products;

namespace Application.Features.Products.Queries
{
    public class ProductSpecification : Specification<Product>
    {
        public ProductSpecification(int pageSize, int pageNumber, string productName, string description, double? rating)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(productName))
                Query.Search(x => x.ProductName, "%" + productName + "%");

            if (!string.IsNullOrEmpty(description))
                Query.Search(x => x.Description, "%" + description + "%");

            Query
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Include(x => x.Availability);
        }
    }
}
