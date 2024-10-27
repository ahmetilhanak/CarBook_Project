using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents
{
    public class _NavbarPartialVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
