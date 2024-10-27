using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Responses.TagCloudResponses;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudsQueryHandler:IRequestHandler<GetTagCloudsQueryRequest,List<GetTagCloudsQueryResponse>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudsQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudsQueryResponse>> Handle(GetTagCloudsQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(z => new GetTagCloudsQueryResponse()
            {              
                TagCloudID = z.TagCloudID,
                Title=z.Title,
                BlogID = z.BlogID,
            }).ToList();
        }
    }
}
