using ContactHub.Application.Abstractions.Messaging;
using ContactHub.Domain.Entities;
using ContactHub.Domain.ErrorHandling;
using ContactHub.Domain.Repositories;
using ContactHub.Domain.ValueObjects;
using MediatR;

namespace ContactHub.Application.Commands.CreateContact;

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
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateContactCommandHandler(IContactRepository contactRepository,
        ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork)
    {
        _contactRepository = contactRepository;
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var name = new Name(request.FirstName, request.LastName);

        var contact = new Contact(Guid.NewGuid(), name);

        if (request.CompanyId.HasValue)
        {
            var company = await _companyRepository.FindAsync(request.CompanyId.Value);

            if (company == null)
            {
                throw new ContactorException("CompanyNotFound", $"A company with the identifier {request.CompanyId} does not exist", nameof(request.CompanyId));
            }

            contact.ConnectCompany(company);
        }

        _contactRepository.Add(contact);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}