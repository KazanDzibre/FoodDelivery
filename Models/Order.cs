using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Models
{
	public class Order
	{
		public int Id { get; set; }
		[Required]
		public string Restaurant_id { get; set; }
		[Required]
		public string address { get; set; }
		
		public int DriverId { get; set; }
	}
}
