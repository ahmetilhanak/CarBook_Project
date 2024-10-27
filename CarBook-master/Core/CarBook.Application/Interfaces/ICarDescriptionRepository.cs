using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICarDescriptionRepository
    {
        CarDescription GetCarDescriptionById(int id);
    }
}
