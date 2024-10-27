using CarBook.Application.Features.Mediator.Responses.PricingResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQueryRequest : IRequest<List<GetPricingQueryResponse>>
    {
    }
}
