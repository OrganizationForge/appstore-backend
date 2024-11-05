using Ardalis.Specification;
using Domain.Entities;

namespace Application.Features.Categories.Queries
{
    public class ChildrenCategorySpecification : Specification<Category>
    {
        public ChildrenCategorySpecification(Guid id)
        {
            Query.Where(x => x.ParentId == id && x.DeletedDate == null)
            .Include(x => x.Childrens).Where(oi => oi.DeletedDate == null)
            .Include(x => x.Specs);
        }
    }
}
