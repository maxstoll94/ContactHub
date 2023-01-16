using ContactHub.Domain.Repositories;

namespace ContactHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactHubContext _context;

        public UnitOfWork(ContactHubContext context)
        {
            _context = context;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
