using CarBook.Application.Features.Mediator.Responses.StatisticResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetAvgRentPriceForPricingPeriodQueryRequest: IRequest<GetAvgRentPriceForPricingPeriodQueryResponse>
    {
        public GetAvgRentPriceForPricingPeriodQueryRequest(string priceForWhat)
        {
            PriceForWhat = priceForWhat;
        }

        public string PriceForWhat {  get; set; }
    }
}
