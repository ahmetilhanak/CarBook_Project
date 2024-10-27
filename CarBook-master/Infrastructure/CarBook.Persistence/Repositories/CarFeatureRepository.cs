using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Dtos.CarFeatureDtos;
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
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _carBookContext;

        public CarFeatureRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public void CreateCarFeatureByCar(CarFeature carFeature)
        {
            _carBookContext.CarFeatures.Add(carFeature);

            _carBookContext.SaveChanges();

        }

        public List<CarFeature> GetCarFeatureByCarIdHavingFeature(int carId)
        {
            var values = _carBookContext.CarFeatures.Include(z=>z.Feature).Where(q=>q.CarID==carId).ToList();

            return values;
        }

        public void UpdateCarFeature(UpdateCarFeatureDto updateCarFeatureDto)
        {
            var featureId = _carBookContext.Features.Where(z => z.Name == updateCarFeatureDto.FeatureName).Select(w => w.FeatureID).FirstOrDefault();

            var carFeature = _carBookContext.CarFeatures.Where(z => z.CarFeatureID == updateCarFeatureDto.CarFeatureID).FirstOrDefault();
        }
    }
}
