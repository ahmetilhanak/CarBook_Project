using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutLeftSideBarPartialVC: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
