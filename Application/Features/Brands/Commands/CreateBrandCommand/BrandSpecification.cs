using Ardalis.Specification;
using Domain.Entities;

namespace Application.Features.Brands.Commands.CreateBrandCommand
{
    public class BrandSpecification : Specification<Brand>
    {
        public BrandSpecification()
        {
            Query.Where(x => x.DeletedDate == null);
        }
    }
}
