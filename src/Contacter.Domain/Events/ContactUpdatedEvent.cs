namespace ContactHub.Domain.Events
{
    public sealed record ContactUpdatedEvent(Guid ContactId) : DomainEvent();
}
