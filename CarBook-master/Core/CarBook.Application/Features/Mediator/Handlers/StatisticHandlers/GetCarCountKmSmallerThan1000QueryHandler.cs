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
    public class GetCarCountKmSmallerThan1000QueryHandler:IRequestHandler<GetCarCountKmSmallerThan1000QueryRequest, GetCarCountKmSmallerThan1000QueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountKmSmallerThan1000QueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountKmSmallerThan1000QueryResponse> Handle(GetCarCountKmSmallerThan1000QueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCountKmSmallerThan1000();

            return new GetCarCountKmSmallerThan1000QueryResponse()
            {
                CarCountWithKmSmallar1000= value,
            };
        }
    }
}
