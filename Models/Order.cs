using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Models
{
	public class Order
	{
		public int Id { get; set; }

		[Required]
		public string Restaurant { get; set; }
									
		[Required]
		public string Address { get; set; }
		
		public User? Driver{ get; set; }
	}
}
