using CarBook.Application.Features.Mediator.Responses.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQueryRequest:IRequest<List<GetServiceQueryResponse>>
    {
    }
}
