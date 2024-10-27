using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandler
{
    public class CreateCarFeatureByCarCommandHandler: IRequestHandler<CreateCarFeatureByCarCommandRequest>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateCarFeatureByCarCommandRequest request, CancellationToken cancellationToken)
        {
            _carFeatureRepository.CreateCarFeatureByCar(new CarFeature()
            {
                CarID = request.CarID,
                FeatureID=request.FeatureID,
                Available=false
            });
        }
    }
}
