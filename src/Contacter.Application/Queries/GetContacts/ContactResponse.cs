using ContactHub.Application.Queries.GetCompanies;
using ContactHub.Domain.Entities;
using ContactHub.Domain.ValueObjects;

namespace ContactHub.Application.Queries.GetContacts
{
    public class ContactResponse
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Socials Socials { get; set; }
        public CompanyResponse? Company { get; set; }

        public ContactResponse(Guid id, Name name, Socials socials)
        {
            Id = id;
            Name = name;
            Socials = socials;
        }

        public static ContactResponse FromContact(Contact contact)
        {
            var response = new ContactResponse(contact.Id, contact.Name, contact.Socials);

            if (contact.Company != null)
            {
                response.Company = CompanyResponse.FromCompany(contact.Company);
            }

            return response;
        }
    }
}
