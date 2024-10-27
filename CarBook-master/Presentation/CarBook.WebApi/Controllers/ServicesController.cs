using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _mediator.Send(new GetServiceQueryRequest());
            return Ok(values);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQueryRequest(id));
            return Ok(value);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateService(CreateServiceCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Added");
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommandRequest(id));

            return Ok("It is deleted");
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateService(UpdateServiceCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Updated");
        }
    }
}
