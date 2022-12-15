using Appoitment.Application.Abstractions.Commands;
using MediatR;

namespace Appoitment.Application.Abstractions.Handlers
{
    internal interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}