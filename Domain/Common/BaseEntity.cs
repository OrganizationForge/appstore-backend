using Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Common
{
    public abstract class BaseEntity : BaseEntity<Guid>
    //public abstract class BaseEntity: IBaseEntity

    {
        protected BaseEntity() => Id = new Guid();
        //[JsonIgnore]
        //private readonly List<BaseEvent> _domainEvents = new();

        //public int Id { get; set; }

        //[NotMapped]
        //public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

        //public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
        //public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
        //public void ClearDomainEvents() => _domainEvents.Clear();
    }

    public abstract class BaseEntity<TId> : IBaseEntity<TId>
    {
        [JsonIgnore]
        private readonly List<DomainEvent> _domainEvents = new();
        public TId Id { get; protected set; } = default!;

        //[NotMapped]
        //public List<DomainEvent> DomainEvents { get; } = new();

        [NotMapped]
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void RemoveDomainEvent(DomainEvent domainEvent) => _domainEvents.Remove(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
