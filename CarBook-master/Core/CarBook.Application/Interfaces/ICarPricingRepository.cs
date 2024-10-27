using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICarPricingRepository
    {
        List<CarPricing> GetCarPricingWithCars(string perWhat);
        List<CarPricing> GetCarPricingWithTimePeriod24();
        List<GetCarPricingWithTimePeriodDto> GetCarPricingWithTimePeriod();
    }

    public class GetCarPricingWithTimePeriodDto
	{
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
		public decimal DailyAmount { get; set; }
		public decimal WeeklyAmount { get; set; }
		public decimal MonthlyAmount { get; set; }
        public string imageUrl { get; set; }
    }
}
