using System;
using System.Collections.Generic;
using System.Linq;
using FoodDelivery.Models;

namespace FoodDelivery.Service
{
    public class OrderService
    {
        private readonly Context _context;

        public OrderService(Context context)
		{
			_context = context;
		}
        public void CreateOrder(Order order)
        {
			if(order == null)
			{
				throw new ArgumentNullException(nameof(order));
			}

			_context.Orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
			if(order == null)
			{
				throw new ArgumentNullException(nameof(order));
			}
			_context.Orders.Remove(order);
        }

        public IEnumerable<Order> GetAll()
        {
			return _context.Orders.ToList();
        }

        public Order GetOrdersById(int id)
        {
			return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
			return (_context.SaveChanges() >= 0);
        }

        public void UpdateOrder(Order order)
        {
             _context.Orders.Update(order);
        }
    }
}
