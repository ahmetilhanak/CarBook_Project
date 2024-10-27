using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.ViewComponents.ContactComponents
{
    public class _MessageBoxPartialVC:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public IViewComponentResult Invoke()
        {
            return View();
        }

        [HttpPost]
        public async Task<IViewComponentResult> InvokePost(CreateContactDto createContactDto)
        {
            createContactDto.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7094/api/Contacts/CreateContact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                //return RedirectToAction("Index", "MainPage");
            }

            return View();
        }
    }
}
