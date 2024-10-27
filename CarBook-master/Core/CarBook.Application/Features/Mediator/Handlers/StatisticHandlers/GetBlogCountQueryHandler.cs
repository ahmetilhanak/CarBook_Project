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
    public class GetBlogCountQueryHandler:IRequestHandler<GetBlogCountQueryRequest, GetBlogCountQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetBlogCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetBlogCountQueryResponse> Handle(GetBlogCountQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetBlogCount();

            return new GetBlogCountQueryResponse()
            {
                BlogCount=value,
            };
        }
    }
}
