using CarBook.Dto.CarDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int BlogId,string Name,string Description,string email)
        {
            AddCommentDto addCommentDto = new AddCommentDto()
            {
                BlogID = BlogId,
                Name = Name,
                Description = Description,
                Email=email,
                CreatedDate= DateTime.Now
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7094/api/Comments/CreateComment", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BlogDetail", "Blog", new { id = addCommentDto.BlogID });
            }
            return RedirectToAction("BlogDetail", "Blog", new { id = addCommentDto.BlogID });

        }
    }
}
