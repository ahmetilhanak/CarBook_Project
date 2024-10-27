using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AdminDashboardComponents
{
    public class _AdminDashboardBlogListComponentPartialVC: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardBlogListComponentPartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Blogs/BlogListWithAuthorAndCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListBlogWithAuthorAndCategoryDto>>(jsonData);


                return View(values);
            }

            return View();
        }
    }
}
