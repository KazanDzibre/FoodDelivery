using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodDelivery.Models
{
	public class User
	{
		public int Id { get; set; } //Ovo ce prebacimo u GUID
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[Required]
		[MaxLength(50)]
		public string UserName { get; set; }
		[Required]
		[MaxLength(10)]
		public string Type { get; set; }  // vidi ovo dal da napravim sa nekim enum typeom, nzm za c# koja je fora videcemo

		//ovo ce se tice samo drivera
		public double longitude { get; set; }
		public double latitude { get; set; }

		public List<Order> orders = new List<Order>();

		[JsonIgnore]
		[Required]
		public string Password { get; set; }
	}
}
