using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Responses.ReviewResponses;
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
    public class GetReviewByCarIdQueryHandler:IRequestHandler<GetReviewByCarIdQueryRequest, List<GetReviewByCarIdQueryResponse>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewByCarIdQueryResponse>> Handle(GetReviewByCarIdQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _reviewRepository.GetReviewsByCarId(request.CarId);

            return values.Select(z=>new GetReviewByCarIdQueryResponse()
            {
                ReviewID=z.ReviewID,
                CarID=z.CarID,
                Comment=z.Comment,
                CustomerImage=z.CustomerImage,
                CustomerName=z.CustomerName,
                RaytingValue=z.RaytingValue,
                ReviewDate=z.ReviewDate
            }).ToList();
        }
    }
}
