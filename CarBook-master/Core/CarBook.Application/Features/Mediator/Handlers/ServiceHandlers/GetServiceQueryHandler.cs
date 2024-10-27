using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Responses.ServiceResponses;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler:IRequestHandler<GetServiceQueryRequest,List<GetServiceQueryResponse>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResponse>> Handle(GetServiceQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(z => new GetServiceQueryResponse()
            {
                ServiceID=z.ServiceID,
                Description=z.Description,
                IconUrl=z.IconUrl,
                Title=z.Title,
            }).ToList();
        }
    }
}
