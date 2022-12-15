using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appoitment.Application.Abstractions.Repository
{
    public interface IModuleGetGenericRepository<T> where T : class
    {
        string Name { get; }

        Task<ICollection<T>> GetAllAsync();
    }
}