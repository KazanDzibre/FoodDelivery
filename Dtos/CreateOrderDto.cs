using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Dtos
{
	public class CreateOrderDto
	{
		[Required]
		public string Restaurant { get; set; }

		[Required]
		public string Address { get; set; }
	}
}
