using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutHeadPartialVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
