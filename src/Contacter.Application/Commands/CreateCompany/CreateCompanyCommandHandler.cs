using Contacter.Application.Abstractions.Messaging;
using Contacter.Domain.Entities;
using Contacter.Domain.Repositories;
using Contacter.Domain.ValueObjects;
using MediatR;

namespace Contacter.Application.Commands.CreateCompany;

public class CreateCompanyCommand : ICommand
{
    public string Name { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public CreateCompanyCommand(string name, string street,
        string city, string postalCode, string country)
    {
        Name = name;
        Street = street;
        City = city;
        PostalCode = postalCode;
        Country = country;
    }
}

internal sealed class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var address = new Address(request.Street, request.City, request.PostalCode, request.Country);

        var company = new Company(Guid.NewGuid(), request.Name, address);

        _companyRepository.Add(company);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}