using MediatR;

namespace ContactHub.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}