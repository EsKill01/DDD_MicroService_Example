using AutoMapper;
using Appoitment.Application.Abstractions.Handlers;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Models;
using Appoitment.Application.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appoitment.Application.Handlers
{
    public class GetUsersByNameHandler : CommonHandler, IQueryHandler<GetUsersByNameQuery, List<UserModel>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUsersByNameHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<List<UserModel>> Handle(GetUsersByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await userRepository.GetByName(request.Name);

            return mapper.Map<List<UserModel>>(result);
        }
    }
}