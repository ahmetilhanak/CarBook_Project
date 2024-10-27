using CarBook.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetLastSomeCarsWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetLastSomeCarsWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetLastSomeCarsWithBrandQueryResult>> Handle(GetLastSomeCarsWithBrandQuery getLastSomeCarsWithBrandQuery)
        {
            var values = _carRepository.GetLast5CarsWithBrand(getLastSomeCarsWithBrandQuery.CarCount);

            return values.Select(z => new GetLastSomeCarsWithBrandQueryResult ()
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
                BrandName=z.Brand.Name
            }).ToList();
        }
    }
}
