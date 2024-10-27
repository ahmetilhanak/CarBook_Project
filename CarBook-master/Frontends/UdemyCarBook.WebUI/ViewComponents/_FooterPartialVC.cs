using CarBook.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.ViewComponents
{
    public class _FooterPartialVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterPartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/FooterAddresses/FooterAddressList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListFooterDto>>(jsonData);


                return View(values.FirstOrDefault());
            }

            return View();
        }
    }
}
