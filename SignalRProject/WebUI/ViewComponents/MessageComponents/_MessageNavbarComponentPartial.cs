using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.MessageComponents
{
    public class _MessageNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
