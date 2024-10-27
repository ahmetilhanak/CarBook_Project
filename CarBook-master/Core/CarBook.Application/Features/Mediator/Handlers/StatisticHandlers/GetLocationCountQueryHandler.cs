using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Responses.LocationResponses;
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
    public class GetLocationCountQueryHandler:IRequestHandler<GetLocationCountQueryRequest, GetLocationCountQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetLocationCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetLocationCountQueryResponse> Handle(GetLocationCountQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetLocationCount();

            return new GetLocationCountQueryResponse()
            {
                LocationCount = value
            };
        }
    }
}
