namespace Application.Features.Categories.Queries
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? UrlImage { get; set; }
        public virtual List<CategoryDTO>? ChildrenCategories { get; set; }

    }
}
