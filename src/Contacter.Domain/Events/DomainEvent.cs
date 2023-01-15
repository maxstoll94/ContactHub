using ContactHub.Domain.SeedWork;

namespace ContactHub.Domain.Events
{
    public abstract record DomainEvent : IDomainEvent
    {
        public Guid Id { get; init; }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
        }
    }
}
