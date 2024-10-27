using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(GetCheckAppUserQueryRequest query)
        {
            var values = await _mediator.Send(query);
            if (values.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(values));
            }
            else
            {
                return BadRequest("Username or password is incorrect");
            }
           
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(CreateAppUserCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Added");

        }
    }
}
