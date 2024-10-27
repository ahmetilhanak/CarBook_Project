using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Responses.PricingResponses;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQueryRequest, List<GetPricingQueryResponse>>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPricingQueryResponse>> Handle(GetPricingQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(z => new GetPricingQueryResponse()
            {
                PricingID = z.PricingID,
                Name=z.Name,
            }).ToList();
        }
    }
}
