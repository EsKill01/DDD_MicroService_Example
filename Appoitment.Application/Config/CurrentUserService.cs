using Appoitment.Application.Abstractions.Config;

namespace Appoitment.Application.Config
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}