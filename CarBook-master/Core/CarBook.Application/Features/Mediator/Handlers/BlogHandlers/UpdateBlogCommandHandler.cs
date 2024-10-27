using CarBook.Application.Features.Mediator.Commands.BlogCommands;
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
    public class UpdateBlogCommandHandler:IRequestHandler<UpdateBlogCommandRequest>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogID);

            value.AuthorID = request.AuthorID;
            value.CategoryID= request.CategoryID;
            value.CreatedDate = request.CreatedDate;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Title = request.Title;
            value.Description = request.Description;

            await _repository.UpdateAsync(value);
        }
    }
}
