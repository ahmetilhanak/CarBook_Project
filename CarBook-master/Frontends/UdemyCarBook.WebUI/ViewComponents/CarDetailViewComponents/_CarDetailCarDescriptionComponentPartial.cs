using CarBook.Dto.CarDescriptionDtos;
using CarBook.Dto.CarFeatureDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarDescriptionComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailCarDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7094/api/CarDescriptions/GetCarDescriptionById/{carId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                var desciption = JsonConvert.DeserializeObject<GetCarDescriptionByCarIdDto>(jsonData);
                ViewBag.description = desciption.Details;
                return View();

            }

            return View();
        }

        //public IViewComponentResult Invoke(int carId)
        //{
        //    return View();
        //}

    }
}
