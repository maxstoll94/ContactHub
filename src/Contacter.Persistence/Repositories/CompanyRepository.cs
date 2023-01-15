using ContactHub.Domain.Entities;
using ContactHub.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ContactHub.Persistence.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ContactHubContext context) : base(context) { }
    }
}
