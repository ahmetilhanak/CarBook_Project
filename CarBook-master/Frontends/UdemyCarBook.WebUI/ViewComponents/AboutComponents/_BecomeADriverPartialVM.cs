using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.AboutComponents
{
    public class _BecomeADriverPartialVM : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
