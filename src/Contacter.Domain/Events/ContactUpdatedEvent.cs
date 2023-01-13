namespace Contacter.Domain.Events
{
    public sealed record ContactUpdatedEvent(Guid ContactId) : DomainEvent();
}
