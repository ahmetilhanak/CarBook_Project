using CarBook.Application.Features.Mediator.Responses.BlogResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByIdWithCategoryAndAuthorQueryRequest:IRequest<GetBlogByIdWithCategoryAndAuthorQueryResponse>
    {
        public GetBlogByIdWithCategoryAndAuthorQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
