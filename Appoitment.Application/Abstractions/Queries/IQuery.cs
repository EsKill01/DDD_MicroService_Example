using MediatR;

namespace Appoitment.Application.Abstractions.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}