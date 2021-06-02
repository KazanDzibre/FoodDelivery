using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data
{
	public class UserContext : DbContext
	{
		public UserContext(DbContextOptions<UserContext> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
	}
}
