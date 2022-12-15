using MediatR;

namespace Appoitment.Application.Abstractions.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}