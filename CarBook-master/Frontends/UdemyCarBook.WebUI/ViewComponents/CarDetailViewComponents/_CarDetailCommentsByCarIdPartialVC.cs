using CarBook.Dto.CarDescriptionDtos;
using CarBook.Dto.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentsByCarIdPartialVC: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailCommentsByCarIdPartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7094/api/Reviews/ReviewListByCarId/{carId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                var reviews = JsonConvert.DeserializeObject<List<GetReviewByCarIdDto>>(jsonData);
                
                return View(reviews);

            }

            return View();
        }
    }
}
