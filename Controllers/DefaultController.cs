using FoodDelivery.Configuration;
using FoodDelivery.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		protected UserService _userService;
		//protected OrderService _orderService;
		protected ProjectConfiguration configuration;

		public DefaultController(ProjectConfiguration configuration)
		{
			this.configuration = configuration;
			this._userService = new UserService(configuration);
		}
	}
}
