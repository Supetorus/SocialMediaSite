using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaSite.Controllers
{
	[Authorize]
	public class AuthController : Controller
	{
		public IActionResult EditUser()
		{
			return View();
		}

		public IActionResult LoggedOut()
		{
			return View();
		}

		public IActionResult Search()
		{
			return View();
		}

		public new IActionResult User()
		{
			return View();
		}
	}
}
