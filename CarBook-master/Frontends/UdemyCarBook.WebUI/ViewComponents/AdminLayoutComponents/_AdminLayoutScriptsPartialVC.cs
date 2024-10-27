using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutScriptsPartialVC: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
