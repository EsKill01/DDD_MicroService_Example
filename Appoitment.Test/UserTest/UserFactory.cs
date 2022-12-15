using AutoMapper;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Commands.User;
using Appoitment.Application.Handlers.Users;
using Appoitment.Application.Handlers.Users.UserPostHandler;
using Appoitment.Application.Models;
using Appoitment.Application.Queries.User;
using Appoitment.Domain.Entities;
using Appoitment.Users.Api.Controllers.User;
using MediatR;
using Moq;

namespace Appoitment.Test.UserTest
{
    public class UserFactory
    {
        #region repositories

        public static Mock<IUserRepository> UserRepositoryMock() => new Mock<IUserRepository>();

        #endregion repositories

        #region controllers

        public static UserController UserController(IMediator mediator) => new UserController(mediator);

        #endregion controllers

        #region handlers

        public static UserPostCommandHandler UserPostHandler(IUserRepository userRepository, IMapper mapper) => new UserPostCommandHandler(userRepository, mapper);

        public static GetAllUsersQueryHandler GetAllUserHandler(IUserRepository userRepository, IMapper mapper) => new GetAllUsersQueryHandler(userRepository, mapper);

        public static GetUserByIdQueryHandler GetUserByIdHandler(IUserRepository userRepository, IMapper mapper) => new GetUserByIdQueryHandler(userRepository, mapper);

        #endregion handlers

        #region commands

        public static UserPostCommand UserPostCommand() => new UserPostCommand();

        #endregion commands

        #region queries

        public static GetAllUsersQuery GetAllUsersQuery() => new GetAllUsersQuery();

        public static GetUserByIdQuery GetUserByIdQuery(string id) => new GetUserByIdQuery(id);

        #endregion queries

        #region objects

        public static User GetUserDTO() => new User();

        public static UserModel GetUserModel() => new UserModel();

        #endregion objects
    }
}