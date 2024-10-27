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
    public class GetAvgRentPriceForPricingPeriodQueryHandler : IRequestHandler<GetAvgRentPriceForPricingPeriodQueryRequest, GetAvgRentPriceForPricingPeriodQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAvgRentPriceForPricingPeriodQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAvgRentPriceForPricingPeriodQueryResponse> Handle(GetAvgRentPriceForPricingPeriodQueryRequest request, CancellationToken cancellationToken)
        {

            decimal value=new decimal(0);

            if (request.PriceForWhat== "PerDay")
            {
                value = _statisticRepository.GetAvgRentPriceForDaily();
            }
            else if ( request.PriceForWhat == "PerWeek")
            {
                value = _statisticRepository.GetAvgRentPriceForWeekly();
            }
            else if (request.PriceForWhat == "PerMonth")
            {
                value = _statisticRepository.GetAvgRentPriceForMonthly();
            }

            return new GetAvgRentPriceForPricingPeriodQueryResponse()
            {
                avgRentPrice=value,
            };
        }
    }
}
