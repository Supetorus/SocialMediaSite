using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;
using System.Security.Claims;

namespace SocialMediaSite.Controllers
{
	[Authorize]
	public class AuthController : Controller
	{
		IDataAccessLayer _dal;

		public AuthController(IDataAccessLayer dal)
		{
			_dal = dal;
		}
		public IActionResult UserEdits(UserInfo newUserInfo)
		{
			if (_dal.UpdateUser(getID(), newUserInfo))
			{
				UserInfoViewModel uivm = new UserInfoViewModel();
				uivm.UserInfo = _dal.GetUserById(getID());
				uivm.Posts = _dal.GetPostsOnUser(uivm.UserInfo.ID);

				ViewBag.ID = getID();
				return View("UserInfo", uivm);
			}
			ModelState.AddModelError("UserName", "That username is taken.");
			return View("EditUser", _dal.GetUserById(getID()));
		}
		public IActionResult EditUser()
		{
			ViewBag.ID = User.FindFirstValue(ClaimTypes.NameIdentifier);
			return View(_dal.GetUserById(getID()));
		}
		public IActionResult LoggedOut()
		{
			return View();
		}
		public IActionResult Search()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Search(SearchViewModel search)
		{
			search.Generate(_dal);
			return View(search);
		}
		public IActionResult UserInfo()
		{
			ViewBag.ID = getID();
			return View(_dal.GetUserById(getID()));
		}
		[HttpGet]
		public IActionResult UserInfo(string userID)
		{
			ViewBag.ID = getID();
			UserInfoViewModel uivm = new UserInfoViewModel();
			if (userID != null) uivm.UserInfo = _dal.GetUserById(userID);
			else uivm.UserInfo = _dal.GetUserById(getID());
			if (uivm.UserInfo != null) uivm.Posts = _dal.GetPostsOnUser(uivm.UserInfo.ID);
			return View(uivm);
		}
		public IActionResult GoToUser(string username)
		{
			ViewBag.ID = getID();
			UserInfoViewModel uivm = new UserInfoViewModel();
			uivm.UserInfo = _dal.GetUserByUsername(username);
			uivm.Posts = _dal.GetPostsOnUser(uivm.UserInfo.ID);
			return View("UserInfo", uivm);
		}
		[HttpPost]
		public IActionResult NewUser(UserInfoViewModel uivm)
		{
			if (!_dal.UniqueUsername(uivm.UserInfo.UserName)) ModelState.AddModelError("UserName", "That username is taken.");
			ViewBag.ID = getID();
			if (ModelState.IsValid)
			{
				_dal.AddUser(uivm.UserInfo);
				return View("UserInfo", uivm);
			}
			return View("UserInfo");
		}
		public IActionResult NewPost(string posterID, string postedID, string text, string image)
		{
			_dal.NewPost(new UserPost(posterID, _dal.GetUserById(posterID).UserName, postedID, _dal.GetUserById(postedID).UserName, text, image));

			UserInfoViewModel uivm = new UserInfoViewModel();
			uivm.UserInfo = _dal.GetUserById(postedID);
			uivm.Posts = _dal.GetPostsOnUser(uivm.UserInfo.ID);
			ViewBag.ID = getID();
			return View("UserInfo", uivm);
		}
		public IActionResult EditPost(int postID)
		{
			ViewBag.ID = getID();
			return View(_dal.GetPostById(postID));
		}
		public IActionResult DeletePost(int postID)
		{
			UserPost post = _dal.GetPostById(postID);
			_dal.DeletePost(getID(), post);
			ViewBag.ID = getID();
			UserInfoViewModel uivm = new UserInfoViewModel();
			uivm.UserInfo = _dal.GetUserById(post.PostedID);
			uivm.Posts = _dal.GetPostsOnUser(uivm.UserInfo.ID);
			return View("UserInfo", uivm);
		}
		public IActionResult PostEdit(UserPost post)
		{
			_dal.EditPost(getID(), post);

			UserInfoViewModel uivm = new UserInfoViewModel();
			uivm.UserInfo = _dal.GetUserById(post.PostedID);
			uivm.Posts = _dal.GetPostsOnUser(uivm.UserInfo.ID);

			ViewBag.ID = getID();
			return View("UserInfo", uivm);
		}
		public IActionResult UserImages(string username)
		{
			ViewBag.Username = username;
			return View(_dal.GetImagesByUsername(username));
		}

		private string getID()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
