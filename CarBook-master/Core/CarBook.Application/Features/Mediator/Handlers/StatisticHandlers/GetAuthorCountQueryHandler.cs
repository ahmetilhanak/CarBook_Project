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
    public class GetAuthorCountQueryHandler:IRequestHandler<GetAuthorCountQueryRequest, GetAuthorCountQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAuthorCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAuthorCountQueryResponse> Handle(GetAuthorCountQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetAuthorCount();

            return new GetAuthorCountQueryResponse()
            {
                AuthorCount= value,
            };
        }
    }
}
