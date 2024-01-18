using Domain.Common.Interfaces;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity:BaseEntity, IAuditableBaseEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }
    }
}
