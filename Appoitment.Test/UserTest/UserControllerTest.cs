using AutoMapper;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Commands.User;
using Appoitment.Application.Models;
using Appoitment.Application.Queries.User;
using Appoitment.Domain.Entities;
using Appoitment.Domain.Responses;
using Appoitment.Test.Mappers;
using Appoitment.Users.Api.Controllers.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Appoitment.Test.UserTest
{
    public class UserControllerTest
    {
        private Mock<IMediator> mediatorMock;
        private Mock<IUserRepository> userRepositoryMock;
        private Mapper mapper;

        public UserControllerTest()
        {
            mediatorMock = CommonFactory.GetMediatorMock();
            userRepositoryMock = UserFactory.UserRepositoryMock();
            mapper = CommonFactory.GetMapper(AutoMapperConfig.Configuration());
        }

        [Fact]
        public async void GetAllUsersTest()
        {
            //arange

            ResetSetups();

            var handler = UserFactory.GetAllUserHandler(userRepositoryMock.Object, mapper);
            var loggerMock = CommonFactory.GetLoggerControllerMock((UserController)FormatterServices.GetUninitializedObject(typeof(UserController))); //Ejemplo
            var validationMock = CommonFactory.GetValidatorMock(UserFactory.UserPostCommand()); //Ejemplo

            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllUsersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(await Task.FromResult(UserMockData.GetUsersModel().ToList()))
                .Verifiable("Se envio el request");

            userRepositoryMock.Setup(n => n.GetAllAsync()).ReturnsAsync(UserMockData.GetDTOUsers().ToList());

            var controller = UserFactory.UserController(mediatorMock.Object);

            //act

            var controllerResult = await controller.GetAllUsers();
            var handlerResult = await handler.Handle(UserFactory.GetAllUsersQuery(), default);

            //assert

            mediatorMock.Verify(x => x.Send(It.IsAny<GetAllUsersQuery>(),
                                           default),
                                           Times.Once());

            Assert.NotNull(controllerResult);
            var okResult = Assert.IsType<OkObjectResult>(controllerResult);
            Assert.IsType<List<UserModel>>(okResult.Value);
            Assert.IsType<List<UserModel>>(handlerResult);
            Assert.Equal(5, handlerResult.Count);
        }

        [Theory]
        [InlineData("628c67be75245b2c62423234")]
        [InlineData("628c69e3bb48da105534047f")]
        public async void GetUserById(string id)
        {
            #region goodRequest

            //arange

            ResetSetups();

            var objModel = UserMockData.GetUsersModel().FirstOrDefault(c => c.Id == id);
            var obj = UserMockData.GetDTOUsers().FirstOrDefault(c => c._id.ToString() == id);
            var handlerMock = UserFactory.GetUserByIdHandler(userRepositoryMock.Object, mapper);
            var validationMock = CommonFactory.GetValidatorMock(UserFactory.UserPostCommand());

            mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(objModel)
                .Verifiable("Se envio el request");

            userRepositoryMock.Setup(n => n.GetAsync(id))
                .ReturnsAsync(obj);

            var handler = handlerMock;
            var controller = UserFactory.UserController(mediatorMock.Object);

            //act

            var result = await controller.GetUserById(id);
            var handlerResult = await handler.Handle(UserFactory.GetUserByIdQuery(id),
                                                                default);

            //assert

            mediatorMock.Verify(x => x.Send(It.IsAny<GetUserByIdQuery>(),
                                            default),
                                            Times.Once());

            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<UserModel>(okResult.Value);
            Assert.IsType<UserModel>(handlerResult);

            #endregion goodRequest
        }

        [Theory]
        [InlineData("6")]
        public async void GetUserByIdBad(string id)
        {
            #region badRequest

            //arange

            ResetSetups();

            var objModel = UserMockData.GetUsersModel().FirstOrDefault(c => c.Id == id);
            var obj = UserMockData.GetDTOUsers().FirstOrDefault(c => c.Id == id);
            var handlerMock = UserFactory.GetUserByIdHandler(userRepositoryMock.Object, mapper);
            var validationMock = CommonFactory.GetValidatorMock(UserFactory.UserPostCommand());

            mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(objModel)
                .Verifiable("Se envio el request");

            var handler = UserFactory.GetUserByIdHandler(userRepositoryMock.Object, mapper);

            userRepositoryMock.Setup(n => n.GetAsync(id))
                .ReturnsAsync(obj);

            var controller = UserFactory.UserController(mediatorMock.Object);

            //act

            var result = await controller.GetUserById(id);
            var handlerResul = await handler.Handle(UserFactory.GetUserByIdQuery(id),
                                                                default);

            //assert

            Assert.NotNull(result);
            var badResult = Assert.IsType<NotFoundResult>(result);

            Assert.Null(handlerResul);

            #endregion badRequest
        }

        [Fact]
        public async void CreateUserTest()
        {
            //arrange

            ResetSetups();

            var command = UserFactory.UserPostCommand();
            var model = UserFactory.GetUserModel();

            var mapperMock = CommonFactory.GetMapperMock();
            var validationMock = CommonFactory.GetValidatorMock(UserFactory.UserPostCommand());

            command.Name = "Legolas";
            command.Lastname = "El elfo";

            model = mapper.Map<UserModel>(command);

            mediatorMock.Setup(m => m.Send(It.IsAny<UserPostCommand>(),
                                           It.IsAny<CancellationToken>()))
                                           .ReturnsAsync(new RepositoryResponse(model))
                                           .Verifiable("Se envio el request");

            userRepositoryMock.Setup(n => n.GetAsync(model.Id))
                .ReturnsAsync((User)null);

            userRepositoryMock.Setup(n => n.AddAsync(It.IsAny<User>()))
                .ReturnsAsync(new RepositoryResponse(model));

            mapperMock.Setup(x => x.Map<UserPostCommand, UserModel>(It.IsAny<UserPostCommand>()))
            .Returns(model);

            validationMock.Setup(n => n.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(new FluentValidation.Results.ValidationResult());

            var handler = UserFactory.UserPostHandler(userRepositoryMock.Object, mapper);

            var controller = UserFactory.UserController(mediatorMock.Object);

            //act

            var controllerResult = await controller.CreateUser(command);
            var handlerResult = await handler.Handle(command, default);

            //assert

            mediatorMock.Verify(x => x.Send(It.IsAny<UserPostCommand>(),
                                            default),
                                            Times.Once());

            Assert.NotNull(handlerResult);
            Assert.NotNull(controllerResult);

            var okControllerResult = Assert.IsType<OkObjectResult>(controllerResult);
            var okHandlerResponse = Assert.IsType<RepositoryResponse>(handlerResult);
            var controllerRepositoryResponse = Assert.IsType<UserModel>(okControllerResult.Value);

            Assert.NotNull(controllerRepositoryResponse);
            Assert.NotNull(okHandlerResponse.ObjectResponse);
        }

        private void ResetSetups()
        {
            mediatorMock.Reset();
            userRepositoryMock.Reset();
        }
    }
}