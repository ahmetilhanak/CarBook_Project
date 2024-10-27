using CarBook.Dto.CarFeatureDto;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainFeaturePartialVC: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailMainFeaturePartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/CarPricing/GetCarPricingsWithCarsList/PerHour");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);

                var value = values.Where(z => z.CarId == carId).FirstOrDefault();

                return View(value);
            }

            return View();
        }
    }
}
