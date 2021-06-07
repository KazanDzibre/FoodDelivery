using FoodDelivery.Core;
using FoodDelivery.Models;

namespace FoodDelivery.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

		private readonly Context context;

		public UnitOfWork(Context context)
		{
			this.context = context;
			Users = new UserRepository(this.context);
			//Orders = new OrderRepository(this.context);
		}


		public IUserRepository Users { get; private set; }

		public Context Context
		{
			get { return context; }
		}

        public int Complete()
        {
			return context.SaveChanges();
        }

        public void Dispose()
        {
			context.Dispose();
        }
    }
}
