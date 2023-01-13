using Contacter.Domain.Events;
using Contacter.Domain.Primitives;
using Contacter.Domain.ValueObjects;

namespace Contacter.Domain.Entities
{
    public class Contact : AggregateRoot
    {
        public Name Name { get; private set; }
        public Socials Socials { get; private set; }
        public Guid? CompanyId { get; private set; }
        public virtual Company? Company { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }
        public DateTimeOffset? UpdatedOn { get; private set; }

        #pragma warning disable CS8618
        // EF Core Constructor
        private Contact(Guid id) : base(id)
        {
            Socials = new Socials();
            CreatedOn = DateTimeOffset.UtcNow;

            RaiseDomainEvent(new ContactCreatedEvent(Id));
        }

        public Contact(Guid id, Name name) : this(id)
        {
            Name = name;
        }

        public void UpdateContactName(Name name)
        {
            Name = name;
            UpdatedOn = DateTimeOffset.UtcNow;
            RaiseDomainEvent(new ContactUpdatedEvent(Id));
        }

        public void UpdateSocials(Socials socials)
        {
            Socials = socials;
            UpdatedOn = DateTimeOffset.UtcNow;
            RaiseDomainEvent(new CompanyUpdatedEvent(Id));
        }

        public void ConnectCompany(Guid companyId)
        {
            CompanyId = companyId;
            UpdatedOn = DateTimeOffset.UtcNow;
            RaiseDomainEvent(new CompanyUpdatedEvent(Id));
        }
    }
}
