using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }
        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }
        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }
        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }
        public decimal GetAvgRentPriceForDaily()
        {
            //var value1 = _context.CarPricings.Include(z => z.Pricing).Where(w => w.Pricing.Name == "PerDay").Average(w => w.Amount);
            var id = _context.Pricings.Where(z => z.Name == "PerDay").Select(w => w.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(w => w.Amount);
            return value;
        }
        public decimal GetAvgRentPriceForMonthly()
        {
            var id = _context.Pricings.Where(z => z.Name == "PerMonth").Select(w => w.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(w => w.Amount);
            return value;
        }
        public decimal GetAvgRentPriceForWeekly()
        {
            var id = _context.Pricings.Where(z => z.Name == "PerWeek").Select(w => w.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(w => w.Amount);
            return value;
        }
        public int GetCarCountByAutoTransmission()
        {
            var value = _context.Cars.Where(z => z.Transmission == "Automatic").Count();
            return value;
        }
        public string BrandNameHavingMaxCar()
        {

            #region way -1

            //var brandIDs = _context.Brands.Select(z => z.BrandID).ToList();

            //string brand;
            //int carcount = 0;

            //string brand2 = "";
            //string brand3 = "";

            //int carCountCheck;
            //int carCountCheck2;



            //foreach (var item in brandIDs)
            //{
            //    brand = _context.Brands.Where(z => z.BrandID == item).Select(w => w.Name).FirstOrDefault();
            //    carCountCheck = _context.Cars.Where(z => z.BrandID == item).Count();
            //    if (carCountCheck >= carcount)
            //    {
            //        carcount = carCountCheck;
            //    }
            //}

            //foreach (var item in brandIDs)
            //{
            //    brand2 = _context.Brands.Where(z => z.BrandID == item).Select(w => w.Name).FirstOrDefault();
            //    carCountCheck2 = _context.Cars.Where(z => z.BrandID == item).Count();
            //    if (carCountCheck2 == carcount)
            //    {
            //        brand3 += brand2 + "-";
            //    }
            //}

            //return $"{brand3.TrimEnd('-')} with {carcount} max car count";

            #endregion


            #region way -2
            var groups = _context.Cars.GroupBy(x => x.BrandID).ToList();

            var maxGroupCount = groups.Max(g => g.Count());

            var maxGroups = groups.Where(g => g.Count() == maxGroupCount)
                                  .ToList();

      
            var idsOfBrandsHavingMaxCar=maxGroups.Select(z => z.Select(e => e.BrandID).FirstOrDefault()).ToList();

            var BrandsHavimgMaxCar = _context.Brands.Where(z => idsOfBrandsHavingMaxCar.Contains(z.BrandID)).ToList();


            if (idsOfBrandsHavingMaxCar.Count > 0) {

                return $"{string.Join(",", BrandsHavimgMaxCar.Select(z => z.Name))},{maxGroupCount}";
                //return $"{string.Join(",", BrandsHavimgMaxCar.Select(z => z.Name))} with {maxGroupCount} max car count";
            }
            else
            {
                return "There is no car";

            }



            #endregion
        }
        public string BlogTitleHavingMaxComment()
        {
            var commentsGroupedByBlogId = _context.Comments.GroupBy(x => x.BlogID).ToList();

            var maxCommentsCountByBlog = commentsGroupedByBlogId.Max(z => z.Count());

            var maxComments = commentsGroupedByBlogId.Where(z => z.Count() == maxCommentsCountByBlog).ToList();

            var idsOfBlogsHavingMaxComment = maxComments.Select(z => z.Select(e => e.BlogID).FirstOrDefault()).ToList();

            var BlogListHavingHavingMaxCommment = _context.Blogs.Where(z => idsOfBlogsHavingMaxComment.Contains(z.BlogID)).ToList();

            var blogs = string.Join(", ", BlogListHavingHavingMaxCommment.Select(z=>z.Title));
            
            return blogs+","+ maxCommentsCountByBlog;
            //return $"{string.Join(",", BlogListHavingHavingMaxCommment)}";
        }
        public int GetCarCountKmSmallerThan1000()
        {
            var values = _context.Cars.Where(z=>z.Km<1000);

            return values.Count();
        }
        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var values = _context.Cars.Where(z => z.Fuel == "Diesel" || z.Fuel == "Gasoline");

            return values.Count();
        }
        public int GetCarCountByFuelElectric()
        {
            var values = _context.Cars.Where(z => z.Fuel == "Electric");

            return values.Count();
        }
        public string GetCarBrandModelByRentPriceDailyMax()
        {
            var pricingIdOfPerDay = _context.Pricings.Where(z=>z.Name=="PerDay").Select(s=>s.PricingID).FirstOrDefault();

            var carsByDailyRent = _context.CarPricings.Where(z => z.PricingID == pricingIdOfPerDay).Max(z => z.Amount);

            var carIdsHavingDailyMaxPrice=_context.CarPricings.Where(z=>z.Amount==carsByDailyRent).Select(s=>s.CarID).ToList();

            var brandsHavingDailyMaxPrice = _context.Cars.Include(z => z.Brand).Where(w => carIdsHavingDailyMaxPrice.Contains(w.CarID)).Select(q=>q.Brand.Name).ToList();
            return string.Join(", ", brandsHavingDailyMaxPrice);
        }
        public string GetCarBrandModelByRentPriceDailyMin()
        {
            var pricingIdOfPerDay = _context.Pricings.Where(z => z.Name == "PerDay").Select(s => s.PricingID).FirstOrDefault();

            var carsByDailyRent = _context.CarPricings.Where(z => z.PricingID == pricingIdOfPerDay).Min(z => z.Amount);

            var carIdsHavingDailyMaxPrice = _context.CarPricings.Where(z => z.Amount == carsByDailyRent).Select(s => s.CarID).ToList();

            var brandsHavingDailyMaxPrice = _context.Cars.Include(z => z.Brand).Where(w => carIdsHavingDailyMaxPrice.Contains(w.CarID)).Select(q => q.Brand.Name).ToList();
            return string.Join(", ", brandsHavingDailyMaxPrice);
        }
    }

  

}
