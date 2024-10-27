using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Responses.CarFeatureResponses;
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
    public class GetCarFeatureByCarIdQueryHandler:IRequestHandler<GetCarFeatureByCarIdQueryRequest, List<GetCarFeatureByCarIdQueryResponse>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResponse>> Handle(GetCarFeatureByCarIdQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _carFeatureRepository.GetCarFeatureByCarIdHavingFeature(request.CarID);

            return values.Select(z=>new GetCarFeatureByCarIdQueryResponse()
            {
                CarFeatureID=z.CarFeatureID,
                CarID=z.CarID,
                Available=z.Available,
                FeatureID=z.FeatureID,
                FeatureName = z.Feature.Name,
            }).ToList();

            
        }
    }
}
