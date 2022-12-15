using Appoitment.Application.Queries.Genders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Appoitment.Users.Api.Controllers.Gender
{
    [ApiController]
    [Route("[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly IMediator mediator;

        public GenderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllGendersQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}