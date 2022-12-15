using Appoitment.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Appoitment.Users.Api.Controllers.UserType
{
    [ApiController]
    [Route("[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUserTypeQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}