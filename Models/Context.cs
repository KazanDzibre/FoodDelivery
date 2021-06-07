
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Models
{
	public class Context : DbContext
	{

		public Context(DbContextOptions<Context> options) : base(options)
		{

		}

        public Context()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.HasOne<User>(s => s.User)
				.WithMany(g => g.Orders)
				.HasForeignKey(s => s.DriverId);
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}
