using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Responses.TestimonialResponses;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler:IRequestHandler<GetTestimonialByIdQueryRequest,GetTestimonialByIdQueryResponse>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResponse> Handle(GetTestimonialByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetTestimonialByIdQueryResponse()
            {
                Comment = value.Comment,
                ImageUrl = value.ImageUrl,
                Name = value.Name,
                TestimonialID = value.TestimonialID,
                Title = value.Title
            };
        }
    }
}
