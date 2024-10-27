using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents
{
    public class _HeadPartialVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
