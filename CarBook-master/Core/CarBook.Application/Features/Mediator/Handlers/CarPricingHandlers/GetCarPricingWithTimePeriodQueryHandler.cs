using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Responses.CarPricingResponses;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodQueryHandler:IRequestHandler<GetCarPricingWithTimePeriodQueryRequest, List<GetCarPricingWithTimePeriodQueryResponse>>
	{
		private readonly ICarPricingRepository _carPricingRepository;

		public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public async Task<List<GetCarPricingWithTimePeriodQueryResponse>> Handle(GetCarPricingWithTimePeriodQueryRequest request, CancellationToken cancellationToken)
		{
			var value = _carPricingRepository.GetCarPricingWithTimePeriod();

			return value.Select(z=>new GetCarPricingWithTimePeriodQueryResponse()
			{
				CarID=z.CarID,
				Model=z.Model,
				DailyAmount=z.DailyAmount,
				WeeklyAmount=z.WeeklyAmount,
				MonthlyAmount=z.MonthlyAmount,
				imageUrl=z.imageUrl,
				Brand=z.Brand,
			} ).ToList();
		}
	}
}
