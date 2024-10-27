using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQueryRequest());
            return Ok(values);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQueryRequest(id));
            return Ok(value);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePricing(CreatePricingCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Added");
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommandRequest(id));

            return Ok("It is deleted");
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Updated");
        }
    }
}
