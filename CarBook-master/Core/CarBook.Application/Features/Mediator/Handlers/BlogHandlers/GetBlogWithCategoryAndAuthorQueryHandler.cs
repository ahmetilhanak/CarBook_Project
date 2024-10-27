using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Responses.BlogResponses;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogWithCategoryAndAuthorQueryHandler:IRequestHandler<GetBlogWithCategoryAndAuthorQueryRequest, List<GetBlogWithCategoryAndAuthorResponse>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogWithCategoryAndAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogWithCategoryAndAuthorResponse>> Handle(GetBlogWithCategoryAndAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetBlogWithCategoryAndAuthor();

            return values.Select(z => new GetBlogWithCategoryAndAuthorResponse()
            {
                BlogID = z.BlogID,
                AuthorID = z.AuthorID,
                AuthorName=z.Author.Name,               
                CategoryID = z.CategoryID,
                CategoryName= z.Category.Name,
                CoverImageUrl = z.CoverImageUrl,
                Title = z.Title,
                CreatedDate = z.CreatedDate,
                Description= z.Description
            }).ToList();
        }
    }
}
