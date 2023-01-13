using Contacter.Application.Abstractions.Messaging;
using Contacter.Domain.Entities;
using Contacter.Domain.Repositories;
using Contacter.Domain.ValueObjects;
using MediatR;

namespace Contacter.Application.Commands.CreateContact;

public class CreateContactCommand : ICommand
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Guid? CompanyId { get; private set; }

    public CreateContactCommand(string firstName, string lastName, Guid? companyId)
    {
        FirstName = firstName;
        LastName = lastName;
        CompanyId = companyId;
    }
}

internal sealed class CreateContactCommandHandler : ICommandHandler<CreateContactCommand>
{
    private readonly IContactRepository _contactRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateContactCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
    {
        _contactRepository = contactRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var name = new Name(request.FirstName, request.LastName);

        var contact = new Contact(Guid.NewGuid(), name);

        if (request.CompanyId.HasValue)
        {
            contact.ConnectCompany(request.CompanyId.Value);
        }

        _contactRepository.Add(contact);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}