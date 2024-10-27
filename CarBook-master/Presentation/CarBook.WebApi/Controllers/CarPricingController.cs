using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{perWhat}")]
        public async Task<IActionResult> GetCarPricingsWithCarsList(string perWhat)
        {
            var values=await _mediator.Send(new GetCarPricingQueryRequest(perWhat));
            return Ok(values);
        }

		[HttpGet("[action]")]
		public async Task<IActionResult> GetCarPricingWithTimePeriod()
		{
			var values = await _mediator.Send(new GetCarPricingWithTimePeriodQueryRequest());
			return Ok(values);
		}
	}
}
