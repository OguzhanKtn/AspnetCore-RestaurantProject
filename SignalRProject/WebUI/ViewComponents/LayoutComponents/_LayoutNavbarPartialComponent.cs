using DtoLayer.NotificationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;


namespace WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarPartialComponent : ViewComponent
	{ 
		private readonly IHttpClientFactory _httpClientFactory;

		public _LayoutNavbarPartialComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:44302/api/Notification");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
