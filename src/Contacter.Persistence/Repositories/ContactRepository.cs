using ContactHub.Domain.Entities;
using ContactHub.Domain.Repositories;
using ContactHub.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ContactHub.Persistence.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(ContactHubContext context) : base(context) { }
    }
}
