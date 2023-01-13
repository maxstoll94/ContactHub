using MediatR;

namespace Contacter.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}