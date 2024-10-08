using Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity : AuditableBaseEntity<Guid>
    //public abstract class AuditableBaseEntity : BaseEntity, IAuditableBaseEntity
    {
        //public string? CreatedBy { get; set; }
        //public DateTime Created { get; set; }
        //public string? ModifiedBy { get; set; }
        //public DateTime? Modified { get; set; }
    }

    public abstract class AuditableBaseEntity<T> : BaseEntity<T>, IAuditableBaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [MaxLength(50)]
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
