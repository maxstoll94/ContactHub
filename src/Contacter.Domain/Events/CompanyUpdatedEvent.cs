namespace ContactHub.Domain.Events
{
    public sealed record CompanyUpdatedEvent(Guid CompanyId) : DomainEvent();
}
