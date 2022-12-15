using Appoitment.Application.Abstractions.Repositories;
using Appoitment.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appoitment.Application.Abstractions.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByProperties(User model);

        Task<ICollection<User>> GetByName(string name);
    }
}