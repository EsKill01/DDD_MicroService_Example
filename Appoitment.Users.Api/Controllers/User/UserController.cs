using Appoitment.Application.Commands.User;
using Appoitment.Application.Queries;
using Appoitment.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Appoitment.Users.Api.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("id/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var query = new GetUserByIdQuery(userId);
            var result = await mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var query = new GetUsersByNameQuery(name);
            var result = await mediator.Send(query);
            return result != null ? Ok(result) : Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserPostCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await mediator.Send(command);

            return result.Error ? BadRequest(result.Message) : Ok(result.ObjectResponse);
        }
    }
}