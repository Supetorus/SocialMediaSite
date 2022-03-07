using System.ComponentModel.DataAnnotations;

namespace SocialMediaSite.Models
{
	public class UserInfo
	{
		[Required]
		public string ID { get; set; }
		[Required(ErrorMessage = "Username is required."),
			MinLength(5, ErrorMessage = "Username must have at least 5 characters."),
			MaxLength(50, ErrorMessage = "Username must have less than 50 characters."),
			Display(Name = "Username")]
		public string UserName { get; set; }
		[MaxLength(500, ErrorMessage = "Description can only be 500 characters.")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Age is required"),
			Range(13, int.MaxValue, ErrorMessage = "You must be 13 or older to make a profile.")]
		public int? Age { get; set; }
		public string Location { get; set; }
		public string Image { get; set; }
	}
}
