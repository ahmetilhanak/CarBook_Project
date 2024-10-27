using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GettingCarsWithPricingsQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GettingCarsWithPricingsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetCarWithPricingsQueryResult>> Handle()
        {
            //var values = _carRepository.GetCarAndPrice();
            var values = _carRepository.GetCarsWithPricings();

            return values.Select(z => new GetCarWithPricingsQueryResult
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
                PricingAmountList=z.CarPricings.Select(z=>z.Amount).ToList(),
                PricingNameList=z.CarPricings.Select(z=>z.Pricing).Select(z=>z.Name).ToList(),
                PricingAmount = z.CarPricings.Select(z => z.Amount).FirstOrDefault(),
                PricingName = z.CarPricings.Select(z => z.Pricing).Select(z => z.Name).FirstOrDefault(),
            }).ToList();

        }

    }
}
