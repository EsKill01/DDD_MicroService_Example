using Appoitment.Application.Abstractions.Queries;
using MediatR;

namespace Appoitment.Application.Abstractions.Handlers
{
    internal interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}