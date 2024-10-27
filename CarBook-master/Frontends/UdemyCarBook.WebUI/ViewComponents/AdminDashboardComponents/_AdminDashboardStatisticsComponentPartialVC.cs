using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminDashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartialVC: ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartialVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() {

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
}
