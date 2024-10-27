using CarBook.Dto.CarDtos;
using CarBook.Dto.CarPricingDtos;
using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents
{
    public class _VehiclePartialVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _VehiclePartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            //int carcount = 5;
            //var responseMessage = await client.GetAsync("https://localhost:7094/api/Cars/GetLastSomeCarsWithBrand/"+carcount);
            var responseMessage = await client.GetAsync("https://localhost:7094/api/CarPricing/GetCarPricingsWithCarsList/PerHour");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultLastSomeCarsWithBrandDto>>(jsonData);
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);

                
                return View(values);
            }

            return View();
        }
    }
}

