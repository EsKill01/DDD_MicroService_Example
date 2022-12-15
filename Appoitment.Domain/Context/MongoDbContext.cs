using Blueshift.EntityFrameworkCore.MongoDB.Annotations;
using Appoitment.Domain.Entities;
using Appoitment.Domain.Entities.UserType;
using Microsoft.EntityFrameworkCore;

namespace Appoitment.Domain.Context
{
    [MongoDatabase("RequestME")]
    public class MongoDbContext : DbContext, IDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public MongoDbContext(DbContextOptions<MongoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> users { get; set; }

        public DbSet<UserType> userTypes { get; set; }

        public DbSet<PhoneType> phoneTypes { get; set; }

        public DbSet<Gender> genders { get; set; }
    }
}