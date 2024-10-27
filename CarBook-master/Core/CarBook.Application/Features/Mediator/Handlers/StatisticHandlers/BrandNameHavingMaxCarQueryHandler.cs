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
    public class BrandNameHavingMaxCarQueryHandler:IRequestHandler<BrandNameHavingMaxCarQueryRequest, BrandNameHavingMaxCarQueryResponse>
    {
        private readonly IStatisticRepository _statisticRepository;

        public BrandNameHavingMaxCarQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<BrandNameHavingMaxCarQueryResponse> Handle(BrandNameHavingMaxCarQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.BrandNameHavingMaxCar();

            return new BrandNameHavingMaxCarQueryResponse()
            {
                BrandWithMaxCar = value,
            };
        }
    }
}
