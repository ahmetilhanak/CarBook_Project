using CarBook.Application.Features.Mediator.Responses.LocationResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQueryRequest:IRequest<GetLocationByIdQueryResponse>
    {
        public GetLocationByIdQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
