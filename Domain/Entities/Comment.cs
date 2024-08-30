using Domain.Common;
using Domain.Entities.Products;

namespace Domain.Entities
{
    public class Comment : AuditableBaseEntity
    {
        public string? CustomerName { get; set; }
        public string? Content { get; set; }
        public string? CustomerImage { get; set; } = "assets/img/shop/reviews/01.jpg";
        public string? Pros { get; set; }
        public string? Cons { get; set; }
        public int Rating { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public int ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
