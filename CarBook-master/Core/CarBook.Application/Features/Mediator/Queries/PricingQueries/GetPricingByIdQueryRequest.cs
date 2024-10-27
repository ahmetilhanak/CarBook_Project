using CarBook.Application.Features.Mediator.Responses.PricingResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQueryRequest:IRequest<GetPricingByIdQueryResponse>
    {
        public GetPricingByIdQueryRequest(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
