using SocialMediaSite.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaSite.Models
{
	public class UserPost
	{
		public int Id { get; set; }
		[MaxLength(255, ErrorMessage = "Your post can't be longer than 255 characters."),
			PostTextOrImage]
		public string Text { get; set; }
		public string ImageID { get; set; }
		public string PosterID { get; set; }
		public string PostedID { get; set; }
		public string PosterName { get; set; }
		public string PostedName { get; set; }
		public DateTime PostDate { get; set; }
		public UserPost()
		{

		}
		public UserPost(string posterID, string posterName, string postedID, string postedName, string text, string image)
		{
			PosterID = posterID;
			PostedID = postedID;
			PosterName = posterName;
			PostedName = postedName;
			Text = text;
			ImageID = image;
			PostDate = DateTime.Now;
		}
	}
}
