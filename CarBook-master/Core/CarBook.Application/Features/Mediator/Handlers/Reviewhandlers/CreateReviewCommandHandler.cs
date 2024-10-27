using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.Reviewhandlers
{
    public class CreateReviewCommandHandler:IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public CreateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var reviewNew = new Review()
            {
                CustomerName = request.CustomerName,
                CustomerImage = request.CustomerImage,
                Comment = request.Comment,
                ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                RaytingValue = request.RaytingValue,
                CarID = request.CarID,
            };

            await _repository.CreateAsync(reviewNew);
        }
    }
}
