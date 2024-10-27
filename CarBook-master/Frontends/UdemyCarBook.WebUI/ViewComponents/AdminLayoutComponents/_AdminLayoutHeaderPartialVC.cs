using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutHeaderPartialVC: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
