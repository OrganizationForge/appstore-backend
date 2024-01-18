using Domain.Common;

namespace Domain.Entities.Library
{
    public class Idiom : AuditableBaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
