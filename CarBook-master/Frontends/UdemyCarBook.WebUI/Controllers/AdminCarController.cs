using CarBook.Dto.BrandDtos;
using CarBook.Dto.AboutDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Cars/CarListWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);


                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Brands/BrandList");
            //if (responseMessage.IsSuccessStatusCode) { 
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ListBrandDto>>(jsonData);
            List<SelectListItem> brandValues = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();

            ViewBag.BrandList = brandValues;

            //ViewBag.BrandList = values.Select(z => z.Name).ToList();
            //}    

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            //createCarDto.Fuel = "Diesel";
            //createCarDto.BigImageUrl = createCarDto.CoverImageUrl;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7094/api/Cars/CreateCar", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("CreateCar");
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7094/api/Cars/RemoveCar/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");


        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client2 = _httpClientFactory.CreateClient();          
            var responseMessage2 = await client2.GetAsync("https://localhost:7094/api/Brands/BrandList");
            //if (responseMessage.IsSuccessStatusCode) { 
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ListBrandDto>>(jsonData2);
            List<SelectListItem> brandValues = (from x in values2
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();

            ViewBag.BrandList = brandValues;

            //-------------------------------------------------------------------------------------//

            var client1 = _httpClientFactory.CreateClient();
            var responseMessage = await client1.GetAsync($"https://localhost:7094/api/Cars/GetCar/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage.Content.ReadAsStringAsync();
                var value1 = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData1);

                return View(value1);
            }

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7094/api/Cars/UpdateCar", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("UpdateCar");

        }


        public IActionResult AdminCarDetail(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
