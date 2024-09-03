using DtoLayer.FeatureDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers
{
	public class AdminFeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminFeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:44302/api/Feature");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
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
		public async Task<IActionResult> Create(CreateFeatureDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:44302/api/Feature", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> Delete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync("https://localhost:44302/api/Feature?id=" + id);
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
			var response = await client.GetAsync($"https://localhost:44302/api/Feature/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
				return View(value);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateFeatureDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync($"https://localhost:44302/api/Feature", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
