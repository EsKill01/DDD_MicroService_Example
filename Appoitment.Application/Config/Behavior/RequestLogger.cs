using Appoitment.Application.Abstractions.Config;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Appoitment.Application.Config
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<TRequest> logger;
        private readonly ICurrentUserService currentUserService;

        public RequestLogger(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            this.logger = logger;
            this.currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            logger.LogInformation("User service request: {Name} {@UserId} {@Request}",
                name, currentUserService.UserId, request);

            return Task.CompletedTask;
        }
    }
}