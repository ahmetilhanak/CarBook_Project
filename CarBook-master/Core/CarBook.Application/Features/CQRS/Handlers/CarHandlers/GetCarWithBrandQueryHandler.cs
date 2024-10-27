using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = _carRepository.GetCarWithBrand();

            return values.Select(z => new GetCarWithBrandQueryResult()
            {
                BigImageUrl = z.BigImageUrl,
                BrandID = z.BrandID,
                CarID = z.CarID,
                CoverImageUrl = z.CoverImageUrl,
                Fuel = z.Fuel,
                Km = z.Km,
                Luggage = z.Luggage,
                Model = z.Model,
                Seat = z.Seat,
                Transmission = z.Transmission,
                BrandName=z.Brand.Name,
                
                
            }).ToList();
        }
    }
}
