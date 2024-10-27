using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{CarId}")]
        public async Task<IActionResult> GetCarPricingsWithCarsList(int CarId)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQueryRequest(CarId));
            return Ok(values);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCarFeature(UpdateCarFeatureCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Updated");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Added");
        }
    }
}
