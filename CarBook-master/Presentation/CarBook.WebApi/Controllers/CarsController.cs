using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLastSomeCarsWithBrandQueryHandler _getLastSomeCarsWithBrandQueryHandler;
        private readonly GetCarWithPricingsQueryHandler _getCarWithPricingsQueryHandler;
        private readonly GettingCarsWithPricingsQueryHandler _denemeHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, RemoveCarCommandHandler removeCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLastSomeCarsWithBrandQueryHandler getLastSomeCarsWithBrandQueryHandler, GetCarWithPricingsQueryHandler getCarWithPricingsQueryHandler, GettingCarsWithPricingsQueryHandler denemeHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLastSomeCarsWithBrandQueryHandler = getLastSomeCarsWithBrandQueryHandler;
            _getCarWithPricingsQueryHandler = getCarWithPricingsQueryHandler;
            _denemeHandler = denemeHandler;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

       

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("It is Added");
        }

        [HttpDelete("[action]/{id}")]

        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));

            return Ok("It is deleted");
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand updateCarCommand)
        {
            await _updateCarCommandHandler.Handle(updateCarCommand);
            return Ok("It is Updated");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CarListWithBrand()
        {
            var values = await _getCarWithBrandQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("[action]/{count}")]
        public async Task<IActionResult> GetLastSomeCarsWithBrand(int count)
        {
            var values = await _getLastSomeCarsWithBrandQueryHandler.Handle(new GetLastSomeCarsWithBrandQuery(count));

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CarsWithPricings()
        {
            var values = await _getCarWithPricingsQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsWithPricings()
        {
            var values = await _denemeHandler.Handle();

            return Ok(values);
        }

        

    }
}
