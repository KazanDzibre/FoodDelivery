using AutoMapper;
using FoodDelivery.Data;
using FoodDelivery.Dtos;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : ControllerBase
	{
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}

		//POST orders/post
		[HttpPost("post")]
		public ActionResult CreateOrder(CreateOrderDto createOrderDto)
		{
			var orderModel = _mapper.Map<Order>(createOrderDto);
			_orderService.CreateOrder(orderModel);
			_orderService.SaveChanges();

			return Ok();
		}

		// // Ovo bi bio log in
		// [HttpPost("authenticate")]
		// public IActionResult Authenticate(AuthenticateRequest model)
		// {
			// var response = _userService.Authenticate(model);

			// if(response == null)
			// {
				// return BadRequest(new { message = "Username or password is incorrect" });
			// }

			// return Ok(response);
		// }


		// // GET users
		// [Authorize]
		// [HttpGet]
		// public ActionResult<IEnumerable<UserReadDto>> GetAll()
		// {
			// var userItems = _userService.GetAll();

			// return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
		// }

		// //GET user/{id}
		// [HttpGet("{id}", Name="GetById")]
		// public ActionResult<UserReadDto> GetById(int id)
		// {
			// var userItem = _userService.GetById(id);
			// if(userItem != null)
			// {
				// return Ok(_mapper.Map<UserReadDto>(userItem));
			// }
			// return NotFound();
		// }

		// //DELETE /users/{id}
		// [HttpDelete("{id}")]
		// public ActionResult DeleteUser(int id)
		// {
			// var userModelFromRepo = _userService.GetById(id);
			// if(userModelFromRepo == null)
			// {
				// return NotFound();
			// }
			// _userService.DeleteUser(userModelFromRepo);
			// _userService.SaveChanges();

			// return NoContent();
		// }

		// //PUT users/{id}
		// [HttpPut("{id}")]
		// public ActionResult UpdateUser(int id, UserRegisterDto userRegisterDto)
		// {
			// var userModelFromRepo = _userService.GetById(id);
			// if(userModelFromRepo == null)
			// {
				// return NotFound();
			// }
			// _mapper.Map(userRegisterDto,userModelFromRepo);

			// _userService.UpdateUser(userModelFromRepo); // ovo zapravo ne radi nista, jer ovaj mapping gore odradi to za mene, tako da ovo mozemo i da skinemo ili da implementiram UpdateUser u UserService.cs

			// _userService.SaveChanges();

			// return NoContent();
		// }

		// //PATCH users/{id}
		// [HttpPatch("{id}")]
		// public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserRegisterDto> patchDoc)
		// {
			// var userModelFromRepo = _userService.GetById(id);
			// if(userModelFromRepo == null)
			// {
				// return NotFound();
			// }

			// var userToPatch = _mapper.Map<UserRegisterDto>(userModelFromRepo);
			// patchDoc.ApplyTo(userToPatch, ModelState);

			// if(!TryValidateModel(userToPatch))
			// {
				// return ValidationProblem(ModelState);
			// }

			// _mapper.Map(userToPatch, userModelFromRepo);

			// _userService.UpdateUser(userModelFromRepo);
			// _userService.SaveChanges();

			// return NoContent();
		// }
	}
}
