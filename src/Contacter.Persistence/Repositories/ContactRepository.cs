using Contacter.Domain.Entities;
using Contacter.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Contacter.Persistence.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(ContacterContext context) : base(context) { }
    }
}
