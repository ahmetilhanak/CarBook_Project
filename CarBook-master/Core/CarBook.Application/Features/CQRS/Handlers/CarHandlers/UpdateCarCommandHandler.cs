using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand updateCarCommand)
        {
            var value = await _repository.GetByIdAsync(updateCarCommand.CarID);

            value.Fuel = updateCarCommand.Fuel;
            value.BrandID = updateCarCommand.BrandID;
            value.Transmission = updateCarCommand.Transmission;
            value.BigImageUrl= updateCarCommand.BigImageUrl;
            value.CoverImageUrl= updateCarCommand.CoverImageUrl;
            value.Km= updateCarCommand.Km;
            value.Luggage= updateCarCommand.Luggage;
            value.Seat= updateCarCommand.Seat;
            value.Model= updateCarCommand.Model;

            await _repository.UpdateAsync(value);

        }
    }
}
