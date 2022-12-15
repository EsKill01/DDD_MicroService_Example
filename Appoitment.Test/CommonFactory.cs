using AutoMapper;
using FluentValidation;
using Appoitment.Application.Abstractions.Repositories;
using Appoitment.Application.Commands;
using Appoitment.Application.Handlers;
using Appoitment.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Appoitment.Test
{
    internal class CommonFactory
    {
        public static Mock<IGenericRepository<T>> GenericRepositoryMock<T>(T repo) where T : CommonEntity => new Mock<IGenericRepository<T>>();

        public static Mock<IMediator> GetMediatorMock() => new Mock<IMediator>();

        public static Mock<ILogger<T>> GetLoggerControllerMock<T>(T controller) where T : ControllerBase => new Mock<ILogger<T>>();

        public static Mock<ILogger<T>> GetLoggerCommandMock<T>(T command) where T : CommonCommand => new Mock<ILogger<T>>();

        public static Mock<ILogger<T>> GetLoggerHandlerMock<T>(T handler) where T : CommonHandler => new Mock<ILogger<T>>();

        public static Mock<IValidator<T>> GetValidatorMock<T>(T command) where T : CommonCommand => new Mock<IValidator<T>>();

        public static Mapper GetMapper(MapperConfiguration config) => new Mapper(config);

        public static Mock<IMapper> GetMapperMock() => new Mock<IMapper>();
    }
}