using DtoLayer.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace WebUI.Controllers
{
	public class AdminAboutController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public AdminAboutController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:44302/api/About");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateAboutDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:44302/api/About", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:44302/api/About/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
				return View(value);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateAboutDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync($"https://localhost:44302/api/About", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
