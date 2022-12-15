using AutoMapper;
using FluentValidation;
using Appoitment.Application.Abstractions.Config;
using Appoitment.Application.Commands.User;
using Appoitment.Application.Handlers;
using Appoitment.Application.Handlers.Phones;
using Appoitment.Application.Handlers.Users;
using Appoitment.Application.Handlers.Users.UserPostHandler;
using Appoitment.Application.Mappers;
using Appoitment.Application.Models;
using Appoitment.Application.Queries;
using Appoitment.Application.Queries.Genders;
using Appoitment.Application.Queries.Phones;
using Appoitment.Application.Queries.User;
using Appoitment.Application.Validations.Commands.User;
using Appoitment.Domain.Responses;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Appoitment.Application.Config
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<UserPostCommand, RepositoryResponse>, UserPostCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllUsersQuery, List<UserModel>>, GetAllUsersQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserByIdQuery, UserModel>, GetUserByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllUserTypeQuery, List<UserTypeModel>>, GetAllUserTypesHandler>();
            services.AddScoped<IRequestHandler<GetAllPhoneTypesQuery, List<PhoneTypeModel>>, GetAllPhoneTypesHandler>();
            services.AddScoped<IRequestHandler<GetAllGendersQuery, List<GenderModel>>, GetAllGendersHandler>();
            services.AddScoped<IRequestHandler<GetUsersByNameQuery, List<UserModel>>, GetUsersByNameHandler>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddLogging();

            services.AddSingleton<IMapper>(new Mapper(AutoMapperConfig.Configuration()));
            services.AddScoped<IValidator<UserPostCommand>, UserPostCommandValidation>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(RequestLogger<>));

            return services;
        }
    }
}