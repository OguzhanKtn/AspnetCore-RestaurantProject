using DtoLayer.MessageDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SendMessage() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto messageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(messageDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");

            var response = await client.PostAsync("https://localhost:44302/api/Message", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
