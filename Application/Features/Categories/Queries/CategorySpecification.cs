using Ardalis.Specification;
using Domain.Entities;

namespace Application.Features.Categories.Queries
{
    public class CategorySpecification : Specification<Category>
    {
        public CategorySpecification()
        {
            Query.Where(x => x.ParentId == null && x.DeletedDate == null)
            .Include(x => x.Childrens).Where(oi => oi.DeletedDate == null)
            .Include(x => x.Specs);
        }
    }
}
