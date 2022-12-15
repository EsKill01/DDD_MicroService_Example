using Appoitment.Application.Queries.Phones;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Appoitment.Users.Api.Controllers.PhoneType
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public PhoneTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPhoneTypesQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}