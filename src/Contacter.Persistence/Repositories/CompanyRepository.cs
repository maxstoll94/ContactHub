using Contacter.Domain.Entities;
using Contacter.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Contacter.Persistence.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ContacterContext context) : base(context) { }
    }
}
