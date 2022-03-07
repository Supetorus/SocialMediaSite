using Microsoft.EntityFrameworkCore;
using SocialMediaSite.Models;

namespace SocialMediaSite.Data
{
	public class UserContext: DbContext
	{
		public DbSet<UserInfo> Users { get; set; }
		public DbSet<UserPost> Posts { get; set; }
		public UserContext(DbContextOptions options) : base(options)
		{

		}
	}
}
