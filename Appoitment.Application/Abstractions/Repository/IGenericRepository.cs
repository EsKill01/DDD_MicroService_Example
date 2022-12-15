using Appoitment.Domain.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appoitment.Application.Abstractions.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<RepositoryResponse> AddAsync(T model);

        Task<ICollection<T>> GetAllAsync();

        Task<T> GetAsync(string id);
    }
}