using Contacter.Domain.Entities;
using Contacter.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Contacter.Persistence.Repositories
{
    public abstract class Repository<T> where T : Entity
    {
        protected ContacterContext Context { get; private set; }

        protected Repository(ContacterContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public IQueryable<T> Query()
        {
            return Context.Set<T>().AsQueryable();
        }

        public Task<T?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Context.Set<T>().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
    }
}
