using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.ViewComponents.AboutComponents
{
    public class _SectionCounterPartialVM : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SectionCounterPartialVM(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region CarCount

            var carCountData = await ApiRun<CarCountDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetCarCount",
                new CarCountDto());

            ViewBag.carcount = carCountData.carCount;

            #endregion

            #region LocationCount

            var locationCountdata = await ApiRun<LocationCountDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetLocationCount",
                new LocationCountDto());

            ViewBag.locationcount = locationCountdata.LocationCount;

            #endregion

            #region AuthorCount

            var authorcountdata = await ApiRun<AuthorCountDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetAuthorCount",
                new AuthorCountDto());

            ViewBag.authorcount = authorcountdata.AuthorCount;

            #endregion

            #region BlogCount

            var blogcountdata = await ApiRun<BlogCountDto>.RunIt(
                _httpClientFactory.CreateClient(),
                "https://localhost:7094/api/Statistics/GetBlogCount",
                new BlogCountDto());

            ViewBag.blogcount = blogcountdata.BlogCount;

            #endregion

            return View();
        }
    }

    public static  class ApiRun24<T> where T : class
    {
        public static async Task<T> RunIt(HttpClient client, string RequestUrl, T classVM)
        {

            var responseMessage = await client.GetAsync(RequestUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<T>(jsonData);
                return values;

            }

            return await Task.FromResult(default(T));

        }
    }
}

