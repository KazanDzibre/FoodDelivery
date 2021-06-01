using System.Collections.Generic;
using FoodDelivery.Dtos;
using FoodDelivery.Models;

namespace FoodDelivery.Data
{
	public interface IUserService
	{
		AuthenticateResponse Authenticate(AuthenticateRequest model);
		IEnumerable<User> GetAll();
		User GetById(int id);
		void SignInUser(User user);
		
	}
}
