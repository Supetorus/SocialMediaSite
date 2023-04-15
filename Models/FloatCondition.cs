using System.ComponentModel.DataAnnotations;

namespace SocialMediaSite.Models
{
	public class FloatCondition
	{
		public enum FloatConditionType
		{
			[Display(Name ="Less Than")]
			LESS_THAN,
			//[Display(Name ="Less than or Equal")]
			//LESS_THAN_OR_EQUAL,
			[Display(Name ="Greater than")]
			GREATER_THAN,
			//[Display(Name ="Greater than or Equal")]
			//GREATER_THAN_OR_EQUAL,
			[Display(Name ="Equal")]
			EQUAL
		}

		public float ComparisonValue { get; set; }
		public FloatConditionType Comparator { get; set; }

		public FloatCondition() { }

		public FloatCondition(FloatConditionType comparator, float compareByValue)
		{
			ComparisonValue = compareByValue;
			Comparator = comparator;
		}

		public bool CheckCondition(float value)
		{
			switch (Comparator)
			{
				case FloatConditionType.LESS_THAN:
					return value < ComparisonValue;
				//case FloatConditionType.LESS_THAN_OR_EQUAL:
				//	return value <= ComparisonValue;
				case FloatConditionType.GREATER_THAN:
					return value > ComparisonValue;
				//case FloatConditionType.GREATER_THAN_OR_EQUAL:
				//	return value >= ComparisonValue;
				case FloatConditionType.EQUAL:
					return value == ComparisonValue;
				default: return false;
			}
		}
	}
}
