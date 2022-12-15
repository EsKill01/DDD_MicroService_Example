using Appoitment.Application.Abstractions.Queries;
using Appoitment.Application.Models;

namespace Appoitment.Application.Queries.User
{
    public class GetUserByIdQuery : IQuery<UserModel>
    {
        public string UserId { get; }

        public GetUserByIdQuery(string id)
        {
            UserId = id;
        }
    }
}