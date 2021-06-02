using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Dtos
{
	public class UserRegisterDto
	{
		[Required]
		[MaxLength(50)]
		public string UserName {get; set;}

		[Required]
		[MaxLength(10)]
		public string Type { get; set; }

		[Required]
		public string Password { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
