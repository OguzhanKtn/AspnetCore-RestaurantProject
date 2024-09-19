using DtoLayer.IdentityDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(RegisterDto dto)
		{
			var appUser = new AppUser()
			{
				Name = dto.Name,
				Surname = dto.Surname,
				Email = dto.Mail,
				UserName = dto.Username
			};

			var result = await _userManager.CreateAsync(appUser, dto.Password);
			if(result.Succeeded)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
		}
	}
}
