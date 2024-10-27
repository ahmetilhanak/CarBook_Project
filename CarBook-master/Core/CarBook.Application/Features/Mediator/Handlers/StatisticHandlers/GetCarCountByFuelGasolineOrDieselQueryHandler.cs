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
    public class GetCarCountByFuelGasolineOrDieselQueryHandler:IRequestHandler<GetCarCountByFuelGasolineOrDieselQueryRequest, GetCarCountByFuelGasolineOrDieselQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByFuelGasolineOrDieselQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByFuelGasolineOrDieselQueryResponse> Handle(GetCarCountByFuelGasolineOrDieselQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCountByFuelGasolineOrDiesel();

            return new GetCarCountByFuelGasolineOrDieselQueryResponse()
            {
                CarCountUsingDieselAndGasoline = value,
            };
        }
    }
}
