using AutoMapper;
using Appoitment.Application.Abstractions.Handlers;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Models;
using Appoitment.Application.Queries.User;
using Appoitment.Domain.Entities.UserType;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appoitment.Application.Handlers
{
    public class GetAllUserTypesHandler : CommonHandler, IQueryHandler<GetAllUserTypeQuery, List<UserTypeModel>>
    {
        private readonly IModuleGetGenericRepository<UserType> userTypeRepository;
        private readonly IMapper mapper;

        public GetAllUserTypesHandler(IEnumerable<IModuleGetGenericRepository<UserType>> userTypeRepository, IMapper mapper)
        {
            this.userTypeRepository = userTypeRepository.FirstOrDefault(c => c.Name == nameof(UserType));
            this.mapper = mapper;
        }

        public async Task<List<UserTypeModel>> Handle(GetAllUserTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await userTypeRepository.GetAllAsync();

            var list = result.ToList();

            return mapper.Map<List<UserTypeModel>>(list);
        }
    }
}