using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Responses.TagCloudResponses;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudsByBlogIdQueryHandler:IRequestHandler<GetTagCloudsByBlogIdQueryRequest,List<GetTagCloudsByBlogIdQueryResponse>>
    {
        private readonly ITagCloudRepository _tagCloudRepository;

        public GetTagCloudsByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudsByBlogIdQueryResponse>> Handle(GetTagCloudsByBlogIdQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _tagCloudRepository.ListTagCloudByBlog(request.Id);

            return values.Select(z=>new GetTagCloudsByBlogIdQueryResponse()
            {               
                TagCloudID = z.TagCloudID,
                Title=z.Title,
                BlogID = z.BlogID,
            }).ToList();
        }
    }
}
