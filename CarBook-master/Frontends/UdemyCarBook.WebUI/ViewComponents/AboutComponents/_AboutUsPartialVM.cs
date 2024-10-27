using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarBook.Dto.AboutDtos;




namespace UdemyCarBook.WebUI.ViewComponents.AboutComponents
{
    public class _AboutUsPartialVM:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsPartialVM(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Abouts/AboutList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListAboutDto>>(jsonData);


                return View(values.FirstOrDefault());
            }

            return View();
        }
    }
}
