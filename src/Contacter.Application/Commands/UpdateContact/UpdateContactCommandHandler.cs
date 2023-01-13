using Contacter.Application.Abstractions.Messaging;
using Contacter.Domain.Exceptions;
using Contacter.Domain.Repositories;
using Contacter.Domain.ValueObjects;
using MediatR;

namespace Contacter.Application.Commands.UpdateContact;

public class UpdateContactCommand : ICommand
{
    public Guid ContactId { get; private set; }
    public Name Name { get; private set; }
    public Socials Socials { get; private set; }

    public UpdateContactCommand(Guid contactId, Name name, Socials socials)
    {
        ContactId = contactId;
        Name = name;
        Socials = socials;
    }
}

internal sealed class UpdateContactCommandHandler : ICommandHandler<UpdateContactCommand>
{
    private readonly IContactRepository _contactRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
    {
        _contactRepository = contactRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.FindAsync(request.ContactId);

        if (contact == null)
        {
            throw new ContractorException("ContactNotFound", $"A contact with the identifier {request.ContactId} does not exist", nameof(request.ContactId));
        }

        contact.UpdateContactName(request.Name);
        contact.UpdateSocials(request.Socials);

        _contactRepository.Update(contact);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}