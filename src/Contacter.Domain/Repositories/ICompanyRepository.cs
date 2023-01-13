using Contacter.Domain.Entities;

namespace Contacter.Domain.Repositories
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// Get a company using its unique identifier
        /// </summary>
        Task<Company?> FindAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get companies
        /// </summary>
        IQueryable<Company> Query();

        /// <summary>
        /// Add a new company to the repository
        /// </summary>
        void Add(Company contact);

        /// <summary>
        /// Update an existing comapny in the repository
        /// </summary>
        void Update(Company contact);
    }
}
