using SocialMediaSite.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SocialMediaSite.Models
{
	public class SearchViewModel
	{
		[Display(Name = "Username")]
		public string SearchTerm { get; set; }
		public IEnumerable<UserInfo> Results { get; set; }
		public Condition Condition { get; set; }

		public void Generate(IDataAccessLayer dal)
		{
			Results = dal.SearchByUsername(SearchTerm);
			if (Condition.FilterCondition != FilterCondition.NONE)
			{
				Results = Results.Where(u => {
					return Condition.FloatCondition.CheckCondition((float)u.Age);
				});
			}
		}
	}

	public class Condition
	{
		[Display(Name = "Condition")]
		public FilterCondition FilterCondition { get; set; }
		public FloatCondition FloatCondition { get; set; }
	}

	public enum FilterCondition
	{
		[Display(Name = "None")]
		NONE,
		[Display(Name = "Age")]
		AGE,
	}
}
