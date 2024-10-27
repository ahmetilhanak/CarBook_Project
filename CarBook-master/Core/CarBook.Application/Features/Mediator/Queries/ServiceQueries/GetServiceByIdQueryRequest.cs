using CarBook.Application.Features.Mediator.Responses.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceByIdQueryRequest : IRequest<GetServiceByIdQueryResponse>
    {
        public GetServiceByIdQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
