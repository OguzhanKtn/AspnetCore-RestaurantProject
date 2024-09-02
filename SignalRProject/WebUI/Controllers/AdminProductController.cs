using DtoLayer.CategoryDto;
using DtoLayer.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers
{
	public class AdminProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:44302/api/Product");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:44302/api/Category");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				List<SelectListItem> categories = (from x in values
												select new SelectListItem
												{
													Text = x.Name,
													Value = x.Id.ToString()
												}).ToList();
				ViewBag.v = categories;
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductDto dto)
		{
			dto.Status = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:44302/api/Product", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> Delete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync("https://localhost:44302/api/Product?id=" + id);
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

			var response2 = await client.GetAsync("https://localhost:44302/api/Category");

			if (response2.IsSuccessStatusCode)
			{
				var jsonData2 = await response2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
				List<SelectListItem> categories = (from x in values2
												   select new SelectListItem
												   {
													   Text = x.Name,
													   Value = x.Id.ToString()
												   }).ToList();
				ViewBag.v = categories;
			}

			var response = await client.GetAsync($"https://localhost:44302/api/Product/{id}");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(value);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateProductDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync($"https://localhost:44302/api/Product", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
