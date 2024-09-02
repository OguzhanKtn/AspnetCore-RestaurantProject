using DtoLayer.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public AdminCategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44302/api/Category");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
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
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            dto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");

            var response = await client.PostAsync("https://localhost:44302/api/Category",stringContent);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
			var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:44302/api/Category?id=" + id);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
		}

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44302/api/Category/{id}");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(value);
            }
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Update(UpdateCategoryDto dto)
		{
			var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var response = await client.PutAsync($"https://localhost:44302/api/Category",stringContent);
			if (response.IsSuccessStatusCode)
			{
                return RedirectToAction("Index");
			}
			return View();
		}
	}
}
