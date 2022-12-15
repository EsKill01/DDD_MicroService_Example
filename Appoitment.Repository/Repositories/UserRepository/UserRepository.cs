using Appoitment.Application.Abstractions.Repository;
using Appoitment.Domain.Context;
using Appoitment.Domain.Entities;
using Appoitment.Domain.Responses;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appoitment.Repository.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        private readonly DbSet<User> _dbSet;

        private void LoadAdditionalData(User x)
        {
            try
            {
                var _context = (MongoDbContext)context;

                x.UserType = _context.userTypes.FirstOrDefault(r => r._id == ObjectId.Parse(x.UserTypeId));
                x.Phones.ToList().ForEach(y =>
                {
                    y.PhoneType = _context.phoneTypes.FirstOrDefault(c => c._id == ObjectId.Parse(y.PhoneTypeId));
                });

                if (!string.IsNullOrEmpty((x.GenderId)))
                {
                    x.UserGender = _context.genders.FirstOrDefault(c => c._id == ObjectId.Parse(x.GenderId));
                }
            }
            catch (Exception)
            {
            }
        }

        public UserRepository(MongoDbContext context)
        {
            this.context = context;
            _dbSet = this.context.Set<User>();
        }

        public async Task<RepositoryResponse> AddAsync(User model)
        {
            try
            {
                var result = await GetByProperties(model);

                if (result != null)
                {
                    return new RepositoryResponse(true, "El objeto ya existe");
                }

                _dbSet.Add(model);
                context.SaveChanges();

                var r = await GetAsync(model._id.ToString());

                return await Task.FromResult(new RepositoryResponse(r));
            }
            catch (Exception)
            {
                return new RepositoryResponse(true, "Ha ocurrido un problema");
            }
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            try
            {
                var result = new List<User>();

                result = _dbSet.ToList();

                result.ForEach(x =>
                {
                    LoadAdditionalData(x);
                });

                //No funciona por ser el metodo generico pero es así
                ////var r = (from us in _dbSet.ToList()
                ////        join ut in _context.userTypes
                ////        on ObjectId.Parse(us.UserTypeId) equals ut._id
                ////        select new User
                ////        {
                ////            Id = us.Id,
                ////            Addresses = us.Addresses,
                ////            Dni = us.Dni,
                ////            Phones = us.Phones,
                ////            Email = us.Email,
                ////            Name = us.Name,
                ////            LastName = us.LastName,
                ////            UserType = new Domain.Entities.UserType.UserType
                ////            {
                ////                UserTypeName = ut.UserTypeName

                ////            }
                ////        }).ToList();

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }

        public async Task<User> GetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var oId = ObjectId.Parse(id);

            try
            {
                var result = _dbSet.Where(c => c._id == oId).FirstOrDefault();

                LoadAdditionalData(result);

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ICollection<User>> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            try
            {
                var result = _dbSet.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

                result.ForEach(x =>
            {
                LoadAdditionalData(x);
            });

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<User> GetByProperties(User model)
        {
            if (model == null)
            {
                return null;
            }

            try
            {
                var result = _dbSet.
                Where(c => c.Name.Equals(model.Name, StringComparison.OrdinalIgnoreCase)
                && c.LastName.Equals(model.LastName, StringComparison.OrdinalIgnoreCase)
                && c.Dni.Equals(model.Dni, StringComparison.OrdinalIgnoreCase)
                ).FirstOrDefault();

                LoadAdditionalData(result);

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}