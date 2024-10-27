using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _carBookContext;

        public CarPricingRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public List<CarPricing> GetCarPricingWithCars(string perWhat)
        {
            var pricingID=_carBookContext.Pricings.Where(z=>z.Name==perWhat).Select(q=>q.PricingID).FirstOrDefault();
            var values = _carBookContext.CarPricings.Include(z=>z.Car).ThenInclude(y=>y.Brand).Include(x=>x.Pricing).Where(z=>z.PricingID==pricingID).ToList();
            return values;
        }

		public List<CarPricing> GetCarPricingWithTimePeriod24()
		{
			throw new NotImplementedException();
		}

		public List<GetCarPricingWithTimePeriodDto> GetCarPricingWithTimePeriod()
		{
			var valueOfCarPricing = _carBookContext.CarPricings.GroupBy(z=>z.CarID).ToList();

            var valueOfCar23 = _carBookContext.Cars.ToList();
            var valueOfCar = _carBookContext.Cars.Include(z=>z.Brand).ToList();

            

            return valueOfCarPricing.Select(z=>new GetCarPricingWithTimePeriodDto()
            {                
                Model=valueOfCar.Where(a=>a.CarID==z.Key).Select(q=>q.Model).FirstOrDefault(),
                DailyAmount=z.Where(w=>w.PricingID==3).Select(q=>q.Amount).FirstOrDefault(),
                WeeklyAmount=z.Where(w=>w.PricingID==4).Select(q=>q.Amount).FirstOrDefault(),
                MonthlyAmount=z.Where(w=>w.PricingID==12).Select(q=>q.Amount).FirstOrDefault(),
                imageUrl= valueOfCar.Where(a => a.CarID == z.Key).Select(q => q.BigImageUrl).FirstOrDefault(),
                CarID=z.Key,
                Brand= valueOfCar.Where(a => a.CarID == z.Key).Select(w=>w.Brand.Name).FirstOrDefault()
			}).ToList();
		}

       
	}

    
}
