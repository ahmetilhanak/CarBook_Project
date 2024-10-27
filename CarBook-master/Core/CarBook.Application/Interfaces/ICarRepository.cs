using CarBook.Application.Interfaces.Dtos;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICarRepository
    {
        //Task<List<Car>> GetCarWithBrandAsync();
        List<Car> GetCarWithBrand();
        List<Car> GetLast5CarsWithBrand(int count);
        List<Car> GetCarsWithPricings();
        List<CarWithPricingDto> GetCarsWithPricingsByDto();
        Tuple<List<Car>,List<CarPricing>> GetCarAndPrice();
       
        
    }
}
