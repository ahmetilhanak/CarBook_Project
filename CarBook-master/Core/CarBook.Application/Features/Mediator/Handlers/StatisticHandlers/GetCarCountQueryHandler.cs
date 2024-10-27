using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Responses.StatisticResponses;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountQueryHandler:IRequestHandler<GetCarCountQueryRequest,GetCarCountQueryResponse>
    {
        private readonly IStatisticRepository _repository;

        public GetCarCountQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountQueryResponse> Handle(GetCarCountQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCount();
            return new GetCarCountQueryResponse()
            {
                CarCount =value
            }; 

        }
    }
}
