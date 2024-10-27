using CarBook.Dto.CarFeatureDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarFeatureByCarIdComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailCarFeatureByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7094/api/CarFeature/GetCarPricingsWithCarsList/{carId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                var features = JsonConvert.DeserializeObject<List<GetFeaturesOfCarByCarIdDto>>(jsonData);

                ViewBag.CarFeatures1 = features.Take(4);
                ViewBag.CarFeatures2 = features.Skip(4).Take(4);
                ViewBag.CarFeatures3 = features.Skip(8).Take(4);
                return View(features);

            }

            return View();
        }
    }
}
