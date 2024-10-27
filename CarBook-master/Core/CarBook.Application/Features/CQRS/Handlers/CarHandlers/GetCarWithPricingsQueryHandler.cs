using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithPricingsQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithPricingsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetCarWithPricingsQueryResult>> Handle()
        {
            var values = _carRepository.GetCarAndPrice();
            var values1 = values.Item1;
            var values2 = values.Item2;

            return values1.Select(z=>new GetCarWithPricingsQueryResult
            {
                CarID = z.CarID,
                BigImageUrl = z.BigImageUrl,
                BrandID = z.BrandID,
                BrandName = z.Brand.Name,
                CoverImageUrl = z.CoverImageUrl,
                Fuel = z.Fuel,
                Km = z.Km,
                Luggage = z.Luggage,
                Model = z.Model,
                Transmission = z.Transmission,  
                Seat = z.Seat,
                PricingAmountList=values2.Where(r=>r.CarID==z.CarID).Select(z=>z.Amount).ToList(),
                PricingNameList=values2.Where(r => r.CarID == z.CarID).Select(z=>z.Pricing).Select(z=>z.Name).ToList(),
                PricingAmount= values2.Where(r => r.CarID == z.CarID).Select(z => z.Amount).FirstOrDefault(),
                PricingName = values2.Where(r => r.CarID == z.CarID).Select(z => z.Pricing).Select(z => z.Name).FirstOrDefault()
            }).ToList();
            
        }
    }
}
