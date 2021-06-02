using System.Collections.Generic;
using FoodDelivery.Models;

namespace FoodDelivery.Data
{
	public interface IOrderService
	{
		bool SaveChanges();	
		IEnumerable<Order> GetAll();  // R
		Order GetById(int id);		 // R
		void CreateOrder(Order order);  //CreateUser prakticno C
		void UpdateOrder(Order order);	 // U
		void DeleteOrder(Order order);  // D

	}
}
