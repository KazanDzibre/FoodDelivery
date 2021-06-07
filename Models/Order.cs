using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Models
{
	public class Order : Entity
	{
		[Required]
		public string Restaurant { get; set; }
									
		[Required]
		public string Address { get; set; }
		
		public User User{ get; set; }

		public int DriverId { get; set; }
	}
}
