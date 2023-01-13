using Contacter.Domain.Events;
using Contacter.Domain.Primitives;
using Contacter.Domain.ValueObjects;

namespace Contacter.Domain.Entities
{
    public class Company : AggregateRoot
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }
        public DateTimeOffset? UpdatedOn { get; private set; }

        // EF Core Constructor
        private Company(Guid id, string name) : base(id)
        {
            Name = name;
            CreatedOn = DateTimeOffset.UtcNow;

            RaiseDomainEvent(new CompanyCreatedEvent(Id));
        }

        public Company(Guid id, string name, Address address) : this(id, name)
        {
            Address = address;
        }

        public void UpdateCompanyName(string name)
        {
            Name = name;
            UpdatedOn = DateTimeOffset.UtcNow;
            RaiseDomainEvent(new ContactUpdatedEvent(Id));
        }

        public void UpdateCompanyAddress(Address address)
        {
            Address = address;
            UpdatedOn = DateTimeOffset.UtcNow;
            RaiseDomainEvent(new ContactUpdatedEvent(Id));
        }
    }
}
