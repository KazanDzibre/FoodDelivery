using System.Collections.Generic;
using AutoMapper;
using FoodDelivery.Data;
using FoodDelivery.Dtos;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		//POST users/register
		[HttpPost("register")]
		public ActionResult SignInUser(UserRegisterDto userRegisterDto)
		{
			var userModel = _mapper.Map<User>(userRegisterDto);
			_userService.SignInUser(userModel);
			_userService.SaveChanges();

			return Ok();
		}

		// Ovo bi bio log in
		[HttpPost("authenticate")]
		public IActionResult Authenticate(AuthenticateRequest model)
		{
			var response = _userService.Authenticate(model);

			if(response == null)
			{
				return BadRequest(new { message = "Username or password is incorrect" });
			}

			return Ok(response);
		}


		// GET users
		[Authorize]
		[HttpGet]
		public ActionResult<IEnumerable<UserReadDto>> GetAll()
		{
			var userItems = _userService.GetAll();

			return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
		}

		//GET user/{id}
		[HttpGet("{id}", Name="GetById")]
		public ActionResult<UserReadDto> GetById(int id)
		{
			var userItem = _userService.GetById(id);
			if(userItem != null)
			{
				return Ok(_mapper.Map<UserReadDto>(userItem));
			}
			return NotFound();
		}

		//DELETE /users/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteUser(int id)
		{
			var userModelFromRepo = _userService.GetById(id);
			if(userModelFromRepo == null)
			{
				return NotFound();
			}
			_userService.DeleteUser(userModelFromRepo);
			_userService.SaveChanges();

			return NoContent();
		}
	}
}
