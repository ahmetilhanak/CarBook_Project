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
    public class GetCarCountByFuelElectricQueryHandler:IRequestHandler<GetCarCountByFuelElectricQueryRequest, GetCarCountByFuelElectricQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByFuelElectricQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByFuelElectricQueryResponse> Handle(GetCarCountByFuelElectricQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCountByFuelElectric();

            return new GetCarCountByFuelElectricQueryResponse()
            {
                CarCountUsingElectric= value,
            };
        }
    }
}
