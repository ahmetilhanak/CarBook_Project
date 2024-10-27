using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Responses.SocialMediaResponse;
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
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQueryRequest, List<GetTestimonialQueryResponse>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResponse>> Handle(GetTestimonialQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(z => new GetTestimonialQueryResponse()
            {
                Comment = z.Comment,
                ImageUrl = z.ImageUrl,
                Name = z.Name,
                TestimonialID = z.TestimonialID,
                Title = z.Title
            }).ToList();
        }
    }
}
