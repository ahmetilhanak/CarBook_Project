using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Responses.StatisticResponses;
using CarBook.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStatisticRepository _statisticRepository;

        public StatisticsController(IMediator mediator, IStatisticRepository statisticRepository)
        {
            _mediator = mediator;
            _statisticRepository = statisticRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQueryRequest());

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLocationCount()
        {
            var values =await _mediator.Send(new GetLocationCountQueryRequest());

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _mediator.Send(new GetAuthorCountQueryRequest());
                
            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQueryRequest());

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQueryRequest());

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForPricingPeriodQueryRequest("PerDay"));

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForPricingPeriodQueryRequest("PerWeek"));

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForPricingPeriodQueryRequest("PerMonth"));

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCountByAutoTransmission()
        {
            var values = await _mediator.Send(new GetCarCountByAutoTransmissionQueryRequest());

            return Ok(values);
        }
     
        [HttpGet("[action]")]
        public async Task<IActionResult> BrandNameHavingMaxCar()
        {
            var values = await _mediator.Send(new BrandNameHavingMaxCarQueryRequest());

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> BlogTitleHavingMaxComment()
        {
            var values = await _mediator.Send(new BlogTitleHavingMaxCommentQueryRequest());

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCountKmSmallerThan1000()
        {
            var values = await _mediator.Send(new GetCarCountKmSmallerThan1000QueryRequest());

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var values = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQueryRequest());

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var values = await _mediator.Send(new GetCarCountByFuelElectricQueryRequest());

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarBrandModelByRentPriceDailyMax()
        {
            var values = await _mediator.Send(new GetCarBrandModelByRentPriceDailyMaxQueryRequest());

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarBrandModelByRentPriceDailyMin()
        {
            var values = await _mediator.Send(new GetCarBrandModelByRentPriceDailyMinQueryRequest());

            return Ok(values);
        }
    }
}


