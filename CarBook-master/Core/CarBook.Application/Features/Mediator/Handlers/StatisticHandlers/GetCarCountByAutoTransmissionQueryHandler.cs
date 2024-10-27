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
    public class GetCarCountByAutoTransmissionQueryHandler:IRequestHandler<GetCarCountByAutoTransmissionQueryRequest, GetCarCountByAutoTransmissionQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByAutoTransmissionQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByAutoTransmissionQueryResponse> Handle(GetCarCountByAutoTransmissionQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCountByAutoTransmission();

            return new GetCarCountByAutoTransmissionQueryResponse()
            {
                AutomaticCarCount=value,
            };
        }
    }
}
