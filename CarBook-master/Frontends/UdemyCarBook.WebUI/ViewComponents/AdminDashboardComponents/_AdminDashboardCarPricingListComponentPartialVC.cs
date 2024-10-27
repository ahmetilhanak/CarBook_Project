using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarBook.Dto.CarPricingDtos;



namespace CarBook.WebUI.ViewComponents.AdminDashboardComponents
{
    public class _AdminDashboardCarPricingListComponentPartialVC: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardCarPricingListComponentPartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
