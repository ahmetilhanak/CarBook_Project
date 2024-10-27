using Microsoft.AspNetCore.SignalR;
using CarBook.WebApi.Hubs.Dtos;
using Newtonsoft.Json;

namespace CarBook.WebApi.Hubs
{
    public class CarHub:Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesssage= await client.GetAsync("https://localhost:7094/api/Statistics/GetCarCount");
            var jsonData = await responseMesssage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<CarCountDto>(jsonData);

            await Clients.All.SendAsync("ReceiveCarCount",values.carCount);

        }
    }
}
