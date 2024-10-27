using CarBook.Dto.CarDtos;
using CarBook.Dto.CarFeatureDto;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.Controllers
{
	
    [Route("[controller]")]
	public class CarsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7094/api/Cars/CarListWithBrand");
            var responseMessage = await client.GetAsync("https://localhost:7094/api/CarPricing/GetCarPricingsWithCarsList/PerHour");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);


                return View(values);
            }

            return View();
        }

		[Route("[action]/{carId}")]

		public async Task<IActionResult> CarDetail(int carId)
        {
            ViewBag.CarId = carId;

			return View();

		}

    }
}
