using ContactHub.Application.Abstractions.Messaging;
using ContactHub.Domain.Repositories;

namespace ContactHub.Application.Queries.GetContacts
{
    public class GetContactsQuery : IQuery<IEnumerable<ContactResponse>>
    {
        public string? SearchParam { get; private set; }

        public GetContactsQuery(string? value)
        {
            SearchParam = value;
        }

    }

    public class GetContactsQueryHandler : IQueryHandler<GetContactsQuery, IEnumerable<ContactResponse>>
    {
        private readonly IContactRepository _contactsRepository;

        public GetContactsQueryHandler(IContactRepository contactsRepository) => _contactsRepository = contactsRepository;

        public Task<IEnumerable<ContactResponse>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var query = _contactsRepository.Query();

            if (request.SearchParam != null)
            {
                query = query.Where(c => c.Name.First.Contains(request.SearchParam) || c.Name.Last.Contains(request.SearchParam));
            }

            var contacts = query
                .OrderBy(c => c.CreatedOn)
                .Select(c => ContactResponse.FromContact(c))
                .ToList()
                .AsEnumerable();

            return Task.FromResult(contacts);
        }
    }
}
