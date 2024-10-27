using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Responses.CarDescriptionResponses;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler:IRequestHandler<GetCarDescriptionByCarIdQueryRequest, GetCarDescriptionQueryResponse>
    {
        private readonly ICarDescriptionRepository _carDescriptionRepository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository carDescriptionRepository)
        {
            _carDescriptionRepository = carDescriptionRepository;
        }

        public async Task<GetCarDescriptionQueryResponse> Handle(GetCarDescriptionByCarIdQueryRequest request, CancellationToken cancellationToken)
        {
            //var value = await _repository.GetByIdAsync(request.Id);
            var description = _carDescriptionRepository.GetCarDescriptionById(request.Id);

            return new GetCarDescriptionQueryResponse()
            {
                CarDescriptionID= description.CarDescriptionID,
                CarID= description.CarID,
                Details= description.Details,
            };
        }
    }
}
