using Domain.Entities;

namespace Application.Features.Categories.Queries
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? UrlImage { get; set; }
        public virtual List<CategoryDTO>? Childrens { get; set; }
        public virtual List<Spec>? Specs { get; set; }

    }
}
