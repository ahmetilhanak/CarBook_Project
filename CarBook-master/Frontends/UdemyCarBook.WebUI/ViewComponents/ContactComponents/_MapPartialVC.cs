using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ContactComponents
{
    public class _MapPartialVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
