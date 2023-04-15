using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialMediaSite.Data
{
	public class UsersDAL : IDataAccessLayer
	{
		private UserContext _userContext;

		public UsersDAL(UserContext userContext)
		{
			_userContext = userContext;
		}
		public bool AddUser(UserInfo userInfo)
		{
			if (_userContext.Users.Where(u => u.UserName == userInfo.UserName).FirstOrDefault() == null)
			{
				_userContext.Add(userInfo);
				_userContext.SaveChanges();
				return true;
			}
			return false;
		}
		public void DeletePost(string userID, UserPost post)
		{
			if (userID == post.PosterID || userID == post.PostedID)
			{
				_userContext.Remove(post);
				_userContext.SaveChanges();
			}
		}
		public void DeleteUser(UserInfo userInfo)
		{
			_userContext?.Remove(userInfo);
			_userContext.SaveChanges();
		}
		public void EditPost(string userID, UserPost post)
		{
			UserPost p = GetPostById(post.Id);
			if (p != null && p.PosterID == userID)
			{
				p.Text = post.Text;
				p.ImageID = post.ImageID;
				_userContext.SaveChanges();
			}
		}
		public IEnumerable<string> GetImagesByUsername(string username)
		{
			return _userContext.Posts.Where(p => p.PostedName == username).Select(p=>p.ImageID);
		}
		public UserPost GetPostById(int postID)
		{
			return _userContext.Posts.Where(p=>p.Id == postID).FirstOrDefault();
		}
		public IEnumerable<UserPost> GetPostsOnUser(string userID)
		{
			return _userContext.Posts.Where(p => p.PostedID == userID);
		}
		public UserInfo GetUserById(string userID)
		{
			return _userContext.Users.Where(u => u.ID == userID).FirstOrDefault();
		}
		public UserInfo GetUserByUsername(string username)
		{
			return _userContext.Users.Where(u => u.UserName == username).FirstOrDefault();
		}
		public IEnumerable<UserInfo> GetUsers()
		{
			return _userContext.Users;
		}
		public void NewPost(UserPost userPost)
		{
			_userContext.Add(userPost);
			_userContext.SaveChanges();
		}
		public IEnumerable<UserInfo> SearchByUsername(string searchTerm)
		{
			return _userContext.Users.Where(u => u.UserName.ToLower().Contains(searchTerm.ToLower()));
		}
		public bool IsUniqueUsername(string userName)
		{
			return !_userContext.Users.Where(u => u.UserName == userName).Any();
		}
		public bool UpdateUser(string userID, UserInfo newUserInfo)
		{
			var other = _userContext.Users.Where(u => u.UserName == newUserInfo.UserName).FirstOrDefault(); // Finds any other user with the same username
			UserInfo u = GetUserById(userID);
			if (other == null || other == u)
			{
				u.UserName = newUserInfo.UserName;
				u.Description = newUserInfo.Description;
				u.Age = newUserInfo.Age;
				u.Location = newUserInfo.Location;
				u.Image = newUserInfo.Image;
				_userContext.SaveChanges();
				return true;
			}
			return false;
		}
	}
}
