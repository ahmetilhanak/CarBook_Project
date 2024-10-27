using CarBook.Application.Features.Mediator.Responses.ReviewResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewByCarIdQueryRequest:IRequest<List<GetReviewByCarIdQueryResponse>>
    {
        public GetReviewByCarIdQueryRequest(int carId)
        {
            CarId = carId;
        }

        public int CarId { get; set; }
    }
}
