using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudsQueryRequest());
            return Ok(values);
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQueryRequest(id));
            return Ok(value);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Added");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateService(UpdateTagCloudCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Updated");
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommandRequest(id));

            return Ok("It is deleted");
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetTagCloudsByBlodId(int id)
        {
            var value = await _mediator.Send(new GetTagCloudsByBlogIdQueryRequest(id));
            return Ok(value);
        }

    }
}
