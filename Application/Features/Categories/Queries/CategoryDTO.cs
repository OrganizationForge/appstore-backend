using Domain.Entities;

namespace Application.Features.Categories.Queries
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        //public int? ParentId { get; set; }
        public virtual List<CategoryDTO>? ChildrenCategories { get; set; }

    }
}
