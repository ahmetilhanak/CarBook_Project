using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Responses.CarPricingResponses
{
	public class GetCarPricingWithTimePeriodQueryResponse
	{
		public int CarID { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }
		public decimal DailyAmount { get; set; }
		public decimal WeeklyAmount { get; set; }
		public decimal MonthlyAmount { get; set; }
		public string imageUrl { get; set; }
	}
}
