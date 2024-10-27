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
    public class GetBlogByIdWithCategoryAndAuthorQueryHandler:IRequestHandler<GetBlogByIdWithCategoryAndAuthorQueryRequest, GetBlogByIdWithCategoryAndAuthorQueryResponse>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByIdWithCategoryAndAuthorQueryHandler(Interfaces.IBlogRepository repository)
        {
            _repository = repository;
        }

        public async  Task<GetBlogByIdWithCategoryAndAuthorQueryResponse> Handle(GetBlogByIdWithCategoryAndAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBlogByIdWithCategoryAndAuthor(request.Id);

            return new GetBlogByIdWithCategoryAndAuthorQueryResponse()
            {
                BlogID = value.BlogID,
                AuthorID = value.AuthorID,
                AuthorName=value.Author.Name,
                CategoryID=value.CategoryID,
                CategoryName=value.Category.Name,
                CoverImageUrl=value.CoverImageUrl,
                CreatedDate=value.CreatedDate,
                Description=value.Description,
                Title = value.Title,
                AuthorImageUrl=value.Author.ImageUrl,
                AuthorDescription=value.Author.Description
                                
            };
        }
    }
}
