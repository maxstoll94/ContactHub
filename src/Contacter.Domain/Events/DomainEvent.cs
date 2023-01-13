using Contacter.Domain.Primitives;

namespace Contacter.Domain.Events
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
