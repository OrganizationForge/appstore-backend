using Ardalis.Specification;
using Domain.Entities;

namespace Application.Features.Categories.Queries
{
    public class CategorySpecification : Specification<Category>
    {
        public CategorySpecification()
        {
            Query.Where(x => x.ParentId == null)
            .Include(x => x.Childrens)
            .Include(x => x.Specs);
        }
    }
}
