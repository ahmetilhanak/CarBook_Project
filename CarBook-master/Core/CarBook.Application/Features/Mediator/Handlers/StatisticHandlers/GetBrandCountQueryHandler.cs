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
    public class GetBrandCountQueryHandler:IRequestHandler<GetBrandCountQueryRequest, GetBrandCountQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetBrandCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetBrandCountQueryResponse> Handle(GetBrandCountQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetBrandCount();

            return new GetBrandCountQueryResponse()
            {
                BrandCount= value,
            };
        }
    }
}
