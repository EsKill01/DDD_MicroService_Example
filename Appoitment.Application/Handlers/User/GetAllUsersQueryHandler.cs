using AutoMapper;
using Appoitment.Application.Abstractions.Handlers;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Models;
using Appoitment.Application.Queries.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appoitment.Application.Handlers.Users
{
    public class GetAllUsersQueryHandler : CommonHandler, IQueryHandler<GetAllUsersQuery, List<UserModel>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await userRepository.GetAllAsync();

            var list = result.ToList();

            return mapper.Map<List<UserModel>>(list);
        }
    }
}