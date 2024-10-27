using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _carBookContext;

        public CarDescriptionRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public CarDescription GetCarDescriptionById(int id)
        {
            return _carBookContext.CarDescriptions.Where(x => x.CarID == id).FirstOrDefault();
        }
    }
}
