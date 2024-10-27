using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutFooterPartialVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
