using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents
{
    public class _ScriptsPartialVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
