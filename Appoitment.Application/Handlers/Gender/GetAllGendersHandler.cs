using AutoMapper;
using Appoitment.Application.Abstractions.Handlers;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Models;
using Appoitment.Application.Queries.Genders;
using Appoitment.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appoitment.Application.Handlers
{
    public class GetAllGendersHandler : CommonHandler, IQueryHandler<GetAllGendersQuery, List<GenderModel>>
    {
        private readonly IModuleGetGenericRepository<Gender> genericRepository;
        private readonly IMapper mapper;

        public GetAllGendersHandler(IEnumerable<IModuleGetGenericRepository<Gender>> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository.FirstOrDefault(c => c.Name == nameof(Gender));
            this.mapper = mapper;
        }

        public async Task<List<GenderModel>> Handle(GetAllGendersQuery request, CancellationToken cancellationToken)
        {
            var result = await genericRepository.GetAllAsync();

            var list = result.ToList();

            return mapper.Map<List<GenderModel>>(list);
        }
    }
}