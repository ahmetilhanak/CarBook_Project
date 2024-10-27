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
    public class GetSomeBlogWithCategoryAndAuthorQueryHandler:IRequestHandler<GetSomeBlogWithCategoryAndAuthorQueryRequest,List<GetSomeBlogWithCategoryAndAuthorResponse>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetSomeBlogWithCategoryAndAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetSomeBlogWithCategoryAndAuthorResponse>> Handle(GetSomeBlogWithCategoryAndAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetSomeBlogWithCategoryAndAuthor(request.Id);

            return values.Select(z => new GetSomeBlogWithCategoryAndAuthorResponse()
            {
                BlogID = z.BlogID,
                AuthorID = z.AuthorID,
                AuthorName = z.Author.Name,
                CategoryID = z.CategoryID,
                CategoryName = z.Category.Name,
                CoverImageUrl = z.CoverImageUrl,
                Title = z.Title,
                CreatedDate = z.CreatedDate,
                Description= z.Description
            }).ToList();
        }
    }
}
