using System.Collections.Generic;

namespace SocialMediaSite.Models
{
	public class UserInfoViewModel
	{
		public UserInfo UserInfo { get; set; }
		public IEnumerable<UserPost> Posts { get; set; }
	}
}
