using System.Collections.Generic;
using FoodDelivery.Dtos;
using FoodDelivery.Models;

namespace FoodDelivery.Data
{
	public interface IUserService
	{
		bool SaveChanges();	
		AuthenticateResponse Authenticate(AuthenticateRequest model);
		IEnumerable<User> GetAll();  // R
		User GetById(int id);		 // R
		void SignInUser(User user);  //CreateUser prakticno C
		void UpdateUser(User user);	 // U
		void DeleteUser(User user);  // D

	}
}
