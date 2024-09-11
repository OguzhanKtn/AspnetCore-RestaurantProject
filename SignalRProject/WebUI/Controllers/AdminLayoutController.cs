using DtoLayer.NotificationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
		public IActionResult Index()
        {
           return View();
        }
    }
}
