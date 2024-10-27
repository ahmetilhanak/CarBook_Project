using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogDetailComponents
{
    public class _BlogDetailsMainPartialVC:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainPartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7094/api/Blogs/BlogList");
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Blogs/GetBlogByIdListWithAuthorAndCategory/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BlogByIdWithAuthorAndCategoryDto>(jsonData);

                // var values = JsonConvert.DeserializeObject<List<ListBlogDto>>(jsonData);



                return View(values);
            }

            return View();
        }
    }
}
