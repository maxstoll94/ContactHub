using ContactHub.Application.Abstractions.Messaging;
using ContactHub.Domain.ErrorHandling;
using ContactHub.Domain.Repositories;
using ContactHub.Domain.ValueObjects;
using MediatR;

namespace ContactHub.Application.Commands.UpdateContact;

public class UpdateContactCommand : ICommand
{
    public Guid ContactId { get; private set; }
    public Name Name { get; private set; }
    public Socials Socials { get; private set; }
    public Guid? CompanyId { get; private set; }

    public UpdateContactCommand(Guid contactId, Name name, Socials socials, Guid? companyId)
    {
        ContactId = contactId;
        Name = name;
        Socials = socials;
        CompanyId = companyId;
    }
}

internal sealed class UpdateContactCommandHandler : ICommandHandler<UpdateContactCommand>
{
    private readonly IContactRepository _contactRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactCommandHandler(IContactRepository contactRepository, 
        ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork)
    {
        _contactRepository = contactRepository;
        _companyRepository= companyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.FindAsync(request.ContactId);

        if (contact == null)
        {
            throw new ContactorException("ContactNotFound", $"A contact with the identifier {request.ContactId} does not exist", nameof(request.ContactId));
        }

        contact.UpdateContactName(request.Name);
        contact.UpdateSocials(request.Socials);

        if (request.CompanyId.HasValue)
        {
            var company = await _companyRepository.FindAsync(request.CompanyId.Value);

            if (company == null)
            {
                throw new ContactorException("CompanyNotFound", $"A company with the identifier {request.CompanyId} does not exist", nameof(request.CompanyId));
            }

            contact.ConnectCompany(company);
        }
        else
        {
            contact.DisconnectCompany();
        }

        _contactRepository.Update(contact);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}