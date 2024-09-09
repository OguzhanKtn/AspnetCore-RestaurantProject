using DtoLayer.BasketDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44302/api/Basket/4");

            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var response = await client.DeleteAsync($"https://localhost:44302/api/Basket/{id}");
        //    if(response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        public async Task<IActionResult> Delete(int id, int quantity = 1)
        {
            var client = _httpClientFactory.CreateClient();

            // PATCH isteği hazırlama
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
