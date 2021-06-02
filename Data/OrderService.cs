using System.Collections.Generic;
using FoodDelivery.Models;

namespace FoodDelivery.Data
{
    public class OrderService : IOrderService
    {
        private readonly Context _context;

        public OrderService(Context context)
		{
			_context = context;
		}
        public void CreateOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
