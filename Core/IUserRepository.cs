using System.Collections.Generic;
using FoodDelivery.Dtos;
using FoodDelivery.Models;

namespace FoodDelivery.Core
{
	public interface IUserRepository : IRepository<User>
	{
		User GetUserById(int id);
		
		User GetUserWithRegistrationToken(string token);

		IEnumerable<User> GetAllUsers();

		User Authenticate(AuthenticateRequest model);

	}
}
