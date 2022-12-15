using Appoitment.Domain.Entities;
using Appoitment.Domain.Entities.UserType;
using Microsoft.EntityFrameworkCore;

namespace Appoitment.Domain.Context
{
    public interface IDbContext
    {
        DbSet<User> users { get; set; }

        DbSet<UserType> userTypes { get; set; }

        DbSet<PhoneType> phoneTypes { get; set; }

        DbSet<Gender> genders { get; set; }
    }
}