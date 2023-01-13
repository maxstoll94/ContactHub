using MediatR;

namespace Contacter.Application.Abstractions.Messaging;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}
