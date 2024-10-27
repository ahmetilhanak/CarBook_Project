using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IStatisticRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();
        decimal GetAvgRentPriceForDaily();
        decimal GetAvgRentPriceForWeekly();
        decimal GetAvgRentPriceForMonthly();
        int GetCarCountByAutoTransmission();
        string BrandNameHavingMaxCar();
        string BlogTitleHavingMaxComment();
        int GetCarCountKmSmallerThan1000();
        int GetCarCountByFuelGasolineOrDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandModelByRentPriceDailyMax();
        string GetCarBrandModelByRentPriceDailyMin();
            
    }
}
