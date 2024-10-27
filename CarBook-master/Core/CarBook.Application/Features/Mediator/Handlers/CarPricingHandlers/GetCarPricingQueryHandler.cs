using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Responses.CarPricingResponses;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingQueryHandler:IRequestHandler<GetCarPricingQueryRequest,List<GetCarPricingQueryResponse>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingQueryResponse>> Handle(GetCarPricingQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _carPricingRepository.GetCarPricingWithCars(request.PerWhat);

            return values.Select(x => new GetCarPricingQueryResponse()
            {
                CarPricingID = x.CarPricingID,
                Brand=x.Car.Brand.Name,
                Model=x.Car.Model,
                CoverImageUrl=x.Car.CoverImageUrl,
                Amount=x.Amount,
                CarID=x.CarID,

            }).ToList();
           
        }
    }
}
