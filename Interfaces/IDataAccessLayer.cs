using SocialMediaSite.Models;
using System.Collections.Generic;

namespace SocialMediaSite.Interfaces
{
	public interface IDataAccessLayer
	{
		IEnumerable<UserInfo> GetUsers();
		bool AddUser(UserInfo userInfo);
		void DeleteUser(UserInfo userInfo);
		UserInfo? GetUserById(string userID);
		UserInfo? GetUserByUsername(string username);
		bool UpdateUser(string userID, UserInfo userinfo);
		IEnumerable<UserInfo> SearchByUsername(string searchTerm);
		bool UniqueUsername(string userName);
		void NewPost(UserPost userPost);
		IEnumerable<UserPost> GetPostsOnUser(string userID);
		UserPost GetPostById(int postID);
		void EditPost(string userID, UserPost post);
		IEnumerable<string> GetImagesByUsername(string username);
		void DeletePost(string userID, UserPost post);
	}
}
