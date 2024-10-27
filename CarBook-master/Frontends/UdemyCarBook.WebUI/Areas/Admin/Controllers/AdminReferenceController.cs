using CarBook.Dto.ReferenceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers

{
    [Area("Admin")]
    [Route("Admin/AdminReference")]
    public class AdminReferenceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminReferenceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Testimonials/TestimonialList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListReferenceDto>>(jsonData);


                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateReference")]
        public async Task<IActionResult> CreateReference()
        {
            Type type = typeof(CreateReferenceDto);
            List<PropertyInfo> properties = type.GetProperties().ToList();
            ViewBag.properties = properties;

            return View();
        }

        [HttpPost]
        [Route("CreateReference")]
        public async Task<IActionResult> CreateReference(CreateReferenceDto createReferenceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReferenceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7094/api/Testimonials/CreateTestimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminReference", new { area = "Admin" });
            }
            return View();
        }


        [Route("RemoveReference/{id}")]
        public async Task<IActionResult> RemoveReference(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7094/api/Testimonials/RemoveTestimonial/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminReference", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminReference", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateReference/{id}")]
        public async Task<IActionResult> UpdateReference(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7094/api/Testimonials/GetTestimonial/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateReferenceDto>(jsonData);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateReference/{id}")]

        public async Task<IActionResult> UpdateReference(UpdateReferenceDto updateReferenceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateReferenceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7094/api/Testimonials/UpdateTestimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminReference", new { area = "Admin" });
            }
            return View();

        }
    }
}
