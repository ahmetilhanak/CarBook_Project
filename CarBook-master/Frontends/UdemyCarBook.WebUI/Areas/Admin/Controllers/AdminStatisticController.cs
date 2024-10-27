using CarBook.Dto.ServiceDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistic")]
    public class AdminStatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            #region CarCount _ way-2

            //var carCountData2 = await new ApiRun2<CarCountDto>(_httpClientFactory).RunIt(
            //    "https://localhost:7094/api/Statistics/GetCarCount",
            //    new CarCountDto());

            //ViewBag.carcount2 = carCountData2.carCount;

            #endregion

            #region CarCount

            var carCountData = await ApiRun<CarCountDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetCarCount",
                new CarCountDto());

            ViewBag.carcount = carCountData.carCount;

            #endregion

            #region LocationCount

            var locationCountdata = await ApiRun<LocationCountDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetLocationCount",
                new LocationCountDto());

            ViewBag.locationcount = locationCountdata.LocationCount;

            #endregion

            #region AuthorCount

            var authorcountdata = await ApiRun<AuthorCountDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetAuthorCount",
                new AuthorCountDto());

            ViewBag.authorcount = authorcountdata.AuthorCount;

            #endregion

            #region BlogCount

            var blogcountdata = await ApiRun<BlogCountDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetBlogCount",
                new BlogCountDto());

            ViewBag.blogcount = blogcountdata.BlogCount;

            #endregion

            #region BrandCount

            var brandcountdata = await ApiRun<BrandCountDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetBrandCount",
                new BrandCountDto());

            ViewBag.brandcount = brandcountdata.BrandCount;

            #endregion

            #region AvgRentPriceForDaily 

            var AvgRentPriceForDailydata = await ApiRun<AvgRentPriceForDailyDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetAvgRentPriceForDaily",
                new AvgRentPriceForDailyDto());

            ViewBag.AvgRentPriceDaily = AvgRentPriceForDailydata.AvgRentPrice;

            #endregion

            #region AvgRentPriceForWeekly

            var AvgRentPriceForWeeklydata = await ApiRun<AvgRentPriceForWeeklyDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetAvgRentPriceForWeekly",
                new AvgRentPriceForWeeklyDto());

            ViewBag.AvgRentPriceWeekly = AvgRentPriceForWeeklydata.AvgRentPrice;

            #endregion

            #region AvgRentPriceForMonthly

            var AvgRentPriceForMonthlydata = await ApiRun<AvgRentPriceForMonthlyDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetAvgRentPriceForMonthly",
                new AvgRentPriceForMonthlyDto());

            ViewBag.AvgRentPriceMonthly = AvgRentPriceForMonthlydata.AvgRentPrice;

            #endregion

            #region CarCountByAutoTransmission

            var CarCountByAutoTransmissiondata = await ApiRun<CarCountByAutoTransmissionDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetCarCountByAutoTransmission",
                new CarCountByAutoTransmissionDto());

            ViewBag.AutomaticCarCount = CarCountByAutoTransmissiondata.AutomaticCarCount;

            #endregion

            #region BrandNameHavingMaxCar

            var BrandNameHavingMaxCardata = await ApiRun<BrandNameHavingMaxCarDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/BrandNameHavingMaxCar",
                new BrandNameHavingMaxCarDto());

            ViewBag.BrandNameHavingMaxCar = BrandNameHavingMaxCardata.BrandWithMaxCar;

            #endregion

            #region BlogTitleHavingMaxComment

            var BlogTitleHavingMaxCommentdata = await ApiRun<BlogTitleHavingMaxCommentDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/BlogTitleHavingMaxComment",
                new BlogTitleHavingMaxCommentDto());

            ViewBag.BlogWithMaxComment = BlogTitleHavingMaxCommentdata.BlogWithMaxComment;

            #endregion

            #region CarCountWithKmSmallar1000

            var CarCountWithKmSmallar1000data = await ApiRun<CarCountWithKmSmallar1000Dto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetCarCountKmSmallerThan1000",
                new CarCountWithKmSmallar1000Dto());

            ViewBag.CarCountWithKmSmallar1000 = CarCountWithKmSmallar1000data.CarCountWithKmSmallar1000;

            #endregion

            #region CarCountByFuelGasolineOrDiesel

            var CarCountByFuelGasolineOrDieseldata = await ApiRun<CarCountByFuelGasolineOrDieselDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetCarCountByFuelGasolineOrDiesel",
                new CarCountByFuelGasolineOrDieselDto());

            ViewBag.CarCountUsingDieselAndGasoline = CarCountByFuelGasolineOrDieseldata.CarCountUsingDieselAndGasoline;

            #endregion

            #region CarCountByFuelElectric

            var CarCountByFuelElectricdata = await ApiRun<CarCountByFuelElectricDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetCarCountByFuelElectric",
                new CarCountByFuelElectricDto());

            ViewBag.CarCountUsingElectric = CarCountByFuelElectricdata.CarCountUsingElectric;

            #endregion

            #region GetCarBrandModelByRentPriceDailyMax

            var GetCarBrandModelByRentPriceDailyMaxdata = await ApiRun<GetCarBrandModelByRentPriceDailyMaxDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetCarBrandModelByRentPriceDailyMax",
                new GetCarBrandModelByRentPriceDailyMaxDto());

            ViewBag.CarBrandMaxDailyPriced = GetCarBrandModelByRentPriceDailyMaxdata.CarBrandMaxDailyPriced;

            #endregion

            #region GetCarBrandModelByRentPriceDailyMin

            var GetCarBrandModelByRentPriceDailyMindata = await ApiRun<GetCarBrandModelByRentPriceDailyMinDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetCarBrandModelByRentPriceDailyMin",
                new GetCarBrandModelByRentPriceDailyMinDto());

            ViewBag.CarBrandMinDailyPriced = GetCarBrandModelByRentPriceDailyMindata.CarBrandMinDailyPriced;

            #endregion

            return View();
        }
    }
}


public class ApiRun2<T> where T : class
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiRun2(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<T> RunIt(string RequestUrl,T classVM) {

        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.GetAsync(RequestUrl);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<T>(jsonData);
            return values;

        }

        return await Task.FromResult(default(T));

    }
}

public static class ApiRun<T> where T : class
{ 
    public static async Task<T> RunIt(HttpClient client,string RequestUrl, T classVM)
    {

        var responseMessage = await client.GetAsync(RequestUrl);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<T>(jsonData);
            return values;

        }

        return await Task.FromResult(default(T));

    }
}