using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}
