using Domain.Common;

namespace Domain.Entities
{
    public class Spec : AuditableBaseEntity
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Format { get; set; }
        public string? Description { get; set; }
        public string? Placeholder { get; set; }
        public bool Required { get; set; } = false;

        public Guid ParentId { get; set; }
        public Spec? ParentSpec { get; set; }
        public Guid CategoryId { get; set; }

        public virtual List<Spec>? Childrens { get; set; }
        public virtual Category? Category { get; set; }
    }
}
