using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminComment")]
    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7094/api/Comments/CommentListByBlogId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListCommentDto>>(jsonData);


                return View(values);
            }

            return View();
        }

        //[HttpGet]
        //[Route("CreateComment")]
        //public async Task<IActionResult> CreateComment()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Route("CreateComment")]
        //public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createCommentDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:7094/api/Comments/CreateComment", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "AdminComment", new { area = "Admin" });
        //    }
        //    return View();
        //}


        [Route("RemoveComment/{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7094/api/Comments/RemoveComment/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminComment", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminComment", new { area = "Admin" });
        }

        //[HttpGet]
        //[Route("UpdateComment/{id}")]
        //public async Task<IActionResult> UpdateComment(int id)
        //{

        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"https://localhost:7094/api/Comments/GetComment/{id}");

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var value = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);

        //        return View(value);
        //    }

        //    return View();
        //}

        //[HttpPost]
        //[Route("UpdateComment/{id}")]

        //public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateCommentDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("https://localhost:7094/api/Comments/UpdateComment", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "AdminComment", new { area = "Admin" });
        //    }
        //    return View();

        //}
    }
}
