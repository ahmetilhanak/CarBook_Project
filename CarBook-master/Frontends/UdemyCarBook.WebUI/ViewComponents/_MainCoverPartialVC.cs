using CarBook.Dto.BannerDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.ViewComponents
{
    public class _MainCoverPartialVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MainCoverPartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Banners/BannerList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListBannerDto>>(jsonData);


                return View(values.FirstOrDefault());
            }

            return View();
        }
    }
}
