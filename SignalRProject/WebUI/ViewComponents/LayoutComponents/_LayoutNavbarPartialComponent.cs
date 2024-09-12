using DtoLayer.NotificationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;


namespace WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarPartialComponent : ViewComponent
	{ 
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
