using System.ComponentModel.DataAnnotations;

namespace SayHi.Models
{
	public class PersonModel
	{
		[Required]
		[Display(Name = "First Name")]
		public string FirstName
		{
			get; set;
		}

		[Required]
		[Display(Name = "Last Name")]
		public string LastName
		{
			get; set;
		}

		public string Greeting
		{
			get { return $"Hi {FirstName} {LastName}!"; }
		}

		public override string ToString()
		{
			return $"First Name: {FirstName}; Last Name: {LastName}; Greeting: {Greeting}";
		}
	}
}
