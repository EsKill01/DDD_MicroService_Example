using FluentValidation.AspNetCore;
using Appoitment.Application.Abstractions.Repositories;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Config;
using Appoitment.Application.Exceptions;
using Appoitment.Domain.Context;
using Appoitment.Domain.Entities;
using Appoitment.Repository.Repositories;
using Appoitment.Repository.Repositories.UserRepository;
using Appoitment.Repository.Repositories.UserTypeRepository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Appoitment.Users.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<User>), typeof(UserRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IModuleGetGenericRepository<>), typeof(UserTypeRepository<>));
            services.AddScoped(typeof(IModuleGetGenericRepository<>), typeof(PhoneTypeRepository<>));
            services.AddScoped(typeof(IModuleGetGenericRepository<>), typeof(GenderRepository<>));

            services.AddMediatR(typeof(Mediator));
            services.AddApplicationServices();

            services.AddControllers(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
            .AddFluentValidation();

            services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

            services.AddDbContext<MongoDbContext>(opt =>
            {
                var connectionString = Configuration.GetConnectionString("MongoDB");
                opt.UseMongoDb(connectionString);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Appoitment.Users.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Appoitment.Users.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}