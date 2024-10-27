using CarBook.Dto.BrandDtos;
using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace CarBook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarListFilterPartialVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _RentACarListFilterPartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> Invoke2Async()
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

            ViewBag.LocationList = LocationValues;

            //ViewBag.BrandList = values.Select(z => z.Name).ToList();
            //}    

            return View();

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            var token = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "accessToken").Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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

                ViewBag.LocationList = LocationValues;

            }
            return View();

        }

    }
}
