using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarBook.Dto.AboutDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7094/api/Blogs/BlogList");
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Blogs/BlogListWithAuthorAndCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListBlogWithAuthorAndCategoryDto>>(jsonData);

                // var values = JsonConvert.DeserializeObject<List<ListBlogDto>>(jsonData);



                return View(values);
            }

            return View();
        }

        
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.BlogId = id;
            ViewData["BlogId"] = id;
            return View();
        }
    }
}
