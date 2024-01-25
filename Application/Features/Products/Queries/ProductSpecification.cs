using Ardalis.Specification;
using Domain.Entities.Products;

namespace Application.Features.Products.Queries
{
    public class ProductSpecification : Specification<Product>
    {
        public ProductSpecification(int pageSize, int pageNumber, string productName, string description, double? rating, int? categoryId)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(productName))
                Query.Search(x => x.ProductName, "%" + productName + "%");

            if (!string.IsNullOrEmpty(description))
                Query.Search(x => x.Description, "%" + description + "%");

            if (categoryId != null)
                Query.Where(x => x.CategoryId == categoryId);

            Query
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Include(x => x.Availability);
        }
    }
}
