using CarBook.Application.Interfaces.Dtos.CarFeatureDtos;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeatureByCarIdHavingFeature(int carId);

        void UpdateCarFeature(UpdateCarFeatureDto updateCarFeatureDto);
        void CreateCarFeatureByCar(CarFeature carFeature);
    }
}
