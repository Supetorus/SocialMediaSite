using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialMediaSite.Models;
using System.Diagnostics;

namespace SocialMediaSite.Controllers
{
	public class HomeController : Controller
	{
		//private readonly ILogger<HomeController> _logger;
		private readonly SignInManager<IdentityUser> _signInManager;
		//private readonly UserManager<IdentityUser> _userManager;

		public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> SignInManager, UserManager<IdentityUser> UserManager)
		{
			//_logger = logger;
			_signInManager = SignInManager;
			//_userManager = UserManager;
		}

		public IActionResult Home()
		{
			if (_signInManager.IsSignedIn(User))
			{
				return Redirect("/Auth/UserInfo");
			}
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult LoggedOut()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
