using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class ReservationCommandHandler:IRequestHandler<CreateReservationCommandRequest>
    {
        private readonly IRepository<Reservation> _repository;

        public ReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation()
            {
                Age = request.Age,
                AgeOfDrivingLicense = request.AgeOfDrivingLicense,
                CarID = request.CarID,
                Description = request.Description,
                DropOffLocationID = request.DropOffLocationID,
                PickUpLocationID = request.PickUpLocationID,
                Email = request.Email,
                LastName = request.LastName,
                Name = request.Name,
                Phone = request.Phone,
                Status = request.Status,
                
            });
        }
    }
}
