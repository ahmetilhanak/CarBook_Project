using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.Controllers
{
    
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
       

        public PricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/CarPricing/GetCarPricingWithTimePeriod");

			if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCarPricingWithTimePeriodDto>>(jsonData);


                return View(values);
            }

            return View();
        }
    }
}
