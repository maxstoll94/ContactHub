namespace ContactHub.Domain.Events
{
    public sealed record CompanyCreatedEvent(Guid CompanyId) : DomainEvent();
}
