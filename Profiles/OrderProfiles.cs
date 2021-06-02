using AutoMapper;
using FoodDelivery.Dtos;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
	public class OrdersProfile : Profile
	{
		public OrdersProfile()
		{
			CreateMap<Order,CreateOrderDto>();
		}
	}
}
