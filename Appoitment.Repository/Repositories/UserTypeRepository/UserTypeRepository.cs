using Appoitment.Application.Abstractions.Repository;
using Appoitment.Domain.Context;
using Appoitment.Domain.Entities.UserType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appoitment.Repository.Repositories.UserTypeRepository
{
    public class UserTypeRepository<T> : IModuleGetGenericRepository<T> where T : UserType
    {
        private readonly DbContext context;

        private readonly DbSet<T> _dbSet;

        public UserTypeRepository(MongoDbContext context)
        {
            this.context = context;
            _dbSet = this.context.Set<T>();
            Name = nameof(UserType);
        }

        public string Name
        {
            get;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            try
            {
                var result = _dbSet.ToList();

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }
    }
}