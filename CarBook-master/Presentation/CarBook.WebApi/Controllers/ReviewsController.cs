using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Validators.ReviewValidator;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{carId}")]
        public async Task<IActionResult> ReviewListByCarId(int carId)
        {
            var values = await _mediator.Send(new GetReviewByCarIdQueryRequest(carId));
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            CreateReviewValidator validator = new CreateReviewValidator();
            var validationResult=validator.Validate(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _mediator.Send(command);
            return Ok("It is Added");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            UpdateReviewValidator validator = new UpdateReviewValidator();
            var validationResult = validator.Validate(command);

            if (!ModelState.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _mediator.Send(command);
            return Ok("It is Updated");
        }
    }
}
