using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Dtos;
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
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _carBookContext;

        public CarRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public Tuple<List<Car>, List<CarPricing>> GetCarAndPrice()
        {
            var carPricings = _carBookContext.CarPricings.Include(z => z.Car).Include(z => z.Pricing).ToList();

            var cars = _carBookContext.Cars.Include(z => z.Brand).ToList();

            return new Tuple<List<Car>, List<CarPricing>>(cars,carPricings);
        }

        

        public List<Car> GetCarsWithPricings()
        {
            var cars = _carBookContext.Cars.Include(z => z.Brand).Include(z => z.CarPricings).ThenInclude(z => z.Pricing).ToList();
            return cars;
        }

        public List<CarWithPricingDto> GetCarsWithPricingsByDto()
        {
            var carPricings= _carBookContext.CarPricings.Include(z => z.Car).Include(z => z.Pricing).ToList();
            
            var cars =  _carBookContext.Cars.Include(z=>z.Brand).ToList();

            

            //var deneme = cars.Select(z=>new CarWithPricingDto()
            //{
            //    CarID = z.CarID,
            //    BigImageUrl = z.BigImageUrl,
            //    BrandID = z.BrandID,
            //    BrandName=z.Brand.Name,
            //    CoverImageUrl=z.CoverImageUrl,
            //    Fuel=z.Fuel,
            //    Km=z.Km,
            //    Luggage=z.Luggage,
            //    Model=z.Model,
            //    Seat = z.Seat,
            //    Transmission=z.Transmission,
                


            //}).ToList();
            throw new NotImplementedException();
        }

        public List<Car> GetCarWithBrand()
        {
            var values = _carBookContext.Cars.Include(z => z.Brand).ToList();

            return values;
        }

        public List<Car> GetLast5CarsWithBrand(int count)
        {
            return _carBookContext.Cars.Include(z => z.Brand).OrderByDescending(z => z.CarID).Take(count).ToList();

        }

      
    }
}
