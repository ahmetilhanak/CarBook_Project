using CarBook.Application.Features.Mediator.Responses.AuthorResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorQueryRequest:IRequest<List<GetAuthorQueryResponse>>
    {
    }
}
