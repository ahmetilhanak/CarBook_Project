using CarBook.Dto.CarDtos;
using CarBook.Dto.CarPricingDtos;
using CarBook.Dto.RentACarDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string id, string? datepick, string? datedrop, string? timepick, string timedrop)
        {
            ViewBag.DatePick = datepick;
            ViewBag.DateDrop = datedrop;
            ViewBag.TimePick = timepick;
            ViewBag.TimeDrop = timedrop;


            ViewBag.LocationId = id;

            List<int> CarIds = new List<int>();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7094/api/RentACar/RentACarListByFilter/{id}/true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListRentACarDto>>(jsonData);

                foreach(var item in values)
                {
                    CarIds.Add(item.CarId);
                }

            }

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:7094/api/CarPricing/GetCarPricingsWithCarsList/PerDay");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData2);

                var cars = values2.Where(z => CarIds.Contains(z.CarId)).ToList();

                return View(cars);
            }

            return View();
        }
    }
}
