using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RentACarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{locationID}/{available}")]
        public async Task<IActionResult> RentACarListByFilter(int locationID,bool available)
        {
            var values = await _mediator.Send(new GetRentACarQueryRequest(locationID,available));
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RentACarListByFilter2(GetRentACarQueryRequest query)
        {
            var values = await _mediator.Send(query);
            return Ok(values);
        }


    }
}
