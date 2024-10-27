using CarBook.Dto.CarDtos;
using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7094/api/Locations/LocationList");
            //if (responseMessage.IsSuccessStatusCode) { 
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ListLocationDto>>(jsonData);
            List<SelectListItem> LocationValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.LocationID.ToString()
                                                   }).ToList();

            List<SelectListItem> PickUpLocations=LocationValues.ToList();
            List<SelectListItem> DropOffpLocations=LocationValues.ToList();

            PickUpLocations.Insert(0,new SelectListItem()
            {
                Text="--- Select Pick-Up Location ---",
                Value=null
            });

            DropOffpLocations.Insert(0, new SelectListItem()
            {
                Text = "--- Select Drop-Off Location ---",
                Value = null
            });


            ViewBag.PickUpLocationList = PickUpLocations;
            ViewBag.DropOffLocationList = DropOffpLocations;

            ViewBag.CarId = id;


            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7094/api/Cars/CarListWithBrand");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData2);


                var CarBrand = values2.Where(z => z.CarID == id).Select(q=>q.BrandName).FirstOrDefault();
                ViewBag.CarBrand = CarBrand;
            }

            

            return View();
        }


        [HttpPost]

        public async Task<IActionResult> CreateReservation(CreateReservationDto createReservationDto)
        {
            createReservationDto.Status = "Reservation is taken";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7094/api/Reservations/CreateReservation", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index","Reservation");
        }
    }
}
