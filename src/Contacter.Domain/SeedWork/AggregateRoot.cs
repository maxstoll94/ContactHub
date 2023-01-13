namespace Contacter.Domain.Primitives
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        protected AggregateRoot(Guid id) : base(id) {}

        /// <summary>
        /// Get all domain events associated with this entity
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents;

        /// <summary>
        /// Clear all domain events associated with this entity
        /// </summary>
        public void ClearDomainEvents() => _domainEvents.Clear();

        /// <summary>
        /// Associate a new domain event to this entity
        /// </summary>
        protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    }
}
