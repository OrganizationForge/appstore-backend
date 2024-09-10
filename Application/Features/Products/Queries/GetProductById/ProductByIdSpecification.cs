using Ardalis.Specification;
using Domain.Entities.Products;

namespace Application.Features.Products.Queries.GetProductById
{
    public class ProductByIdSpecification : Specification<Product>, ISingleResultSpecification<Product>
    {
        public ProductByIdSpecification(Guid id)
        {

            Query.Where(p => p.Id == id)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Availability)
                .Include(x => x.ProductFiles);
        }
    }
}
