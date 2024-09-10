using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.BookATableComponents
{
    public class _BookATableNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
