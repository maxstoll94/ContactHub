﻿namespace Contacter.Domain.Events
{
    public sealed record ContactCreatedEvent(Guid ContactId) : DomainEvent();
}
