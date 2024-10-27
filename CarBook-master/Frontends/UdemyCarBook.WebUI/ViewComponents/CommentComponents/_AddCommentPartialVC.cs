using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentComponents
{
    public class _AddCommentPartialVC: ViewComponent
    {
        public IViewComponentResult Invoke(int blogId)
        {
            ViewBag.BlogId = blogId;
            return View();
        }
    }
}
