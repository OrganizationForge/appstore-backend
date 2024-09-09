using System.Security.Principal;

namespace Domain.Common.Interfaces
{
    public interface IBaseEntity
    {
        //public int Id { get; set; }
        //IReadOnlyCollection<DomainEvent> DomainEvents { get; }
        //List<DomainEvent> DomainEvents { get; }
        IReadOnlyCollection<DomainEvent> DomainEvents { get; }

        public void AddDomainEvent(DomainEvent domainEvent);
        public void RemoveDomainEvent(DomainEvent domainEvent);
        public void ClearDomainEvents();
    }

    public interface IBaseEntity<TId> : IBaseEntity
    {
        TId Id { get; }
    }


}
