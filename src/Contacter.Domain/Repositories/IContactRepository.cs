using ContactHub.Domain.Entities;

namespace ContactHub.Domain.Repositories
{
    public interface IContactRepository
    {
        /// <summary>
        /// Get a contact using its unique identifier
        /// </summary>
        Task<Contact?> FindAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get contacts
        /// </summary>
        IQueryable<Contact> Query();

        /// <summary>
        /// Add a new contact to the repository
        /// </summary>
        void Add(Contact contact);

        /// <summary>
        /// Update an existing contact in the repository
        /// </summary>
        void Update(Contact contact);
    }
}
