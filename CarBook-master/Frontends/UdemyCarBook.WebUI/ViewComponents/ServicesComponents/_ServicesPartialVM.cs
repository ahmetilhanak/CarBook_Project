using CarBook.Dto.ServiceDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.ViewComponents.ServicesComponents
{
    public class _ServicesPartialVM : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServicesPartialVM(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Services/ServiceList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListServiceDto>>(jsonData);


                return View(values);
            }

            return View();
        }
    }

}
