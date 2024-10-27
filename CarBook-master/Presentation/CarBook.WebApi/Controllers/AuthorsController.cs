using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AuthorList()
        {
            var values = await _mediator.Send(new GetAuthorQueryRequest());
            return Ok(values);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var value = await _mediator.Send(new GetAuthorByIdQueryRequest(id));
            return Ok(value);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _mediator.Send(new RemoveAuthorCommandRequest(id));

            return Ok("It is deleted");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Added");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Updated");
        }
    }
}
