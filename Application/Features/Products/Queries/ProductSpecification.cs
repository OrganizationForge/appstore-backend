using Ardalis.Specification;
using Domain.Entities.Products;

namespace Application.Features.Products.Queries
{
    public class ProductSpecification : Specification<Product>
    {
        public ProductSpecification(int pageSize, int pageNumber, string productName, string description, double? rating, int? categoryId, int? brandId  )
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(productName))
                Query.Search(x => x.Name, "%" + productName + "%");

            if (!string.IsNullOrEmpty(description))
                Query.Search(x => x.Description, "%" + description + "%");

            if (categoryId != null)
                Query.Where(x => x.CategoryId == categoryId);

            if(brandId != null)
                Query.Where(x => x.BrandId == brandId);

            Query
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Include(x => x.Availability);
        }
    }
}
 