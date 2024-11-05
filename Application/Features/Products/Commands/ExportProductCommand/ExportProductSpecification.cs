using Ardalis.Specification;
using Domain.Entities.Products;

namespace Application.Features.Products.Commands.ExportProductCommand
{
    public class ExportProductSpecification : Specification<Product>
    {
        public ExportProductSpecification(ExportProductCommand request)
        {
            Query
            .Where(p => p.Rating >= request.MinimumRate!.Value, request.MinimumRate.HasValue)
            .Where(p => p.Rating <= request.MaximumRate!.Value, request.MaximumRate.HasValue);
        }
    }
}
