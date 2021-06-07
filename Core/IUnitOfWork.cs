using System;

namespace FoodDelivery.Core
{
	public interface IUnitOfWork : IDisposable
	{
		int Complete();
	}
}
