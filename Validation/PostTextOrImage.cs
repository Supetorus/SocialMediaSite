using SocialMediaSite.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaSite.Validation
{
	public class PostTextOrImage: ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			static string GetErrorMessage() => "A post must have either text or an image.";

			var post = (UserPost)validationContext.ObjectInstance;
			if (post.ImageID != null || post.Text != null)
				return ValidationResult.Success;
			else return new ValidationResult(GetErrorMessage());
		}
	}
}
