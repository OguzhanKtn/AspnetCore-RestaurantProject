using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
