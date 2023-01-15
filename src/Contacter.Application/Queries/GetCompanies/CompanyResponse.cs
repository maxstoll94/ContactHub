using ContactHub.Domain.Entities;
using ContactHub.Domain.ValueObjects;

namespace ContactHub.Application.Queries.GetCompanies
{
    public class CompanyResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public CompanyResponse(Guid id, string name, Address address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public static CompanyResponse FromCompany(Company company)
        {
            return new CompanyResponse(company.Id, company.Name, company.Address);
        }
    }
}
