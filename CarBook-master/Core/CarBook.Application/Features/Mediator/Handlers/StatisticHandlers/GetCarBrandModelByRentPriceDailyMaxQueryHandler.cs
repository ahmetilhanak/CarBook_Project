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
    public class GetCarBrandModelByRentPriceDailyMaxQueryHandler:IRequestHandler<GetCarBrandModelByRentPriceDailyMaxQueryRequest, GetCarBrandModelByRentPriceDailyMaxQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarBrandModelByRentPriceDailyMaxQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarBrandModelByRentPriceDailyMaxQueryResponse> Handle(GetCarBrandModelByRentPriceDailyMaxQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarBrandModelByRentPriceDailyMax();

            return new GetCarBrandModelByRentPriceDailyMaxQueryResponse()
            {
                CarBrandMaxDailyPriced=value,
            };
        }
    }
}
