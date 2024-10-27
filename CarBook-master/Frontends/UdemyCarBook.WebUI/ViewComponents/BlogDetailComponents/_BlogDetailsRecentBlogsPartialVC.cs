using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.BlogDetailComponents
{
    public class _BlogDetailsRecentBlogsPartialVC: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsRecentBlogsPartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            int count = 3;
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Blogs/BlogSomeListWithAuthorAndCategory/" + count);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListSomeBlogWithAuthorAndCategoryDto>>(jsonData);


                return View(values);
            }

            return View();
        }
    }
}
