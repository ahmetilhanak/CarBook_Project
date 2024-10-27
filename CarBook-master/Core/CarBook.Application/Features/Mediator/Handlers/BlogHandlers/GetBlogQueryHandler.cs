using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Responses.BlogResponses;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQueryRequest, List<GetBlogQueryResponse>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResponse>> Handle(GetBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(z => new GetBlogQueryResponse()
            {
                BlogID = z.BlogID,
                AuthorID = z.AuthorID,
                CategoryID = z.CategoryID,
                CoverImageUrl = z.CoverImageUrl,
                CreatedDate= DateTime.Now.Date,
                Title= z.Title,
                Description= z.Description,
            }).ToList();
        }
    }
}
