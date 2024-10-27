using CarBook.Dto.CarFeatureDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailTabPanelComponentPartialVM: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailTabPanelComponentPartialVM(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
