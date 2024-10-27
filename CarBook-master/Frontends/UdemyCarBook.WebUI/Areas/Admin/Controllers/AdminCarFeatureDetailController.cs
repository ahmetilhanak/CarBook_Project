using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarFeatureDto;
using CarBook.Dto.CategoryDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[Area]/[controller]")]
    //[Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Index(int id)
        {


            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7094/api/Features/FeatureList");
            if (responseMessage2.IsSuccessStatusCode)
            {
                List<string> featureNames = new List<string>();

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData2);

                foreach (var item in values2)
                {
                    featureNames.Add(item.Name);
                }

                ViewBag.featureNames = featureNames;


            }


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7094/api/CarFeature/GetCarPricingsWithCarsList/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCarFeatureByCarIdDto>>(jsonData);


                return View(values);
            }

            


            return View();
          
        }


        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Index(List<GetCarFeatureByCarIdDto> resultCarFeatureByCarIdDtos) 
        {

            var client = _httpClientFactory.CreateClient();
            
            foreach (var item in resultCarFeatureByCarIdDtos)
            {
                var jsonData = JsonConvert.SerializeObject(item);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7094/api/CarFeature/UpdateCarFeature", stringContent);
            }

            return RedirectToAction("Index", "AdminCarFeatureDetail", new { area = "Admin" });

        }

        [HttpGet]
        [Route("[action]/{id}")]      
        public async Task<IActionResult> CreateFeatureByCarId(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7094/api/Features/FeatureList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDtoWithIsChecked>>(jsonData);
                ViewBag.carId=id;
                ViewBag.features = values;

                return View(values);
            }

            return View();

        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> CreateFeatureByCarId(List<ResultFeatureDtoWithIsChecked> featureDtoWithIsCheckeds,int id)
        {

            var client = _httpClientFactory.CreateClient();

            foreach (var item in featureDtoWithIsCheckeds)
            {
                if (item.IsChecked)
                {
                    var carFeature = new CreateCarFeatureDto()
                    {
                        CarID = id,
                        FeatureID = item.FeatureID,
                        Available = false,

                    };

                    var jsonData = JsonConvert.SerializeObject(carFeature);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:7094/api/CarFeature/CreateCarFeatureByCar", stringContent);
                }
                
            }

            return RedirectToAction("Index", "AdminCarFeatureDetail", new { area = "Admin",id=id });


        }
    }
}
