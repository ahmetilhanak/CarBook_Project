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
    public class UpdateReviewCommandHandler:IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public UpdateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _repository.GetByIdAsync(request.ReviewID);

            reviewToUpdate.CustomerName = request.CustomerName;
            reviewToUpdate.CustomerImage = request.CustomerImage;
            reviewToUpdate.Comment = request.Comment;
            reviewToUpdate.ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            reviewToUpdate.RaytingValue = request.RaytingValue;
            reviewToUpdate.CarID = request.CarID;

            await _repository.UpdateAsync(reviewToUpdate);
        }
    }
}
