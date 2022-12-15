namespace Appoitment.Application.Abstractions.Config
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAuthenticated { get; }
    }
}