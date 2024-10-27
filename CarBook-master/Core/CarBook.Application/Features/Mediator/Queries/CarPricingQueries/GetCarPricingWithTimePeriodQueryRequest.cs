using CarBook.Application.Features.Mediator.Responses.CarPricingResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries
{
	public class GetCarPricingWithTimePeriodQueryRequest:IRequest<List<GetCarPricingWithTimePeriodQueryResponse>>
	{
	}
}
