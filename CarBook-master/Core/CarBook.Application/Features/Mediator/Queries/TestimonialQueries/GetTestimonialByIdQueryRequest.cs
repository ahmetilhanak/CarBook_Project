using CarBook.Application.Features.Mediator.Responses.TestimonialResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQueryRequest:IRequest<GetTestimonialByIdQueryResponse>
    {
        public GetTestimonialByIdQueryRequest()
        {
            
        }

        public GetTestimonialByIdQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
