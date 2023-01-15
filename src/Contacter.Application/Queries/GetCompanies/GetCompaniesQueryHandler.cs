using ContactHub.Application.Abstractions.Messaging;
using ContactHub.Domain.Repositories;

namespace ContactHub.Application.Queries.GetCompanies
{
    public class GetCompaniesQuery : IQuery<IEnumerable<CompanyResponse>>
    {
        public string? SearchParam { get; private set; }

        public GetCompaniesQuery(string? value)
        {
            SearchParam = value;
        }

    }

    public class GetCompaniesQueryHandler : IQueryHandler<GetCompaniesQuery, IEnumerable<CompanyResponse>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompaniesQueryHandler(ICompanyRepository companyRepository) => _companyRepository = companyRepository;

        public Task<IEnumerable<CompanyResponse>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var query = _companyRepository.Query();

            if (request.SearchParam != null)
            {
                query = query.Where(c => c.Name.Contains(request.SearchParam));
            }

            var contacts = query
                .OrderBy(c => c.CreatedOn)
                .Select(c => CompanyResponse.FromCompany(c))
                .ToList()
                .AsEnumerable();

            return Task.FromResult(contacts);
        }
    }
}
