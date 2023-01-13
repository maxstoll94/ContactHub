namespace Contacter.Domain.Events
{
    public sealed record CompanyCreatedEvent(Guid CompanyId) : DomainEvent();
}
