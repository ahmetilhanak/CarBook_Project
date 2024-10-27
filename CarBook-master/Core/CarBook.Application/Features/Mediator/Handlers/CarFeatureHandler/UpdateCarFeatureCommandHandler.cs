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
    public class UpdateCarFeatureCommandHandler:IRequestHandler<UpdateCarFeatureCommandRequest>
    {
        private readonly IRepository<CarFeature> _repository;

        public UpdateCarFeatureCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CarFeatureID);

            value.Available=request.Available;

            await _repository.UpdateAsync(value);
        }
    }
}
