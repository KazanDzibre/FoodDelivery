using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Dtos
{
	public class CreateOrderDto
	{
		[Required]
		public string Restaurant_id { get; set; }
		[Required]
		public string address { get; set; }
	}
}
