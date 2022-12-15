using AutoMapper;
using Appoitment.Application.Abstractions.Handlers;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Models;
using Appoitment.Application.Queries.Phones;
using Appoitment.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appoitment.Application.Handlers.Phones
{
    public class GetAllPhoneTypesHandler : CommonHandler, IQueryHandler<GetAllPhoneTypesQuery, List<PhoneTypeModel>>
    {
        private readonly IModuleGetGenericRepository<PhoneType> phoneTypeRepository;
        private readonly IMapper mapper;

        public GetAllPhoneTypesHandler(IEnumerable<IModuleGetGenericRepository<PhoneType>> moduleGetGenericsRepository, IMapper mapper)
        {
            this.phoneTypeRepository = moduleGetGenericsRepository.FirstOrDefault(c => c.Name == nameof(PhoneType));
            this.mapper = mapper;
        }

        public async Task<List<PhoneTypeModel>> Handle(GetAllPhoneTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await phoneTypeRepository.GetAllAsync();

            var list = result.ToList();

            return mapper.Map<List<PhoneTypeModel>>(list);
        }
    }
}