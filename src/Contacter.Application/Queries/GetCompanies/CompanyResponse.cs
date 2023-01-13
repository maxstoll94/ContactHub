using Contacter.Domain.Entities;
using Contacter.Domain.ValueObjects;

namespace Contacter.Application.Queries.GetCompanies
{
    public class CompanyResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }

        public CompanyResponse(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public static CompanyResponse FromCompany(Company company)
        {
            return new CompanyResponse(company.Name, company.Address);
        }
    }
}
