using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Responses.AuthorResponses;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler:IRequestHandler<GetAuthorQueryRequest,List<GetAuthorQueryResponse>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResponse>> Handle(GetAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetAllAsync();

            return values.Select(z => new GetAuthorQueryResponse()
            {
                AuthorID = z.AuthorID,
                Name = z.Name,
                ImageUrl = z.ImageUrl,
                Description = z.Description,
                
            }).ToList();
            
        }
    }
}
