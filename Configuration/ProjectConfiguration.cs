namespace FoodDelivery.Configuration
{
	public class ProjectConfiguration : IProjectConfiguration
	{
		public DatabaseConfiguration DatabaseConfiguration { get; set; } = new DatabaseConfiguration();

	}

	public class DatabaseConfiguration
	{
		public string ConnectionString { get; set; }
	}
}
