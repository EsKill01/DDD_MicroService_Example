using AutoMapper;
using Appoitment.Application.Abstractions.Handlers;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Models;
using Appoitment.Application.Queries.User;
using System.Threading;
using System.Threading.Tasks;

namespace Appoitment.Application.Handlers.Users
{
    public class GetUserByIdQueryHandler : CommonHandler, IQueryHandler<GetUserByIdQuery, UserModel>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await userRepository.GetAsync(request.UserId);

            return mapper.Map<UserModel>(result);
        }
    }
}