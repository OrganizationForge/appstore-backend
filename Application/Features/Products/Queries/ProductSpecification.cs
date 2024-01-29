using Ardalis.Specification;
using Domain.Entities.Products;

namespace Application.Features.Products.Queries
{
    public class ProductSpecification : Specification<Product>
    {
        public ProductSpecification(PaginationProductParameters parameters)
        {
            Query.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            if (!string.IsNullOrEmpty(parameters.ProductName))
                Query.Search(x => x.Name, "%" + parameters.ProductName + "%");

            if (!string.IsNullOrEmpty(parameters.Description))
                Query.Search(x => x.Description, "%" + parameters.Description + "%");

            if (parameters.CategoryId != null)
                Query.Where(x => x.CategoryId == parameters.CategoryId);

            if(parameters.BrandId != null)
                Query.Where(x => x.BrandId == parameters.BrandId);

            if(parameters.MinPrice != null)
                Query.Where(x => x.Price >= parameters.MinPrice && x.Price <= parameters.MaxPrice);

            Query
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Include(x => x.Availability);
        }
    }
}
 