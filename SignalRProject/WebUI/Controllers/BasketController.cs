using DtoLayer.BasketDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;
        public BasketController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            int userId =Convert.ToInt32(_userManager.GetUserId(User));
  
            var response = await client.GetAsync($"https://localhost:44302/api/Basket/{userId}");

            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }

      
        public async Task<IActionResult> Delete(int id, int quantity = 1)
        {
            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Patch, $"https://localhost:44302/api/Basket/{id}")
            {
                Content = new StringContent(quantity.ToString(), System.Text.Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
