using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Responses.StatisticResponses;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarBrandModelByRentPriceDailyMinQueryHandler:IRequestHandler<GetCarBrandModelByRentPriceDailyMinQueryRequest, GetCarBrandModelByRentPriceDailyMinQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarBrandModelByRentPriceDailyMinQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarBrandModelByRentPriceDailyMinQueryResponse> Handle(GetCarBrandModelByRentPriceDailyMinQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarBrandModelByRentPriceDailyMin();

            return new()
            {
                CarBrandMinDailyPriced=value,
            };
        }
    }
}
