using AutoMapper;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Commands.User;
using Appoitment.Application.Models;
using Appoitment.Domain.Entities;
using Appoitment.Domain.Responses;
using Appoitment.Test.Mappers;
using Appoitment.Users.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Appoitment.Test.UserTest
{
    public class UserApiTest
    {
        private Mock<IUserRepository> repositoryMock;
        private IWebHostBuilder webHost;
        private Mapper mapper;

        public UserApiTest()
        {
            repositoryMock = UserFactory.UserRepositoryMock();
            mapper = CommonFactory.GetMapper(AutoMapperConfig.Configuration());

            webHost = new WebHostBuilder()
            .ConfigureAppConfiguration(c => c.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"ConnectionStrings:MongoDb", "localhost"}
            }))
            .UseStartup<Startup>();
        }

        [Fact]
        public async Task UserApiGetAllTest()
        {
            //arange

            ResetSetups();
            var url = $"user";
            repositoryMock.Setup(n => n.GetAllAsync()).ReturnsAsync(UserMockData.GetDTOUsers().ToList());

            webHost.ConfigureTestServices(services =>
            {
                services.AddScoped(c => repositoryMock.Object);
            });

            using var server = new TestServer(webHost);
            using var client = server.CreateClient();

            //act

            var statusResponse = await client.GetAsync(url);

            var result = await client.GetFromJsonAsync<List<UserModel>>(url, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            //assert

            Assert.Equal(System.Net.HttpStatusCode.OK, statusResponse.StatusCode);
            Assert.NotNull(statusResponse.Content);
            var objResponse = Assert.IsType<List<UserModel>>(statusResponse.Content.ReadFromJsonAsync<List<UserModel>>().Result);
            Assert.Equal(5, objResponse.Count);
            Assert.IsType<List<UserModel>>(objResponse);

            Assert.NotNull(result);
            Assert.Equal(5, result.Count);
            Assert.IsType<List<UserModel>>(result);
        }

        [Theory]
        [InlineData("628c67be75245b2c62423234")]
        [InlineData("628c69e3bb48da105534047f")]
        public async Task UserApiGetByIdTest(string id)
        {
            ResetSetups();

            //arange

            var obj = UserMockData.GetDTOUsers().FirstOrDefault(c => c._id.ToString() == id);
            var url = $"user/id/{id}";

            repositoryMock.Setup(n => n.GetAsync(id))
                .ReturnsAsync(obj);

            webHost.ConfigureTestServices(services =>
            {
                services.AddScoped(c => repositoryMock.Object);
            });

            using var server = new TestServer(webHost);
            using var client = server.CreateClient();

            //act

            var statusResponse = await client.GetAsync(url);

            var result = await client.GetFromJsonAsync<UserModel>(url, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, statusResponse.StatusCode);
            Assert.NotNull(statusResponse.Content);
            var objResponse = Assert.IsType<UserModel>(statusResponse.Content.ReadFromJsonAsync<UserModel>().Result);
            Assert.Equal(id, objResponse.Id);

            Assert.NotNull(result);
            Assert.IsType<UserModel>(result);
            Assert.Equal(result.Id, id);
        }

        [Theory]
        [InlineData("6")]
        public async void GetUserByIdBadTest(string id)
        {
            #region badRequest

            var url = $"user/id/{id}";
            //arange

            ResetSetups();

            var obj = UserMockData.GetDTOUsers().FirstOrDefault(c => c.Id == id);

            repositoryMock.Setup(n => n.GetAsync(id))
                .ReturnsAsync(obj);

            webHost.ConfigureTestServices(services =>
           {
               services.AddScoped(c => repositoryMock.Object);
           });

            using var server = new TestServer(webHost);
            using var client = server.CreateClient();

            //act

            var result = await client.GetAsync(url);

            //assert

            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
            Assert.NotNull(result.Content);
            Assert.NotEmpty(result.Content.ToString());
        }

        [Fact]
        public async void CreateUserTest()
        {
            //arrange

            ResetSetups();

            var url = $"User/";
            var model = UserFactory.GetUserModel();
            var entity = UserFactory.GetUserDTO();
            var command = UserFactory.UserPostCommand();
            var objDto = UserMockData.GetDTOUsers().FirstOrDefault();

            entity.Name = "Legolas";
            entity.LastName = "El elfo";
            entity.Dni = "123456";

            model.Name = "Legolas";
            model.LastName = "El elfo";
            model.Dni = "123456";

            command = mapper.Map<UserPostCommand>(objDto);

            command.Name = "Legolas";
            command.Lastname = "El elfo";
            command.DNI = "123456";

            repositoryMock.Setup(n => n.GetByProperties(entity))
                .ReturnsAsync((User)null);

            repositoryMock.Setup(n => n.AddAsync(It.IsAny<User>()))
                .ReturnsAsync(new RepositoryResponse(model));

            webHost.ConfigureTestServices(services =>
            {
                services.AddScoped(c => repositoryMock.Object);
            });

            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8,
            "application/json");

            using var server = new TestServer(webHost);
            using var client = server.CreateClient();

            //act

            var statusResponse = await client.PostAsync(url, httpContent);

            //assert

            Assert.Equal(System.Net.HttpStatusCode.OK, statusResponse.StatusCode);

            Assert.NotNull(statusResponse.Content);
            var objResponse = Assert.IsType<UserModel>(statusResponse.Content.ReadFromJsonAsync<UserModel>().Result);
            Assert.Equal("123456", objResponse.Dni);
        }

        #endregion badRequest

        private void ResetSetups()
        {
            repositoryMock.Reset();
        }
    }
}