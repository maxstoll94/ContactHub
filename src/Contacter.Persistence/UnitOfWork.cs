using Contacter.Domain.Repositories;

namespace Contacter.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContacterContext _context;

        public UnitOfWork(ContacterContext context)
        {
            _context = context;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
